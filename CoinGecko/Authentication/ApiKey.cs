namespace CoinGecko.Authentication
{
    /// <summary>
    /// API key
    /// </summary>
    public class ApiKey
    {
        /// <summary>
        /// No API key instance.
        /// </summary>
        internal static ApiKey NoApiKey => new ApiKey(string.Empty, ApiTier.Free);

        /// <summary>
        /// Creates a new instance of <see cref="ApiKey"/>. Free tier API endpoint will be used.
        /// </summary>
        /// <param name="apiKey"></param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentException"></exception>
        public static ApiKey CreateDemoApiKey(string apiKey)
        {
            if (string.IsNullOrWhiteSpace(apiKey))
                throw new System.ArgumentException("API key cannot be null.");

            return new ApiKey(apiKey, ApiTier.Demo);
        }

        /// <summary>
        /// Creates a new instance of <see cref="ApiKey"/>. Paid tier API endpoint will be used.
        /// </summary>
        /// <param name="apiKey"></param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentException"></exception>
        public static ApiKey CreatePaidApiKey(string apiKey)
        {
            if (string.IsNullOrWhiteSpace(apiKey))
                throw new System.ArgumentException("API key cannot be null.");

            return new ApiKey(apiKey, ApiTier.Paid);
        }

        /// <summary>
        /// API Key.
        /// </summary>
        public string Key { get; }

        /// <summary>
        /// API Tier.
        /// </summary>
        public ApiTier Tier { get; }

        /// <summary>
        /// Creates a new instance of <see cref="ApiKey"/>.
        /// </summary>
        /// <param name="apiKey"></param>
        /// <param name="apiTier"></param>
        private ApiKey(string apiKey, ApiTier apiTier)
        {
            Key = apiKey;
            Tier = apiTier;
        }
    }
}
