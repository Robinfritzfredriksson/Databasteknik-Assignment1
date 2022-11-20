using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wpf_Databastenknik_Assignment1.Models.Entities
{
    internal class CustomerCategoryEntity
    {
        public int Id { get; set; }
        public string CustomerName { get; set; } = null!;
        public ICollection<CustomerEntity> Customer { get; set; }
    }
}
