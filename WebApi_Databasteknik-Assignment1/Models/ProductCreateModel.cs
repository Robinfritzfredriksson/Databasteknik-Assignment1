namespace WebApi_Databasteknik_Assignment1.Models
{
    public class ProductCreateModel
    {

        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
    }
}
