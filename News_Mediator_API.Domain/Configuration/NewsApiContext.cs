using EntityFrameworkCore.Triggers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using News_Mediator_API.Domain.Models;

namespace News_Mediator_API.Configuration;

public class NewsApiContext : DbContextWithTriggers
{
    private readonly IConfiguration Configuration;
    public NewsApiContext(DbContextOptions options, IConfiguration configuration) : base(options)
    {
        Configuration = configuration;
    }
    public DbSet<News> News { get; set; }
    public DbSet<BookMark> BookMarks { get; set; }
    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new BookmarkNewsConfiguration());
        modelBuilder.ApplyConfiguration(new UserConfiguration());
    }
}
