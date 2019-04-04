using Inf.Booking.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inf.Booking.Infrastructure.Configuration
{
    public class CourtEntityConfiguration : IEntityTypeConfiguration<CourtEntity>
    {
        public void Configure(EntityTypeBuilder<CourtEntity> builder)
        {
            builder.ToTable("Court", BookingContext.DEFAULT_SCHEMA);
            builder.HasKey(p => p.Id);
            builder.Property(p => p.CourtType).IsRequired();
        }
    }
}
