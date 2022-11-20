using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wpf_Databastenknik_Assignment1.Models.Entities
{
    public class OrderRowEntity
    {
        public int Id { get; set; }
        public Guid OrderId { get; set; }
        public Guid ProductId { get; set; }
    }
}
