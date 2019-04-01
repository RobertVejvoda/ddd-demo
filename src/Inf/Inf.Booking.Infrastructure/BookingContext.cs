using Inf.Booking.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            base.OnModelCreating(modelBuilder);
        }  
}
