using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabaty.Core.Entity;

namespace Talabaty.Repository.Data.Configuration
{
    internal class ProductConfig : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            // Configuration logic for Product entity
            builder.HasOne(P => P.ProductBrand).WithMany()
                   .HasForeignKey(P => P.ProductBrandId)
                   .OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(P => P.ProductType).WithMany()
                   .HasForeignKey(P => P.ProductTypeId)
                   .OnDelete(DeleteBehavior.Cascade);
            builder.Property(P => P.Name).IsRequired().HasMaxLength(100);
            builder.Property(P => P.Description).IsRequired().HasMaxLength(500);
            builder.Property(P => P.ImageUrl).IsRequired();
        }
    }
}
