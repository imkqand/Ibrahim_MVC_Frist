namespace Ibrahim_MVC_Frist.Dtos
{
    public class ProductDto
    {
        public int Id { get; set; }               // رقم المنتج
        public string Name { get; set; }          // اسم المنتج
        public string Description { get; set; }   // وصف المنتج
        public decimal Price { get; set; }        // السعر
        public int Quantity { get; set; }         // الكمية المتوفرة
        public int CategoryId { get; set; }      // الفئة أو التصنيف
    }
}
