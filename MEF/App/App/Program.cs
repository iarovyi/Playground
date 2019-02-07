using System;
using System.Collections.Generic;
using System.Composition.Convention;
using System.Composition.Hosting;
using System.IO;
using Contract;

namespace App
{
    class Program
    {
        static void Main(string[] args)
        {
            var conventions = new ConventionBuilder();
            conventions
                .ForTypesDerivedFrom<IPlugin>()
                .Export<IPlugin>()
                .Shared();

            var assemblies = new[] { typeof(MyEmbeddedPlugin).Assembly };
            string pluginsDir = Path.Combine(Directory.GetCurrentDirectory(), @"../../../../ExtensionA/bin/Debug/netstandard2.0");

            var configuration = new ContainerConfiguration()
                .WithAssemblies(assemblies, conventions)
                .WithAssembliesInPath(pluginsDir, conventions);

            using (CompositionHost container = configuration.CreateContainer())
            {
                IEnumerable<IPlugin> plugins = container.GetExports<IPlugin>();
                foreach (IPlugin plugin in plugins)
                {
                    Console.WriteLine(plugin.GetName());
                }
            }

            Console.WriteLine("Completed");
            Console.ReadKey();
        }
    }
}
