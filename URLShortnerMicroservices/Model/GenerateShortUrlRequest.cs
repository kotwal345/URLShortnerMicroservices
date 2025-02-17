using System.ComponentModel.DataAnnotations;

namespace URLShortnerMicroservices.Model
{
    /// <summary>
    /// Request Data Flow object generate sort url method.
    /// </summary>
    public class GenerateShortUrlRequest
    {
        /// <summary>
        /// Instance of string Representing the longUrl
        /// </summary>
        
        //[Required]
        //[MinLength(3)]

        public string longUrl { get; set; }
    }
}
