using System;
using System.Collections.Generic;
using aws;
using Constructs;
using HashiCorp.Cdktf;

namespace MyCompany.MyApp
{
    class MyApp : TerraformStack
    {
        public MyApp(Construct scope, string id) : base(scope, id)
        {
            //1. Specify providers
            var awsProvider = new AwsProvider(this, "AWS", new AwsProviderConfig
            {
                Region = "us-east-1"
            });

            //2.  Create resources directly
            new Instance(this, "hello", new InstanceConfig
            {
                Ami = "ami-2757f631",
                InstanceType = "t2.micro"
            });

            //3. Deploy existing terraform modules
            new TerraformHclModule(this, "network", new TerraformHclModuleOptions()
            {
                Source = "git@github.com:MySoftware/Infrastructure.Modules.NetworkZone//aws?ref=v4.4.0",
                Variables = new Dictionary<string, object>()
                {
                    {"name",               "myzone" },
                    {"primary_cidr_block", "10.61.0.0/22" },
                    {"common_tags",        new Dictionary<string,string>(){ {"mytag", "myvalue" } } }
                },
            });
        }

        public static void Main(string[] args)
        {
            App app = new App();
            new MyApp(app, "cdktf");
            app.Synth();
            Console.WriteLine("App synth complete");
        }
    }
}