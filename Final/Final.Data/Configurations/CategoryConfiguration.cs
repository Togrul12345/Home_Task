using Final.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final.Data.Configurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasMany(a => a.Products).WithOne(a => a.Category);
            builder.Property(a => a.Description).HasMaxLength(100);
            builder.Property(a => a.Name).HasMaxLength(40);
        }
    }
}
