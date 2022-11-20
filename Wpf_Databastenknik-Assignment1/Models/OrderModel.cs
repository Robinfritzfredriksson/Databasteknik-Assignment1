using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wpf_Databastenknik_Assignment1.Models.Entities;

namespace Wpf_Databastenknik_Assignment1.Models
{
    public class OrderModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public string Address { get; set; } = null!;
        public DateTime OrderDate { get; set; }
        public decimal Price { get; set; }
        public List<ProductEntity> Products { get; set; }
    }
}
