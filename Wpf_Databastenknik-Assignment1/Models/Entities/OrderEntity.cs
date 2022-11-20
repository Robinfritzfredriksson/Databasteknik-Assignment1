using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wpf_Databastenknik_Assignment1.Models.Entities
{
    public class OrderEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public string Address { get; set; } = null!;
        public DateTime OrderDate { get; set; }
        public decimal Price { get; set; }

    }
}
