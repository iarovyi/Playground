using Pulumi;
using Pulumi.Aws.Ec2;

namespace Components
{
    public class NetworkingArgs
    {
        public string Name { get; set; }
        public string PrimaryCidrBlock { get; set; }
        public string PrivateCidrBlock { get; set; }
        public string? PublicCidrBlock { get; set; }
    }

    public class Networking : ComponentResource
    {
        public Networking(string name, NetworkingArgs args, ComponentResourceOptions? options = null)
            : base("aws:component:networking", name, options)
        {
            var customOptions = new CustomResourceOptions()
            {
                DependsOn = options?.DependsOn,
                Parent = this
            };

            var vpc = new Vpc(args.Name, new VpcArgs
            {
                CidrBlock = args.PrimaryCidrBlock
            }, customOptions);

            var privateSubnet = new Subnet($"{args.Name}-private", new SubnetArgs()
            {
                CidrBlock = args.PrivateCidrBlock,
                VpcId = vpc.Id
            }, customOptions);

            if (!string.IsNullOrEmpty(args.PublicCidrBlock))
            {
                var publicSubnet = new Subnet($"{args.Name}-public", new SubnetArgs()
                {
                    CidrBlock = args.PublicCidrBlock,
                    VpcId = vpc.Id
                }, customOptions);

                PublicSubnetId = publicSubnet.Id;
            } else
            {
                PublicSubnetId = Output.Create(null as string);
            }

            VpcId = privateSubnet.VpcId;
            PrivateSubnetId = privateSubnet.Id;
        }

        [Output]
        public Output<string> VpcId { get; set; }

        [Output]
        public Output<string> PrivateSubnetId { get; set; }

        [Output]
        public Output<string?> PublicSubnetId { get; set; }
    }
}
