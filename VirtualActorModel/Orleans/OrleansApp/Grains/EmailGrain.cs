using System;
using System.Threading.Tasks;

using GrainInterfaces;

using Orleans;

namespace Grains
{
    /// <summary>
    /// Grain implementation class Grain1.
    /// </summary>
    public class EmailGrain : Grain, IEmailGrain
    {
        public async Task<string> SendMessage(string address, string message)
        {
            Console.WriteLine($"Sending message to {address}: {message}");
            await Task.Delay(TimeSpan.FromSeconds(20));

            return "Hello from Grain!!";
        }

        public override Task OnActivateAsync()
        {
            //Guid primaryKey = this.GetPrimaryKey();
            return base.OnActivateAsync();
        }

        public override Task OnDeactivateAsync()
        {
            return base.OnDeactivateAsync();
        }
    }
}
