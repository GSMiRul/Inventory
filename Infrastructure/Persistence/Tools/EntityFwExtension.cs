using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Tools
{
    public static class EntityFwExtension
    {
        public static ModelBuilder AddPirmaryKeys(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Brand>()
                .HasKey(b => b.Id)
                .HasName("PK_Brand");

            return modelBuilder;
        }

        public static ModelBuilder AddIndex(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Brand>()
                .HasIndex(b => b.BarandName)
                .IsUnique()
                .HasDatabaseName("IX_Brand");

            modelBuilder.Entity<Brand>()
                .Property(b => b.BarandName)
                .HasMaxLength(150)
                .IsRequired();

            modelBuilder.Entity<Brand>()
               .Property(b => b.ShortName)
               .HasMaxLength(100);

            return modelBuilder;
        }

        public static ModelBuilder AddSeedData(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Brand>().HasData(
                new Brand { BarandName = "Sony", ShortName = "SNY" },
                new Brand { BarandName = "Daewo", ShortName = "DW" },
                new Brand { BarandName = "LG Electronics", ShortName = "LG" }
            );

            return modelBuilder;
        }
    }
}
