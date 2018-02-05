using System;

using GrainInterfaces;

using Orleans;
using Orleans.Runtime.Configuration;
using Orleans.Runtime.Host;

namespace SiloHostApp
{
    /*
     Don't run this app.
     Instead run "OrleansHost.exe" from nuget package with "OrleansConfiguration.xml" and extra change in "OrleansHost.exe.config"
         */
    public class Program
    {
        static SiloHost siloHost;

        static void Main(string[] args)
        {
            AppDomain hostDomain = AppDomain.CreateDomain("OrleansHost", null,
                new AppDomainSetup()
                {
                    AppDomainInitializer = InitSilo
                });

            Console.WriteLine("Silo started.");

            DoSomeClientWork();
            Console.WriteLine("\nPress Enter to terminate...");
            Console.ReadLine();

            hostDomain.DoCallBack(ShutdownSilo);
        }

        private static void DoSomeClientWork()
        {
            var clientConfig = ClientConfiguration.LocalhostSilo(30000);
            //var client = new ClientBuilder().UseConfiguration(clientConfig).Build();
            //client.Connect().Wait();
            GrainClient.Initialize(clientConfig);
            var client = GrainClient.GrainFactory.GetGrain<IEmailGrain>(0);

            Console.WriteLine("\n\n{0}\n\n", client.SendMessage("", "").Result);
        }

        private static void InitSilo(string[] args)
        {
            var siloConfig = ClusterConfiguration.LocalhostPrimarySilo();
            siloHost = new SiloHost(System.Net.Dns.GetHostName(), siloConfig);
            siloHost.InitializeOrleansSilo();
            var startedok = siloHost.StartOrleansSilo();

            if (!startedok) { throw new SystemException($"Failed to start Orleans silo '{siloHost.Name}' as a {siloHost.Type} node"); }
        }

        static void ShutdownSilo()
        {
            if (siloHost != null)
            {
                siloHost.Dispose();
                GC.SuppressFinalize(siloHost);
                siloHost = null;
            }
        }
    }
}
