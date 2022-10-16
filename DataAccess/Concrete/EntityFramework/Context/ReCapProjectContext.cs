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
        public DbSet<Model> Models;
        public DbSet<CarState> CarStates;
        public DbSet<Car> Cars;
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

            modelBuilder.Entity<CarState>(f =>
            {
                f.ToTable("CarStates").HasKey(k => k.Id);
                f.Property(f => f.Id).HasColumnName("Id");
                f.Property(f => f.Name).HasColumnName("Name").IsRequired();
            });

            modelBuilder.Entity<Model>(m =>
            {
                m.ToTable("Models").HasKey(k => k.Id);
                m.Property(m => m.Id).HasColumnName("Id");
                m.Property(m => m.Name).HasColumnName("Name").IsRequired();
                m.Property(m => m.DailyPrice).HasColumnName("DailyPrice");
                m.Property(m => m.BrandId).HasColumnName("BrandId");
                m.Property(m => m.CarTypeId).HasColumnName("CarTypeId");
                m.Property(m => m.ColorId).HasColumnName("ColorId");
                m.Property(m => m.FuelId).HasColumnName("FuelId");
                m.HasOne(m => m.brand);
                m.HasOne(m => m.fuel);
                m.HasOne(m => m.carType);
                m.HasOne(m => m.color);
            });

            modelBuilder.Entity<Car>(m =>
            {
                m.ToTable("Cars").HasKey(k => k.Id);
                m.Property(m => m.Id).HasColumnName("Id");
                m.Property(m => m.CarName).HasColumnName("CarName").IsRequired();
                m.Property(m => m.Plate).HasColumnName("Plate");
                m.Property(m => m.ModelYear).HasColumnName("ModelYear");
                m.Property(m => m.DailyPrice).HasColumnName("DailyPrice");
                m.Property(m => m.Description).HasColumnName("Description");
                m.Property(m => m.Kilometer).HasColumnName("Kilometer");
                m.Property(m => m.CarStateId).HasColumnName("CarStateId");
                m.Property(m => m.ModelId).HasColumnName("ModelId");
                m.HasOne(m => m.carState);
                m.HasOne(m => m.Model);
            });

            

        }



    }
}
