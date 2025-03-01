
using System;
using Microsoft.EntityFrameworkCore;
using URLShortnerMicroservices.Data;
using URLShortnerMicroservices.Model;

namespace URLShortnerMicroservices.Services
{
    public class URLShortenerService : IUrlShortenerService
    {
        private UrlShortenerContext _context = new UrlShortenerContext();
        private const string Alphabet = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

        private Random _random = new Random();

        /// <summary>
        /// Retrives the original URL associated with the given short URL.
        /// </summary>
        /// <param name="shortUrl">Instance of string indicating the short URL</param>
        /// <returns>The Original URL if found; Otherwise NULL.</returns>
        public async Task<string?> GetOriginalUrlAsync(string shortUrl)
        {

            var response = await _context.urlMappings.FirstOrDefaultAsync(s =>s.shortUrl == shortUrl);
            if (response != null)
            {
                return response.longUrl;
            }
            return null;
        }

        /// <summary>
        /// Shortner an original URL by generating a unique code storing into database.
        /// </summary>
        /// <param name="originalUrl">Instance of string indicating the original URL.</param>
        /// <returns>The newly generated short URL. </returns>
        public async Task<string> ShortenUrlAsync(string originalUrl)
        {

            //generate short code

            var shortcode = GenerateShortCode();
            //Add prefix if nedded
            var shortUrl = "project.ly" + shortcode;
            //add into database
            var mapping = new UrlMapping();
            mapping.shortUrl = shortUrl;
            mapping.longUrl = originalUrl;

            var response = await _context.urlMappings.AddAsync(mapping);
            await _context.SaveChangesAsync();

            return response.Entity.shortUrl;
        }
        private string GenerateShortCode(int length = 6)
        {
            return new string(Enumerable.Repeat(Alphabet, length).Select(s => s[_random.Next(s.Length)]).ToArray());
        }
    }
}

