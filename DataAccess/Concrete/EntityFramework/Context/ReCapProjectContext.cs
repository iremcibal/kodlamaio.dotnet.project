using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework.Context
{
    public class ReCapProjectContext : DbContext 
    {
        public DbSet<Brand> Brands;
        public DbSet<CarType> CarType;
        public DbSet<Color> Colors;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Windows Auth için "...;Integrated Security=True"
            // Sql Auth için:
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ReCapProject;Integrated Security=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Brand>(b =>
            {
                b.ToTable("Brands").HasKey(k => k.Id);
                b.Property(b => b.Id).HasColumnName("Id");
                b.Property(b => b.Name).HasColumnName("Name").IsRequired();
            });

            modelBuilder.Entity<CarType>(ct =>
            {
                ct.ToTable("CarType").HasKey(k => k.Id);
                ct.Property(ct => ct.Id).HasColumnName("Id");
                ct.Property(ct => ct.Name).HasColumnName("Name").IsRequired();
            });

            modelBuilder.Entity<Color>(c =>
            {
                c.ToTable("Colors").HasKey(k => k.Id);
                c.Property(c => c.Id).HasColumnName("Id");
                c.Property(c => c.Name).HasColumnName("Name").IsRequired();
            });

            modelBuilder.Entity<Fuel>(f =>
            {
                f.ToTable("Fuels").HasKey(k=>k.Id); 
                f.Property(f => f.Id).HasColumnName("Id");
                f.Property(f => f.Name).HasColumnName("Name").IsRequired();
            });

        }



    }
}
