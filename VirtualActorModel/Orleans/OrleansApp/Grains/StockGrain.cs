using System;
using System.Net.Http;
using System.Threading.Tasks;

using GrainInterfaces;

using Orleans;

namespace Grains
{
    public class StockGrain : Grain, IStockGrain
    {
        string price;

        public override async Task OnActivateAsync()
        {
            string stock;
            this.GetPrimaryKey(out stock);
            await UpdatePrice(stock);
            var timer = RegisterTimer(
                UpdatePrice,
                stock,
                TimeSpan.FromMinutes(1),
                TimeSpan.FromMinutes(1));

            await base.OnActivateAsync();
        }

        async Task UpdatePrice(object stock)
        {
            price = await GetPriceFromYahoo(stock as string);
            Console.WriteLine(price);
        }

        async Task<string> GetPriceFromYahoo(string stock)
        {
            
            var uri = "http://download.finance.yahoo.com/d/quotes.csv?f=snl1c1p2&e=.csv&s=" + stock;
            using (var http = new HttpClient())
            using (var resp = await http.GetAsync(uri))
            {
                return await resp.Content.ReadAsStringAsync();
            }
        }

        public Task<string> GetPrice()
        {
            return Task.FromResult(price);
        }
    }
}
