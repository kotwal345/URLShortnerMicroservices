
using System;
using URLShortnerMicroservices.Model;

namespace URLShortnerMicroservices.Services
{
    public class URLShortenerService : IUrlShortenerService
    {
        private const string Alphabet = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

        private Random _random = new Random();
        public Task<string?> GetOriginalUrlAsync(string shortCode)
        {
            throw new NotImplementedException();
        }

        public Task<string> ShortenUrlAsync(string originalUrl)
        {

            //generate short code
            var shortcode = GenerateShortCode();
            //Add prefix if nedded
            var shortUrl = "newgen.ly" + shortcode;
            //add into database
            var mapping = new urlMapping();
            mapping.shortUrl = shortUrl;
            mapping.longUrl = originalUrl;

            
            throw new NotImplementedException();
        }
        private string GenerateShortCode(int length = 6)
        {
            return new string(Enumerable.Repeat(Alphabet, length).Select(s => s[_random.Next(s.Length)]).ToArray());
        }
    }
}
