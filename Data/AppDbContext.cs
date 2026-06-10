using Microsoft.EntityFrameworkCore;
using BocaDeDrogasAPI.Models;

namespace BocaDeDrogasAPI.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options){}

    public DbSet<Consumidor> CUSTOMERS { get; set;}

    public DbSet<Droga> DRUGS { get; set;}

    public DbSet<Venda> SELLS => Set<Venda>();
}
