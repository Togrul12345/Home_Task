using ECommerce.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Data.Contexts
{
    public class ECommerceDbContext:DbContext
    {
        public ECommerceDbContext(DbContextOptions opt):base(opt)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Order>().HasMany(a => a.OrderItems).WithOne(a => a.Order).HasForeignKey(a => a.OrderId).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<OrderItem>().HasOne(a => a.Product).WithMany(a => a.OrderItems).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Product>().HasMany(a => a.OrderItems).WithOne(a => a.Product).OnDelete(DeleteBehavior.Restrict);

        }
    }
}
