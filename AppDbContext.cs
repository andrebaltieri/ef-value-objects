using ConsoleApp01.Entities;
using ConsoleApp01.Models.Mappings;
using Microsoft.EntityFrameworkCore;

namespace ConsoleApp01;

public class AppDbContext : DbContext
{
    public DbSet<User> Users { get; set; } = null!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseSqlServer(
        "CONN_STR");

    protected override void OnModelCreating(ModelBuilder modelBuilder) =>
        modelBuilder.ApplyConfiguration(new UserMap());
}