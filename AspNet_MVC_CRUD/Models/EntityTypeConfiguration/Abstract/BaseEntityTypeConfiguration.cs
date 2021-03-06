using AspNet_MVC_CRUD.Models.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace AspNet_MVC_CRUD.Models.EntityTypeConfiguration.Abstract
{
    // BaseEntity.cs sınıfının üyelerini configure ediyoruz.
    public abstract class BaseEntityTypeConfiguration<T> : EntityTypeConfiguration<T> where T : BaseEntity
    {
        public BaseEntityTypeConfiguration()
        {
            HasKey(x => x.Id);
            Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.CreateDate).HasColumnType("datetime2").HasColumnName("CreatedDate").IsRequired();
            Property(x => x.UpdateDate).HasColumnType("datetime2").HasColumnName("UpdateDate").IsOptional();
            Property(x => x.DeleteDate).HasColumnType("datetime2").HasColumnName("DeleteDate").IsOptional();
            Property(x => x.Status).HasColumnName("Status").IsRequired();
        }
    }
}