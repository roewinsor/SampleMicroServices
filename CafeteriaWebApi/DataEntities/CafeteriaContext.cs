using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CafeteriaWebApi.DataEntities;

namespace CafeteriaWebApi.DataEntities
{
    public class CafeteriaContext: DbContext
    {
        public CafeteriaContext(DbContextOptions<CafeteriaContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Booking>()
            .HasOne<BookingStatus>(s => s.BookingStatus)
            .WithOne(bs => bs.Booking)
            .HasForeignKey<BookingStatus>(bs => bs.BookingId);

            modelBuilder.Entity<BookingStatus>()
            .HasOne<Booking>(bs => bs.Booking)
            .WithOne(b => b.BookingStatus)
            .HasForeignKey<BookingStatus>(bs => bs.BookingId);

            modelBuilder.Entity<BookingStatus>()
                .Property(b => b.StatusDate)
                .HasDefaultValueSql("getdate()");

                
        }

        public DbSet<Booking> Booking { get; set; }
        public DbSet<BookingStatus> BookingStatus { get; set; }



    }
}
