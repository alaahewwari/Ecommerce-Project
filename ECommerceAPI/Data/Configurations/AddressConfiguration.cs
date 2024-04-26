using ECommerceAPI.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerceAPI.Data.Configurations
{
    public class AddressConfiguration : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.Property(a => a.Country)
                .HasMaxLength(255);

            builder.Property(a => a.City)
                .HasMaxLength(255);

            builder.Property(a => a.Street)
                .HasMaxLength(255);

            builder.Property(a => a.ZipCode)
                .HasMaxLength(12);

        }
    }
}
