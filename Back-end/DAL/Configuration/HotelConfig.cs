using HotelManagementApplication.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace HotelManagementApplication.DAL.Configuration
{
    public class HotelConfig : IEntityTypeConfiguration<Hotel>
    {
        public void Configure(EntityTypeBuilder<Hotel> builder) 
        {
            builder.ToTable("Hotels");
            builder.HasKey(x => x.HotelId);
            builder.Property(x => x.HotelId).UseIdentityColumn();

            builder.Property(e => e.HotelId).IsRequired();
            builder.Property(e => e.Name).IsRequired().HasMaxLength(50);
            builder.Property(e => e.Address).IsRequired().HasMaxLength(200);
            builder.Property(e => e.Rating).IsRequired();

            builder.HasData(new List<Hotel>()
            {
                    new Hotel {
                        HotelId = 1,
                        Name = "Grand Plaza",
                        Address = "123 Main St",
                        Rating = 4.5m
                    },
                    new Hotel {
                        HotelId = 2,
                        Name = "Luxury Heaven",
                        Address = "456 Oak St",
                        Rating = 5.0m
                        },
                    new Hotel {
                        HotelId = 3,
                        Name = "Seaside Retreat",
                        Address = "789 Beach Blvd",
                        Rating = 4.0m 
                    }
            });
        }
    }
}
