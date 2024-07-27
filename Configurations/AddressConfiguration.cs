using ExaminationSystem.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ExaminationSystem.Configurations
{
    public class AddressConfiguration : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.Property(a => a.Street)
            .IsRequired()
            .HasMaxLength(100);

            builder.Property(a => a.City)
            .IsRequired()
            .HasMaxLength(50);

            builder.Property(a => a.Country)
            .IsRequired()
            .HasMaxLength(50);
        }
    }
}
