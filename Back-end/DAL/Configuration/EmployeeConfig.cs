using HotelManagementApplication.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HotelManagementApplication.DAL.Configuration
{
    public class EmployeeConfig : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder) 
        {
            builder.ToTable("Employees");
            builder.HasKey(e => e.EmployeeId);
            builder.Property(e => e.EmployeeId).UseIdentityColumn();

            builder.Property(e => e.EmployeeId).IsRequired();
            builder.Property(e => e.HotelId).IsRequired();
            builder.Property(e => e.FirstName).IsRequired().HasMaxLength(50);
            builder.Property(e => e.LastName).IsRequired().HasMaxLength(50);
            builder.Property(e => e.Position).IsRequired();
                                            

            builder.HasData(new List<Employee>()
            {

            new Employee {
                EmployeeId = 1,
                HotelId = 1,
                FirstName = "Alice",
                LastName = "Johnson",
                Position = "Manager" },
            new Employee {
                EmployeeId = 2,
                HotelId = 1,
                FirstName = "Bob",
                LastName = "Smith",
                Position = "Front Desk Staff" },
            new Employee {
                EmployeeId = 3,
                HotelId = 2,
                FirstName = "Charlie",
                LastName = "Brown",
                Position = "Housekeeping"}
            });

            builder.HasOne(n => n.Hotel)
                   .WithMany(n => n.Employees)
                   .HasForeignKey(n => n.HotelId)
                   .HasConstraintName("Fk_Hotel_Employees");
        }
    }
}
