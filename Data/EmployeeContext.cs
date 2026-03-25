using Microsoft.EntityFrameworkCore;

namespace EF_core.Model
{
    public class EmployeeContext : DbContext
    {
        public EmployeeContext(DbContextOptions<EmployeeContext> options) : base(options)
        {

        }
        public DbSet<Employee> Employees { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Fluent API configuration for Hotel entity(alternative to data annotations)
            modelBuilder.Entity<Employee>()
                .Property(e => e.Email)
                .IsRequired()
                .HasMaxLength(100);

            // Seed Data
            modelBuilder.Entity<Employee>().HasData(
                new Employee
                {
                    EmployeeId = 1,
                    FirstName = "Gurkirat",
                    LastName = "Singh",
                    Email = "gsingh@ap.com",
                    PhoneNo = "+91 946738923",
                    Address = "1234 dave street"
                },
                new Employee
                {
                    EmployeeId = 2,
                    FirstName = "Ben",
                    LastName = "Stocks",
                    Email = "ben12@ic.com",
                    PhoneNo = "+91 9456305478",
                    Address = "235 GBP ATS street"
                });
                
        }
    }
}
