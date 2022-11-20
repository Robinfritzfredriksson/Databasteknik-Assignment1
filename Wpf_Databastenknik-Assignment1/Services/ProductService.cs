using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wpf_Databastenknik_Assignment1.Contexts;
using Wpf_Databastenknik_Assignment1.Models;
using Wpf_Databastenknik_Assignment1.Models.Entities;

namespace Wpf_Databastenknik_Assignment1.Services
{
    public class ProductService
    {
        private readonly DataContext _context;

        public ProductService(DataContext context)
        {
            _context = context;
        }
        
        public async Task<IEnumerable<ProductEntity>> GetAll()
        {
            var products = await _context.Products.ToListAsync();
            return products;
        }

        public async Task<ProductEntity> Get(Guid id)
        {
            return await _context.Products.FindAsync(id);
        }


    }
}
