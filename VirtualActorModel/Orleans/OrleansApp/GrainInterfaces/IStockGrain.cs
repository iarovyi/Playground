using System.Threading.Tasks;

namespace GrainInterfaces
{
    public interface IStockGrain : Orleans.IGrainWithStringKey
    {
        Task<string> GetPrice();
    }
}
