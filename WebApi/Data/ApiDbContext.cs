

using Microsoft.EntityFrameworkCore;
using WebApi.models;

namespace WebApi.Data
{
    public class ApiDbContext: DbContext
    {
        public ApiDbContext(DbContextOptions<ApiDbContext>options) : base(options)
        {

        }

        public DbSet<Song> Songs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Song>().HasData(
                new Song() { Id = 1, Title = "DDLJ", Duration = 300, Language = "Hindi" },
                new Song() { Id = 2, Title = "Perfect", Duration = 240, Language = "English" }
                );
        }
    }
}
