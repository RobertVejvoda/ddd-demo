using Inf.Booking.Infrastructure.Configuration;
using Inf.Core.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Inf.Booking.Infrastructure
{
    public class BookingContext : DbContext, IUnitOfWork
    {
        public const string DEFAULT_SCHEMA = "booking";

        public BookingContext(DbContextOptions<BookingContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new BookingEntityConfiguration());
            modelBuilder.ApplyConfiguration(new CourtEntityConfiguration());
        }
    }

    public class BookingContextDesignFactory : IDesignTimeDbContextFactory<BookingContext>
    {
        public BookingContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<BookingContext>()
                .UseSqlServer("Data Source=.\\SQLExpress;Initial Catalog=InfDemo;MultipleActiveResultSets=True;Integrated Security=true;");

            return new BookingContext(optionsBuilder.Options);
        }
    }
}
