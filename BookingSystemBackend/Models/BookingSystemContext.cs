using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookingSystemBackend.Models
{
    public class BookingSystemContext : DbContext
    {
        public BookingSystemContext(DbContextOptions<BookingSystemContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Booking>()
                .HasKey(b => new { b.BookingDate, b.SeatId });
            modelBuilder.Entity<Connection>()
                .HasKey(c => new { c.StartStationId, c.EndStationId, c.TrainId });
            modelBuilder.Entity<Connection>()
                .HasOne(c => c.StartStation)
                .WithMany()
                .HasForeignKey(c => c.StartStationId)
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Connection>()
                .HasOne(c => c.EndStation)
                .WithMany()
                .HasForeignKey(c => c.EndStationId)
                .OnDelete(DeleteBehavior.NoAction); ;
            modelBuilder.Entity<Connection>()
                .HasOne(c => c.Train)
                .WithMany(t => t.Connections)
                .HasForeignKey(c => c.TrainId)
                .OnDelete(DeleteBehavior.NoAction);
        }

        public DbSet<Person> People { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Station> Stations { get; set; }
        public DbSet<Connection> Connections { get; set; }
        public DbSet<Train> Trains { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Seat> Seats { get; set; }
    }
}
