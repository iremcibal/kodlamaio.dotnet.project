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
        public DbSet<User> Users;
        public DbSet<Rental> Rentals;
        public DbSet<Customer> Customers;
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

            modelBuilder.Entity<Rental>(f =>
            {
                f.ToTable("Rentals").HasKey(k => k.Id);
                f.Property(f => f.Id).HasColumnName("Id");
                f.Property(f => f.CustomerId).HasColumnName("CustomerId").IsRequired();
                f.Property(f => f.CarId).HasColumnName("CarId"); 
                f.Property(f => f.RentDate).HasColumnName("RentDate");
                f.Property(f => f.ReturnDate).HasColumnName("ReturnDate");
                f.Property(f => f.BillNumber).HasColumnName("BillNumber");
                f.Property(f => f.RentTotal).HasColumnName("RentTotal");
                f.Property(f => f.PriceTotal).HasColumnName("PriceTotal");
                f.HasOne(f => f.Car);
                f.HasOne(f => f.Customer);
            });

            modelBuilder.Entity<User>(f =>
            {
                f.ToTable("Users").HasKey(k => k.Id);
                f.Property(f => f.Id).HasColumnName("Id");
                f.Property(f => f.FirstName).HasColumnName("FirstName");
                f.Property(f => f.LastName).HasColumnName("LastName");
                f.Property(f => f.Email).HasColumnName("Email");
                f.Property(f => f.PasswordHash).HasColumnName("PasswordHash");
                f.Property(f => f.PasswordSalt).HasColumnName("PasswordSalt");
                f.Property(f => f.Status).HasColumnName("Status");

            });

            modelBuilder.Entity<Customer>(f =>
            {
                f.ToTable("Customers").HasKey(k => k.Id);
                f.Property(f => f.Id).HasColumnName("Id");
                f.Property(f => f.CompanyName).HasColumnName("CompanyName");
                f.Property(f=>f.UserId).HasColumnName("UserId");
                f.HasOne(f => f.User);

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
