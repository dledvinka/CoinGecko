using CoinGecko.ApiEndPoints;
using CoinGecko.Authentication;
using CoinGecko.Entities.Response.Events;
using CoinGecko.Interfaces;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace CoinGecko.Clients
{
    public class EventsClient : BaseApiClient, IEventsClient
    {
        public EventsClient(HttpClient httpClient, JsonSerializerSettings serializerSettings) : base(httpClient, serializerSettings)
        {
        }

        public EventsClient(HttpClient httpClient, JsonSerializerSettings serializerSettings, ApiKey apiKey) : base(httpClient, serializerSettings, apiKey)
        {
        }

        public async Task<Events> GetEvents()
        {
            return await GetEvents(new string[] { }, new string[] { }, null, null, null, null).ConfigureAwait(false);
        }

        public async Task<Events> GetEvents(string[] countryCode, string[] type, string page, string upcommingEventsOnly,
            string fromDate, string toDate)
        {
            return await GetAsync<Events>(AppendQueryString(EventsApiEndPoints.Events,
                new Dictionary<string, object>
                {
                    {"country_code",string.Join(",",countryCode)},
                    {"type",string.Join(",",type)},
                    {"page",page},
                    {"upcoming_events_only",upcommingEventsOnly},
                    {"from_date",fromDate},
                    {"to_date",toDate}
                })).ConfigureAwait(false);
        }

        public async Task<EventCountry> GetEventCountry()
        {
            return await GetAsync<EventCountry>(
                AppendQueryString(EventsApiEndPoints.EventsCountries)).ConfigureAwait(false);
        }

        public async Task<EventTypes> GetEventTypes()
        {
            return await GetAsync<EventTypes>(AppendQueryString(EventsApiEndPoints.EventsTypes)).ConfigureAwait(false);
        }
    }
}