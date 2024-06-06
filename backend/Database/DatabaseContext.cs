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

    public DbSet<FileStorage> FilesStorage { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSnakeCaseNamingConvention();
    }
}
