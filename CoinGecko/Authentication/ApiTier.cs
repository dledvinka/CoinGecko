namespace CoinGecko.Authentication
{
    /// <summary>
    /// API tier
    /// </summary>
    public enum ApiTier
    {
        /// <summary>
        /// Free tier. Free to use.
        /// </summary>
        Free,
        
        /// <summary>
        /// Demo tier. Free to use. Uses same endpoint as the free tier.
        /// </summary>
        Demo,

        /// <summary>
        /// Paid tier. Uses different endpoint.
        /// </summary>
        Paid
    }
}
