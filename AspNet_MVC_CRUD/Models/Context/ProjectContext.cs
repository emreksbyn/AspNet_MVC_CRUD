using AspNet_MVC_CRUD.Models.Entities.Concrete;
using AspNet_MVC_CRUD.Models.EntityTypeConfiguration.Concrete;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace AspNet_MVC_CRUD.Models.Context
{
    public class ProjectContext : DbContext
    {
        public ProjectContext()
        {
            Database.Connection.ConnectionString = @"Server=.;Database=AspNetMvcDb;Integrated Security=True";
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Configurasyonları çağırıyoruz.
            modelBuilder.Configurations.Add(new CategoryEntityTypeConfiguration());
            modelBuilder.Configurations.Add(new ProductEntityTypeConfiguration());

            // Tablo isimleri Türkçe olursa çoğullaştırmayı kapatmak için :
            //modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            // CategoryEntityTypeConfiguration ve ProductEntityTypeConfiguration sınıflarında yaptığımız configurasyonları burada da yapabilirdik. Fakar bu clean code mantığına uymaz .
            //modelBuilder.Entity<Category>().Property(x => x.CreateDate).HasColumnType("datetime2");

            base.OnModelCreating(modelBuilder);
        }
    }
}