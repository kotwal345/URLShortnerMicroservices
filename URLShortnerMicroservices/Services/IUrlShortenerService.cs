namespace URLShortnerMicroservices.Services
{
    /// <summary>
    /// Interface layer for the URL Service.
    /// </summary>
    public interface IUrlShortenerService
    {
        /// <summary>
        /// Method which will perform the shortning of the long url provided.
        /// </summary>
        /// <param name="originalUrl">Instance Of string</param>
        /// <returns>Instance of string indicating shortned url for longUrl. </returns>
        Task<string> ShortenUrlAsync(string originalUrl);

        /// <summary>
        /// Method will return the valid long url for given shortUrl.
        /// </summary>
        /// <param name="shortCode">Instance of string</param>
        /// <returns>Instance of string representing the long url for given short URL. </returns>
        Task<string?> GetOriginalUrlAsync(string shortCode);
    }
}
