using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi_Databasteknik_Assignment1.Contexts;
using WebApi_Databasteknik_Assignment1.Models;
using WebApi_Databasteknik_Assignment1.Models.Entities;


namespace WebApi_Databastenknik_Assignment1.Services
{
    public class CustomerService
    {
        private readonly DataContext _context;

        public CustomerService(DataContext context)
        {
            _context = context;
        }

        public async Task Create(CustomerCreateModel model)
        {

            var customerEntity = new CustomerEntity
            {
                Name = model.Name,
                Email = model.Email,
                PhoneNumber = model.PhoneNumber,

            };
            _context.Add(customerEntity);
            await _context.SaveChangesAsync();

        }

        public async Task<IEnumerable<CustomerModel>> GetAll()
        {
            var customers = new List<CustomerModel>();
            foreach (var customer in await _context.Customers.ToListAsync())
                customers.Add(new CustomerModel { Id = customer.Id, Name = customer.Name, Email = customer.Email, PhoneNumber = customer.PhoneNumber });

            return customers;
        }

        public async Task<CustomerModel> Get(int id)
        {
            var customerEntity = await _context.Customers.FindAsync(id);
            if (customerEntity != null)
                return new CustomerModel { Id = customerEntity.Id, Name = customerEntity.Name, Email = customerEntity.Email, PhoneNumber = customerEntity.PhoneNumber, };
            return null!;

        }

    }

}

