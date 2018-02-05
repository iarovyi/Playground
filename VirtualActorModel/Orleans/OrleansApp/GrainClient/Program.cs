using System;

using GrainInterfaces;

using Orleans;
using Orleans.Runtime.Configuration;
using Orleans.Runtime.Host;

namespace GrainClientApp
{
    /*Orleans guarantees single-threaded execution of each individual grain
      Cleaning up: Grain is removed from memory (deactivates) when they are idle for too long.
      Failover:    Grains that were executing on a failed server get automatically re-instantiated on other servers
      Silo - container of grains (usually one per machine)
      Grain (virtual actor) states:
      1) Activating
      2) Active in memory
      3) Deactivating
      4) Persisted

      Run Orleans as:
      1) AppDomain in your app
      2) Run OrleansHost.exe from "Microsoft.Orleans.OrleansHost" nuget package with "OrleansConfiguration.xml" file

     OnActivateAsync and OnDeactivateAsync should be used instead of constructor and disposal
     Orleans waits for 30 seconds (10 minutes with the debugger), then kills the requ

      Orleans uses custom task scheduler in order to make sure that grain is executed on the same thread.
      So use await Task.Factory.StartNew(() =>{ ... }); and not Task.Run

      Plugin for Visual Studio: https://marketplace.visualstudio.com/items?itemName=sbykov.MicrosoftOrleansToolsforVisualStudio
    */
    public class Program
    {
        static void Main(string[] args)
        {
            DoSomeClientWork();
        }

        private static void DoSomeClientWork()
        {
            var clientConfig = ClientConfiguration.LocalhostSilo(30000);
            //var client = new ClientBuilder().UseConfiguration(clientConfig).Build();
            //client.Connect().Wait();
            GrainClient.Initialize(clientConfig);

            var grainFactory = GrainClient.GrainFactory;
            var e0 = grainFactory.GetGrain<IEmployee>(Guid.NewGuid());
            var e1 = grainFactory.GetGrain<IEmployee>(Guid.NewGuid());
            var e2 = grainFactory.GetGrain<IEmployee>(Guid.NewGuid());
            var e3 = grainFactory.GetGrain<IEmployee>(Guid.NewGuid());
            var e4 = grainFactory.GetGrain<IEmployee>(Guid.NewGuid());

            var m0 = grainFactory.GetGrain<IManager>(Guid.NewGuid());
            var m1 = grainFactory.GetGrain<IManager>(Guid.NewGuid());
            var m0e = m0.AsEmployee().Result;
            var m1e = m1.AsEmployee().Result;

            m0e.Promote(10);
            m1e.Promote(11);

            m0.AddDirectReport(e0).Wait();
            m0.AddDirectReport(e1).Wait();
            m0.AddDirectReport(e2).Wait();

            m1.AddDirectReport(m0e).Wait();
            m1.AddDirectReport(e3).Wait();

            m1.AddDirectReport(e4).Wait();

            // retrieve the MSFT stock
            var grain = GrainClient.GrainFactory.GetGrain<IStockGrain>("MSFT");
            var price = grain.GetPrice().Result;
            Console.WriteLine(price);

            Console.WriteLine("Finished");
            Console.ReadKey();
        }
    }
}
