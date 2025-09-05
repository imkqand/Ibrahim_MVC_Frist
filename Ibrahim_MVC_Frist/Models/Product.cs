using System.ComponentModel.DataAnnotations;

namespace Ibrahim_MVC_Frist.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }               // رقم المنتج
        public string Name { get; set; }          // اسم المنتج
        public string Description { get; set; }   // وصف المنتج
        public decimal Price { get; set; }        // السعر
        public int Quantity { get; set; }         // الكمية المتوفرة
        public int CategoryId { get; set; }      // الفئة أو التصنيف
        public Category? Category { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.UtcNow; // تاريخ الإضافة
        public bool IsAvailable { get; set; }

        public bool IsDelete { get; set; } = false;

    }
}
