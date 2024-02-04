using Microsoft.EntityFrameworkCore;
using Tips.Domain;

namespace Tips.Database;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> dbContextOptions) : base(dbContextOptions)
    {
    }

    public DbSet<ToDo> ToDos { get; set; }
}