using AspNet_MVC_CRUD.Models.Entities.Concrete;
using AspNet_MVC_CRUD.Models.EntityTypeConfiguration.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AspNet_MVC_CRUD.Models.EntityTypeConfiguration.Concrete
{
    public class ProductEntityTypeConfiguration : BaseEntityTypeConfiguration<Product>
    {
        public ProductEntityTypeConfiguration()
        {
            ToTable("dbo.Products");

            Property(x => x.Name)
                .HasColumnType("nvarchar")
                .HasColumnName("Name")
                .HasMaxLength(60)
                .IsRequired();

            Property(x => x.Description)
                .HasColumnType("nvarchar")
                .HasColumnName("Description")
                .HasMaxLength(300)
                .IsRequired();

            Property(x => x.UnitPrice)
                .HasColumnType("decimal")
                .HasColumnName("UnitPrice")
                .IsRequired();

            Property(x => x.UnitInStock)
               .HasColumnType("smallint")
               .HasColumnName("UnitInStock")
               .IsRequired();

            HasRequired(x => x.Category)
                .WithMany(x => x.Products) // Bir kategorinin bir çok product' ı var
                .HasForeignKey(x => x.CategoryId)
                .WillCascadeOnDelete(false); // Bir varlık silinirken onun bağlantılı olduğu varlıkları silme dedik. Silerken aralarındaki bağlantı gider.
        }
    }
}