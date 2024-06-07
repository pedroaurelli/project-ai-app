using Microsoft.EntityFrameworkCore;
using Models;

namespace Database;

public class DatabaseContext : DbContext
{
    public DatabaseContext()
    {
    }

    public DatabaseContext(
        DbContextOptions<DatabaseContext> options) 
        : base(options)
    {
    }

    public DbSet<Audio> Audios { get; set; }

    public DbSet<AudioTranscription> AudioTranscriptions { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            var connectionString =
                "Server=localhost;Port=5432;Database=postgres;User Id=postgres;Password=postgres;";

            optionsBuilder.UseNpgsql(connectionString);
        }

        optionsBuilder.UseSnakeCaseNamingConvention();
    }
}
