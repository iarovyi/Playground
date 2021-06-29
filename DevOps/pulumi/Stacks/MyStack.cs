using Components;
using Pulumi;
using Pulumi.Aws.Ec2;
using Pulumi.Aws.Ec2.Inputs;
using Pulumi.Aws.S3;

class MyStack : Stack
{
    public MyStack()
    {
        var cfg = new Config();
        var name = cfg.Require("name");
        var bucket = new Bucket("my-bucket");

        var dbPasswordParam = new Pulumi.Aws.Ssm.Parameter($"/{name}/db-password", new Pulumi.Aws.Ssm.ParameterArgs
        {
            Type = "SecureString",
            Value = cfg.RequireSecret("dbPassword"),
        });
        
        var network = new Networking($"{name}-net", new NetworkingArgs() { 
            Name = "new",
            PrimaryCidrBlock = "20.0.0.0/16",
            PrivateCidrBlock = "20.0.128.0/18"
        });

        var webApp = new WebApp($"{name}-webapp", new WebAppArgs() {
            VpcId = network.VpcId,
            SubnetId = network.PrivateSubnetId,
            AssociatePublicIpAddress = true,
            Ami = new GetAmiArgs
            {
                MostRecent = true,
                Owners = { "137112412989" },
                Filters = { new GetAmiFilterArgs { Name = "name", Values = { "amzn-ami-hvm-*" } } }
            },
            UserdataScript = @"
                #!/bin/bash
                echo ""Hello, World!"" > index.html
                nohup python -m SimpleHTTPServer 80 &
                "
        });

        this.PublicIp = webApp.PublicIp;
        this.PublicDns = webApp.PublicDns;
        this.BucketName = bucket.Id;
        this.DbPasswordSSMParamName = dbPasswordParam.Name;
    }

    [Output]
    public Output<string> BucketName { get; set; }

    [Output]
    public Output<string> DbPasswordSSMParamName { get; set; }

    [Output("public-ip")]
    public Output<string> PublicIp { get; set; }

    [Output("public-dns")]
    public Output<string> PublicDns { get; set; }
}
