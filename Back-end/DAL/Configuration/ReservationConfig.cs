using HotelManagementApplication.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HotelManagementApplication.DAL.Configuration
{
    public class ReservationConfig : IEntityTypeConfiguration<Reservation>
    {
        public void Configure(EntityTypeBuilder<Reservation> builder)
        {
            builder.ToTable("Reservations");
            builder.HasKey(x => x.ReservationId);
            builder.Property(x => x.ReservationId).UseIdentityColumn();

            builder.Property(e => e.ReservationId).IsRequired();
            builder.Property(e => e.RoomId).IsRequired();
            builder.Property(e => e.CustomerId).IsRequired();
            builder.Property(e => e.GuestName).IsRequired().HasMaxLength(50);

            builder.HasData(new List<Reservation>
            {
            new Reservation { ReservationId = 1,
                RoomId = 1,
                CustomerId = 1,
                GuestName = "Satyam Verma",
                CheckInDate = DateTime.Now.AddDays(2),
                CheckOutDate = DateTime.Now.AddDays(5)
            },
            new Reservation {ReservationId = 2,
                RoomId = 2,
                CustomerId= 2,
                GuestName = "Aryan Sharma",
                CheckInDate = DateTime.Now.AddDays(7),
                CheckOutDate = DateTime.Now.AddDays(10)
            },
            new Reservation {
                ReservationId = 3,
                RoomId = 3,
                CustomerId = 3,
                GuestName = "Sneha Gupta",
                CheckInDate = DateTime.Now.AddDays(5),
                CheckOutDate = DateTime.Now.AddDays(8)
            }
            });

            builder.HasOne(n => n.Room)
                   .WithMany(n => n.Reservations)
                   .HasForeignKey(n => n.RoomId)
                   .HasConstraintName("Fk_Reservation_Rooms");

            builder.HasOne(n => n.Customer)
                .WithMany(n => n.Reservations)
                .HasForeignKey(n => n.CustomerId)
                .HasConstraintName("Fk_Customer_Reservations");

        }
    }
}
