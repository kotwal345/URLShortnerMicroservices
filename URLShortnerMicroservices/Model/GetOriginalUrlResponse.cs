namespace URLShortnerMicroservices.Model
{
    /// <summary>
    /// Response model class for the 
    /// </summary>
    public class GetOriginalUrlResponse : GenerateShortUrlResponse
    {
        public string message { get; set; }
    }
}
