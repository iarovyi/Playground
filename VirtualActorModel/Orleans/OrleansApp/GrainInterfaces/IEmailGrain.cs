using System.Threading.Tasks;
using Orleans;

namespace GrainInterfaces
{
    /// <summary>
    /// Grain interface IEmailGrain
    /// </summary>
    public interface IEmailGrain : IGrainWithIntegerKey
    {
        Task<string> SendMessage(string address, string message);
    }
}
