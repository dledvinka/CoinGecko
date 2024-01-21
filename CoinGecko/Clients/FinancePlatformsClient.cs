﻿using CoinGecko.ApiEndPoints;
using CoinGecko.Authentication;
using CoinGecko.Entities.Response.Finance;
using CoinGecko.Interfaces;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace CoinGecko.Clients
{
    public class FinancePlatformsClient : BaseApiClient, IFinancePlatformsClient
    {
        public FinancePlatformsClient(HttpClient httpClient, JsonSerializerSettings serializerSettings) : base(httpClient, serializerSettings)
        {
        }

        public FinancePlatformsClient(HttpClient httpClient, JsonSerializerSettings serializerSettings, ApiKey apiKey) : base(httpClient, serializerSettings, apiKey)
        {
        }

        public async Task<IReadOnlyList<FinancePlatforms>> GetFinancePlatforms()
        {
            return await GetFinancePlatforms(50, "100").ConfigureAwait(false);
        }

        public async Task<IReadOnlyList<FinancePlatforms>> GetFinancePlatforms(int perPage, string page)
        {
            return await GetAsync<IReadOnlyList<FinancePlatforms>>(AppendQueryString(
                FinancePlatformsApiEndPoints.FinancePlatform, new Dictionary<string, object>
                {
                    {"per_page",perPage},
                    {"page",page}
                }
            )).ConfigureAwait(false);
        }

        public async Task<IReadOnlyList<FinanceProducts>> GetFinanceProducts()
        {
            return await GetFinanceProducts(50, "100", "", "").ConfigureAwait(false);
        }

        public async Task<IReadOnlyList<FinanceProducts>> GetFinanceProducts(int perPage, string page, string startAt, string endAt)
        {
            return await GetAsync<IReadOnlyList<FinanceProducts>>(AppendQueryString(
                    FinancePlatformsApiEndPoints.FinanceProducts, new Dictionary<string, object>
                    {
                        {"per_page",perPage},
                        {"page",page},
                        {"startAt",startAt},
                        {"endAt",endAt}
                    }))
                .ConfigureAwait(false);
        }
    }
}