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
        public DbSet<Brand> brands;

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

        }

    }
}
