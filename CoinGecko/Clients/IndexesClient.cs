﻿using CoinGecko.ApiEndPoints;
using CoinGecko.Authentication;
using CoinGecko.Entities.Response.Indexes;
using CoinGecko.Interfaces;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace CoinGecko.Clients
{
    public class IndexesClient : BaseApiClient, IIndexesClient
    {
        public IndexesClient(HttpClient httpClient, JsonSerializerSettings serializerSettings) : base(httpClient, serializerSettings)
        {
        }

        public IndexesClient(HttpClient httpClient, JsonSerializerSettings serializerSettings, ApiKey apiKey) : base(httpClient, serializerSettings, apiKey)
        {
        }

        public async Task<IReadOnlyList<IndexData>> GetIndexes()
        {
            return await GetIndexes(null, "").ConfigureAwait(false);
        }

        public async Task<IReadOnlyList<IndexData>> GetIndexes(int? perPage, string page)
        {
            return await GetAsync<IReadOnlyList<IndexData>>(AppendQueryString(
                IndexesApiEndPointUrl.IndexesUrl, new Dictionary<string, object>
                {
                    {"per_page",perPage},
                    {"page",page}
                })).ConfigureAwait(false);
        }

        public async Task<IndexData> GetIndexById(string id)
        {
            return await GetAsync<IndexData>(AppendQueryString(
                IndexesApiEndPointUrl.IndexesWithId(id))).ConfigureAwait(false);
        }

        public async Task<IReadOnlyList<IndexList>> GetIndexList()
        {
            return await GetAsync<IReadOnlyList<IndexList>>(AppendQueryString(
                IndexesApiEndPointUrl.IndexesList)).ConfigureAwait(false);
        }
    }
}