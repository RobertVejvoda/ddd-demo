using Inf.Booking.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inf.Booking.Infrastructure.Configuration
{
    public class BookingEntityConfiguration : IEntityTypeConfiguration<BookingEntity>
    {
        public void Configure(EntityTypeBuilder<BookingEntity> builder)
        {
            builder.ToTable("Booking", BookingContext.DEFAULT_SCHEMA);
            builder.HasKey(p => p.Id);
            builder.Property(p => p.CourtId).IsRequired();
            builder.Property(p => p.BookedFrom).IsRequired();
            builder.Property(p => p.BookedTo).IsRequired();
            builder.Property(p => p.Status).IsRequired();
            builder.Property(p => p.PhoneNo).IsRequired();
            builder.Property(p => p.CreatedBy).IsRequired();
            builder.Property(p => p.CreatedDate).IsRequired();
            builder.Property(p => p.ModifiedBy).IsRequired(false);
            builder.Property(p => p.ModifiedDate).IsRequired(false);

            builder.HasOne(o => o.Court)
                .WithMany()
                .HasForeignKey("CourtId");
        }
    }
}
