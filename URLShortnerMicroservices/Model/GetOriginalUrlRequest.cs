namespace URLShortnerMicroservices.Model
{
    /// <summary>
    /// Request Data Flow object generate long url method.
    /// class representing the request attributes for the API GetOriginalUrl.
    /// </summary>
    public class GetOriginalUrlRequest
    {
        /// <summary>
        /// Instance of string Representing the shortUrl
        /// </summary>
        public string shortUrl { get; set; }
    }
}
