using Microsoft.EntityFrameworkCore;
using BocaDeDrogasAPI.Models;

namespace BocaDeDrogasAPI.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options){}

    public DbSet<Consumidor> Consumidores => Set<Consumidor>();

    public DbSet<Droga> Drogas => Set<Droga>();

    public DbSet<Venda> Vendas => Set<Venda>();
}
