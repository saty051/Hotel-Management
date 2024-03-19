using HotelManagementApplication.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HotelManagementApplication.DAL.Configuration
{
    public class CustomerConfig : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable("Customers");
            builder.HasKey(x => x.CustomerId);
            builder.Property(x => x.CustomerId).UseIdentityColumn();

            builder.Property(e => e.CustomerId).IsRequired();
            builder.Property(e => e.FirstName).IsRequired().HasMaxLength(25);
            builder.Property(e => e.Email).IsRequired(false).HasMaxLength(100);
            builder.Property(e => e.Phone).IsRequired().HasMaxLength(255);

            builder.HasData(new List<Customer>()
            {
                new Customer {
                    CustomerId = 1,
                    FirstName = "Emily",
                    LastName = "Davis",
                    Email = "emily@email.com",
                    Phone = "123-456-7890" },
                new Customer {
                    CustomerId = 2,
                    FirstName = "James",
                    LastName = "Miller",
                    Email = "james@email.com",
                    Phone = "987-654-3210" },
                new Customer {
                    CustomerId = 3,
                    FirstName = "Sophia",
                    LastName = "Anderson",
                    Email = "sophia@email.com",
                    Phone = "456-789-0123" 
                }
            });

        }
    }
}
