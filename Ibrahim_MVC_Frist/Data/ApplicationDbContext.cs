using Ibrahim_MVC_Frist.Models;
using Microsoft.EntityFrameworkCore;

namespace Ibrahim_MVC_Frist.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public  virtual DbSet<Category> Categories { get; set; }
       public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Employee> employeesm { get; set; }
        public virtual DbSet<UserRole> UserRoles { get; set; }
        public  virtual DbSet<Permission> Permissions { get; set; }

    }
}
