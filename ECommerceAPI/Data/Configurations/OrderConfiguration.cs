using ECommerceAPI.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerceAPI.Data.Configurations
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder 
                .Property(o=> o.totalPrice)
                .HasPrecision(18, 2);

            builder
              .Property(o => o.Country)
              .HasMaxLength(255);

            builder
                .Property(o=>o.City)
                .HasMaxLength(255);

          
            builder
                .Property(o=>o.Street)
                .HasMaxLength(255);

            builder 
                .Property(o=>o.ZipCode)
                .HasMaxLength(12);
        }
    }

}
