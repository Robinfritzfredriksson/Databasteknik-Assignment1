namespace WebApi_Databasteknik_Assignment1.Models
{
    public class CustomerCreateModel
    {
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string? PhoneNumber { get; set; }
    }
}
