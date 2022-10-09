using Microsoft.EntityFrameworkCore;

namespace LabManager.Models;

public class SystemContext : DbContext
{
    public DbSet<Computer> Computers { get; set; }
    public DbSet<Lab> Labs { get; set; }

    public SystemContext() { }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseMySQL(
            "server=localhost;database=labmanager;user=root;password=123456;"
        );
    }
}