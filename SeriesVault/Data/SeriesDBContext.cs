using Microsoft.EntityFrameworkCore;

namespace SeriesVault.Data;

public class SeriesDbContext(DbContextOptions options): DbContext(options)
{
    public DbSet<Series> Series => Set<Series>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.Entity<Series>().HasData(
            new Series{ id = 1, Title = "Lost", Platform = "Netflix", Producer = "J. J. Abrams, Jeffrey Lieber, Damon Lindelof", Publisher = "American Broadcasting Company"},
            new Series{ id = 2, Title = "Dexter", Platform = "Netflix", Producer = "Michael C. Hall", Publisher = "Showtime, CBS"},
            new Series{ id = 3, Title = "The Rookie", Platform = "Netflix", Producer = "Helen Pai", Publisher = "ABC in the United States"},
            new Series{ id = 4, Title = "The Boys", Platform = "Amazon Prime", Producer = "Eric Kripke", Publisher = "Dynamite Entertainment"});
    }
}