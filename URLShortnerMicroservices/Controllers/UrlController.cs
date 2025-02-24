using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using URLShortnerMicroservices.Model;
using URLShortnerMicroservices.Services;

namespace URLShortnerMicroservices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UrlController : ControllerBase
    {
        /// <summary>
        /// Instance of IUrlShortenerService.
        /// </summary>
        private IUrlShortenerService _urlShortnereService;
        public UrlController(IUrlShortenerService urlShortenerService)
        {
            _urlShortnereService = urlShortenerService;
        }
        /// <summary>
        /// This will provide a short url for given long url
        /// </summary>
        /// <param name="request"> Instance of GenerateShortUrlRequest</param>
        /// <returns>On Completion  will return the Long url with valid statuscode</returns>
        [HttpPost("generateShortUrl")]

        public async Task<IActionResult> generateShortUrl([FromBody] GenerateShortUrlRequest request)
        {
            if (string.IsNullOrEmpty(request.longUrl))
            {
                return BadRequest("The Longest needs to be specified ");
            }
            try
            {
                var shortUrl = await _urlShortnereService.ShortenUrlAsync(request.longUrl);
                GenerateShortUrlResponse generateShortUrlReponse = new GenerateShortUrlResponse();
                generateShortUrlReponse.longUrl = request.longUrl;
                generateShortUrlReponse.shortUrl = shortUrl;

                return CreatedAtAction(nameof(generateShortUrl),generateShortUrlReponse);
            }
            catch(Exception ex)
            {
                return StatusCode(500, "Internal server error, Unable to process request ");
            }
        }

        /// <summary>
        /// retrive the original URL associated with the short URL.
        /// </summary>
        /// <param name="request">Instance of GetOriginalUrlRequest containing the short URL to ehich find the original URL</param>
        /// <returns>Response with short URL and Long URL along with message if not found it will be error message.</returns>
        [HttpPost("getOriginalUrl")]
        public async Task<IActionResult> getOriginalUrl([FromBody] GetOriginalUrlRequest request)
        {
            if (string.IsNullOrEmpty(request.shortUrl))
            {
                return BadRequest("Short URL property needs to be specified ");
            }
            try
            {
                var longUrlResponse = await _urlShortnereService.GetOriginalUrlAsync(request.shortUrl);
                GetOriginalUrlResponse getOrignalUrlResponse = new GetOriginalUrlResponse();
                getOrignalUrlResponse.shortUrl = request.shortUrl;
                getOrignalUrlResponse.longUrl = longUrlResponse;

                if (longUrlResponse == null)
                {
                    getOrignalUrlResponse.message = "URL not present into the Database.";
                }
                return Ok(getOrignalUrlResponse);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error occured while processing request ." + ex.Message);
            }
            
        }
    }
}

