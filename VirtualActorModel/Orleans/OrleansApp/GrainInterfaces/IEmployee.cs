using System;
using System.Threading.Tasks;

using Orleans;
using Orleans.Concurrency;

namespace GrainInterfaces
{
    public interface IEmployee : IGrainWithGuidKey
    {
        Task<int> GetLevel();
        Task Promote(int newLevel);

        Task<IManager> GetManager();
        Task SetManager(IManager manager);

        Task Greeting(GreetingData data);
    }

    [Immutable] //Indicates to orleans not to pass deep copy but reference to our object because
    //we promised that we will not change it.
    public class GreetingData
    {
        public Guid From { get; set; }
        public string Message { get; set; }
        public int Count { get; set; }
    }
}
