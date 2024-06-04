using ECommerceAPI.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace ECommerceAPI.Data.Configurations
{
    public class PaymentMethodConfiguration : IEntityTypeConfiguration<PaymentMethod>
    {
        public void Configure(EntityTypeBuilder<PaymentMethod> builder)
        { 
            builder
                .Property(p => p.TotalAmount)
                .HasPrecision(18, 2);
            builder
                .Property(p=>p.Provider)
                .HasMaxLength(255);
            builder
                .Property(p => p.AccountNumber)
                .HasMaxLength(255);
            builder
                .Property(p=>p.SecurityCode)
                .HasMaxLength(255);
        }
    }
}
