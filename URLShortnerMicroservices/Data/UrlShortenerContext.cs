using Microsoft.EntityFrameworkCore;
using URLShortnerMicroservices.Model;

namespace URLShortnerMicroservices.Data
{
    /// <summary>
    /// Database context class for CRUD operation on DB using EF.
    /// </summary>
    public class UrlShortenerContext : DbContext
    {
        /// <summary>
        /// Represent the UrlMappings table in the Database.
        /// </summary>
        public DbSet<UrlMapping> urlMappings { get; set; }

        /// <summary>
        /// This will configure the database engine used for DbContext.
        /// </summary>
        /// <param name="optionsBuilder">Instance of DbContextOptionsBuilder. </param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=LAPTOP-NHR5LA7M\\SQLEXPRESS;Initial Catalog=UrlShortnerDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False");
        }
    }
}
