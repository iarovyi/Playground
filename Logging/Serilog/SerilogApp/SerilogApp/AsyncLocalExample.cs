using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace SerilogApp
{
    /// <summary>
    /// General documentation
    /// https://docs.microsoft.com/en-us/dotnet/api/system.threading.asynclocal-1?view=netframework-4.7.2
    /// 
    /// Async local is saved within Execution Context
    /// https://referencesource.microsoft.com/#mscorlib/system/threading/executioncontext.cs,670
    ///
    /// Example of usage from Serilog
    /// https://github.com/serilog/serilog/blob/dev/src/Serilog/Context/LogContext.cs#L56
    /// </summary>
    public class AsyncLocalExample
    {
        const string InitialValue = "initial value";
        const string NewValue = "new value";
        static readonly AsyncLocal<string> _asyncLocalString = new AsyncLocal<string>() { Value = InitialValue };

        public static async Task Demo(TextWriter console)
        {
            console.WriteLine($"{FormatExpectedResult(InitialValue)} Initiating task has initial value'");

            //-------- Child task can modify value and its child tasks will inherit modified value ------
            await Task.Factory.StartNew(async () =>
            {
                _asyncLocalString.Value = NewValue;
                console.WriteLine($"{FormatExpectedResult(NewValue)} Child task can modify value");

                await Task.Factory.StartNew(() =>
                {
                    console.WriteLine($"{FormatExpectedResult(NewValue)} Child task inherit modified value by parent task");
                });
            });

            //-------- Async local can be supressed ----------------------------------------------------
            Task taskWithSupressedFlow;
            using (AsyncFlowControl flow = ExecutionContext.SuppressFlow())
            {
                taskWithSupressedFlow = Task.Factory.StartNew(() =>
                {
                    console.WriteLine($"{FormatExpectedResult(null)} value can be suppressed");
                });
            }
            await taskWithSupressedFlow;

            //-------- Child task inherit value --------------------------------------------------------
            await Task.Delay(TimeSpan.FromSeconds(2));
            await Task.Factory.StartNew(() =>
            {
                console.WriteLine($"{FormatExpectedResult(InitialValue)} Child task inherited initial value");
            });

            //------- Child thread inherit value ------------------------------------------------------
            var childThread = new Thread(() =>
            {
                console.WriteLine($"{FormatExpectedResult(InitialValue)} Child thread inherited initial value");
            });
            childThread.Start();
            childThread.Join();
        }

        static string FormatExpectedResult(string expectedState) =>
            _asyncLocalString.Value == expectedState ? "[SUCCESS]" : "[FAILED]";
    }
}
