using Microsoft.EntityFrameworkCore;
using WebScrapper.Data.Models;

namespace WebScrapper.Data.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SearchEngines>().HasData(
                new List<SearchEngines>()
                {
                    new()
                    {
                        Id = 1,
                        BaseUrl = "http://www.google.co.uk",
                        //ResultExtractionExpression = @"gMi0 kCrYT(.+?)sa=U&ved=",
                        ResultExtractionExpression = @"q=([^&]+)",
                        SearchUrl = "search?q=#SearchText#&num=#NumberResultsToSearchIn#",
                        Title = "Google"
                    },
                    new()
                    {
                        Id = 2,
                        BaseUrl = "http://www.bing.com",
                        ResultExtractionExpression = @"((<cite>)(.+?)(</cite>))",
                        SearchUrl = "search?q=#SearchText#",
                        Title = "Bing"
                    },
                }
            );
        }

        public virtual DbSet<SearchResults> SearchResults { get; set; }

        public virtual DbSet<SearchEngines> SearchEngines { get; set; }
    }
}
