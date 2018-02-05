using System;
using System.Threading.Tasks;

using GrainInterfaces;

using Orleans;
using Orleans.Concurrency;

namespace Grains
{
    [Reentrant] //Will increase timeout because we call other services inside
    public class Employee : Grain, IEmployee
    {
        public Task<int> GetLevel()
        {
            return Task.FromResult(_level);
        }

        public Task Promote(int newLevel)
        {
            _level = newLevel;
            return Task.CompletedTask;
        }

        public Task<IManager> GetManager()
        {
            return Task.FromResult(_manager);
        }

        public Task SetManager(IManager manager)
        {
            _manager = manager;
            return Task.CompletedTask;
        }

        public async Task Greeting(GreetingData data)
        {
            Console.WriteLine("{0} said: {1}", data.From, data.Message);

            // stop this from repeating endlessly
            if (data.Count >= 3) return;

            // send a message back to the sender
            var fromGrain = GrainFactory.GetGrain<IEmployee>(data.From);
            await fromGrain.Greeting(new GreetingData
            {
                From = this.GetPrimaryKey(),
                Message = "Thanks!",
                Count = data.Count + 1
            });
        }

        private int _level;
        private IManager _manager;
    }
}