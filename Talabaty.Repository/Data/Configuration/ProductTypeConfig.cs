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
    internal class ProductTypeConfig : IEntityTypeConfiguration<Talabaty.Core.Entity.ProductType>
    {
        public void Configure(EntityTypeBuilder<ProductType> builder)
        {
            builder.Property(pt => pt.Name)
                   .IsRequired()
                   .HasMaxLength(100);
        }
    }
}
