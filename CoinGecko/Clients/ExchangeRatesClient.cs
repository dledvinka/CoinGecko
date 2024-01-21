using CoinGecko.ApiEndPoints;
using CoinGecko.Authentication;
using CoinGecko.Entities.Response.ExchangeRates;
using CoinGecko.Interfaces;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace CoinGecko.Clients
{
    public class ExchangeRatesClient : BaseApiClient, IExchangeRatesClient
    {
        public ExchangeRatesClient(HttpClient httpClient, JsonSerializerSettings serializerSettings) : base(httpClient, serializerSettings)
        {
        }

        public ExchangeRatesClient(HttpClient httpClient, JsonSerializerSettings serializerSettings, ApiKey apiKey) : base(httpClient, serializerSettings, apiKey)
        {
        }

        public async Task<ExchangeRates> GetExchangeRates()
        {
            return await GetAsync<ExchangeRates>(
                AppendQueryString(ExchangeRatesApiEndPoints.ExchangeRate)).ConfigureAwait(false);
        }
    }
}