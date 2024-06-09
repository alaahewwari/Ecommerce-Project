using ECommerceAPI.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace ECommerceAPI.Data.Configurations
{
    public class CurrencyConfiguration : IEntityTypeConfiguration<Currency>
    {
        public void Configure(EntityTypeBuilder<Currency> builder)
        {
            builder
                   .Property(c => c.Name)
                   .HasMaxLength(50);
            builder
                .Property(c => c.Code)
                .HasMaxLength(3);
            builder
                .Property(c => c.Symbol)
                .HasMaxLength(10);
            builder
                .Property(c => c.ExchangeRate)
                .HasPrecision(18, 2);
        }
    }
}
