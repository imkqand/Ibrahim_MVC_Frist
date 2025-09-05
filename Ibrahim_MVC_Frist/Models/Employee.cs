using System.ComponentModel.DataAnnotations;

namespace Ibrahim_MVC_Frist.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public int Phone{ get; set; }

        public string UserName { get; set; }
        public string Password { get; set; }

        public bool Islock { get; set; } = false;

        public bool IsDelete { get; set; } = false;

        public int? UserDeleted { get; set; }

        public DateTime DeleteDate { get; set; }

        public int? UserRoleId { get; set; }

        public virtual UserRole? UserRole { get; set; }




    }
}
