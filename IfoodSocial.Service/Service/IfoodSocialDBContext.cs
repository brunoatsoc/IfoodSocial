using IfoodSocial.Core;
using Microsoft.EntityFrameworkCore;

namespace IfoodSocial.Service;

public class IfoodSocialDBContext : DbContext
{
    public DbSet<Bairro> Bairros { get; set; }
    public DbSet<Cidade> Cidades { get; set; }
    public DbSet<Localidade> Localidades { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Bairro>().HasKey(x => x.Cod_Bairro);
        modelBuilder.Entity<Cidade>().HasKey(x => x.Cod_Cidade);
        modelBuilder.Entity<Localidade>().HasKey(x => x.Cod_Localidade);

        modelBuilder.Entity<Cidade>().HasMany(x => x.Bairros).WithOne(x => x.Cidade).OnDelete(DeleteBehavior.Cascade);
        modelBuilder.Entity<Bairro>().HasMany(x => x.Localidades).WithOne(x => x.Bairro);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
   {
       optionsBuilder.UseSqlite("Data Source=C:/Users/brunoatsoc/Desktop/IfoodSocial/IfoodSocial.API/IfoodSocialAPI.db");
   }
}