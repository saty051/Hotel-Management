using HotelManagementApplication.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HotelManagementApplication.DAL.Configuration
{
    public class RoomConfig: IEntityTypeConfiguration<Room>
    {
        public void Configure(EntityTypeBuilder<Room> builder)
        {
            builder.ToTable("Rooms");
            builder.HasKey(x => x.RoomId);
            builder.Property(x => x.RoomId).UseIdentityColumn();

            
            builder.Property(e => e.RoomId).IsRequired();
            builder.Property(e => e.HotelId).IsRequired();
            builder.Property(e => e.RoomNumber).IsRequired();


            builder.HasData(new List<Room>()
            {
                new Room {
                    RoomId = 1,
                    HotelId = 1,
                    RoomNumber = "101",
                    Capacity = 2,
                    Price = 150.00m },
                new Room {
                    RoomId = 2,
                    HotelId = 1,
                    RoomNumber = "102",
                    Capacity = 4,
                    Price = 200.00m },
                new Room {
                    RoomId = 3,
                    HotelId = 2,
                    RoomNumber = "201",
                    Capacity = 3,
                    Price = 180.00m 
                }
            });

            builder.HasOne(n => n.Hotel)
                .WithMany(n => n.Rooms)
                .HasForeignKey(n => n.HotelId)
                .HasConstraintName("Fk_Rooms_Hotels");


        }
    }
}
