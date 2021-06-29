using Pulumi;
using Pulumi.Aws.Ec2;
using Pulumi.Aws.Ec2.Inputs;

namespace Components
{
    public class WebAppArgs
    {
        public Input<string> VpcId { get; set; }
        public Input<string> SubnetId { get; set; }
        public GetAmiArgs Ami { get; set; }
        public string UserdataScript { get; set; }
        public Input<bool>? AssociatePublicIpAddress { get; set; } = Output.Create(false);
        public string Ec2Size { get; set; } = "t2.micro";
        public int Port { get; set; } = 80;
        public string Whitelisting { get; set; } = "0.0.0.0/0";
    }

    public class WebApp : ComponentResource
    {
        public WebApp(string name, WebAppArgs args)
            : base("aws:component:webapp", name)
        {
            var ami = Output.Create(GetAmi.InvokeAsync(args.Ami));

            var group = new SecurityGroup($"{name}-web-sg", new SecurityGroupArgs
            {
                Description = "Enable HTTP access",
                VpcId = args.VpcId,
                Ingress =
            {
                new SecurityGroupIngressArgs
                {
                    Protocol = "tcp",
                    FromPort = 80,
                    ToPort = 80,
                    CidrBlocks = {args.Whitelisting}
                }
            }
            });

            var server = new Instance($"{name}-server", new InstanceArgs
            {
                InstanceType = args.Ec2Size,
                VpcSecurityGroupIds = { group.Id },
                UserData = args.UserdataScript,
                Ami = ami.Apply(a => a.Id),
                SubnetId = args.SubnetId,
                AssociatePublicIpAddress = args.AssociatePublicIpAddress
            });

            this.PublicIp = server.PublicIp;
            this.PublicDns = server.PublicDns;
        }

        [Output] public Output<string> PublicIp { get; set; }

        [Output] public Output<string> PublicDns { get; set; }
    }
}
