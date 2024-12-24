using Department.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Department.Data.Configurations
{
    public class DepartmentConfiguration : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            builder.Property(a => a.FirstName).HasMaxLength(20);
            builder.Property(a => a.LastName).HasMaxLength(20);
            builder.Property(a => a.PhoneNumber).HasMaxLength(25);
        }
    }
}
