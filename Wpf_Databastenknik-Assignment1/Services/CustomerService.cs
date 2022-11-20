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
    public class CustomerService
    {
        private readonly DataContext _context;

        public CustomerService(DataContext context)
        {
            _context = context;
        }


        public async Task<IEnumerable<CustomerEntity>> GetAll()
        {
            return await _context.Customers.ToListAsync();
        }

        public async Task<CustomerEntity> Get(int id)
        {
            return await _context.Customers.FindAsync(id);
        }

    }

}
