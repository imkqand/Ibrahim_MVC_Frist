using Ibrahim_MVC_Frist.Models;
using Microsoft.EntityFrameworkCore;

namespace Ibrahim_MVC_Frist.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }
       public DbSet<Product> Products { get; set; }
        public DbSet<Employee> employeesm { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }

    }
}
