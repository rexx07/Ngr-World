using Microsoft.EntityFrameworkCore;
using NgrWrld.Core.Domain;

namespace NgrWrld.Core.Data;

public class NgrWrldDbContext: DbContext
{
    public NgrWrldDbContext(): base()
    {
    }

    public NgrWrldDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<City> Cities => Set<City>(); //{ get; set; }
    public DbSet<Country> Countries => Set<Country>(); //{ get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.Entity<City>().ToTable("Cities");
        modelBuilder.Entity<City>().HasKey(x => x.Id);
        modelBuilder.Entity<City>().Property(x => x.Id).IsRequired();
        modelBuilder.Entity<City>().Property(x => x.Lat).HasColumnType("decimal(7,4)");
        modelBuilder.Entity<City>().Property(x => x.Lon).HasColumnType("decimal(7,4)");
        
        modelBuilder.Entity<Country>().ToTable("Countries");
        modelBuilder.Entity<Country>().HasKey(x => x.Id);
        modelBuilder.Entity<Country>().Property(x => x.Id).IsRequired();
        modelBuilder.Entity<City>()
            .HasOne(x => x.Country)
            .WithMany(y => y.Cities)
            .HasForeignKey(x => x.CountryId);
    }
}