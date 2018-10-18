using System.Drawing;
using System.Threading.Tasks;
using Serilog;
using Serilog.Context;
using Serilog.Core;
using Serilog.Formatting.Json;
using Console = Colorful.Console;

namespace SerilogApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Logging context with Serilog", Color.Green);
            LoggingContextWithSerilog().Wait();

            Console.WriteLine("Custom logging context", Color.Green);
            CustomLoggingContext().Wait();

            Console.WriteLine("Finished, press any key", Color.Green);
            Console.ReadKey();
        }

        static Task CustomLoggingContext() => AsyncLocalExample.Demo(Console.Out);

        static async Task LoggingContextWithSerilog()
        {
            using (Logger log = new LoggerConfiguration()
                                    .Enrich.FromLogContext()
                                    .WriteTo.Console(new JsonFormatter())
                                    .CreateLogger())
            {

                using (LogContext.PushProperty("CorrelationId", "hello"))
                {
                    await Task.Factory.StartNew(() =>
                    {
                        log.Information("All log events with context contains CorrelationId=hello");
                    });
                }

                log.Information("Log event outside context does not contain CorrelationId");
            }
        }
    }
}
