using ECommerceAPI.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace ECommerceAPI.Data.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder
                .HasMany(p => p.CartItems)
                .WithOne(ci => ci.Product)
                .HasForeignKey(ci => ci.ProductId)
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .HasOne(p => p.CreatedUser)
                .WithMany(u => u.CreatedProducts)
                .HasForeignKey(p => p.CreatedUserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(p => p.UpdatedUser)
                .WithMany(u => u.UpdatedProducts)
                .HasForeignKey(p => p.UpdatedUserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                 .Property(o => o.Price)
                 .HasPrecision(18, 2);

            builder
                .Property(sp=>sp.SalePrice)
                .HasPrecision(18,2);

            builder
                .Property(p => p.Name)
                .HasMaxLength(255);

        }
    }
}
