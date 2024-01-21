﻿using CoinGecko.ApiEndPoints;
using CoinGecko.Authentication;
using CoinGecko.Entities.Response.StatusUpdates;
using CoinGecko.Interfaces;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace CoinGecko.Clients
{
    public class StatusUpdateClient : BaseApiClient, IStatusUpdatesClient
    {
        public StatusUpdateClient(HttpClient httpClient, JsonSerializerSettings serializerSettings) : base(httpClient, serializerSettings)
        {
        }

        public StatusUpdateClient(HttpClient httpClient, JsonSerializerSettings serializerSettings, ApiKey apiKey) : base(httpClient, serializerSettings, apiKey)
        {
        }

        public async Task<StatusUpdate> GetStatusUpdate()
        {
            return await GetStatusUpdate("", "", null, null).ConfigureAwait(false);
        }

        public async Task<StatusUpdate> GetStatusUpdate(string category, string projectType, int? perPage, int? page)
        {
            return await GetAsync<StatusUpdate>(AppendQueryString(
                StatusUpdateApiEndPoints.StatusUpdateUrl, new Dictionary<string, object>
                {
                    {"category",category},
                    {"project_type",projectType},
                    {"per_page",perPage},
                    {"page",page}
                })).ConfigureAwait(false);
        }
    }
}