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
    public class OrderService
    {
        private readonly DataContext _context;

        public OrderService(DataContext context)
        {
            _context = context;
        }

        public async Task Create(OrderModel orderModel)
        {
            var orderEntity = new OrderEntity
            {
                Id = Guid.NewGuid(),
                OrderDate= DateTime.Now,    
                Address= orderModel.Address,
                Name= orderModel.Name,
                Price= orderModel.Price
            };

            _context.Orders.Add(orderEntity);
            await _context.SaveChangesAsync();

            foreach (var product in orderModel.Products)
            {
                _context.OrdersRows.Add(new OrderRowEntity
                {
                    OrderId = orderEntity.Id,
                    ProductId = product.Id
                });
                await _context.SaveChangesAsync();
            }

            
        }

        public async Task<IEnumerable<OrderEntity>> GetAll()
        {
            return await _context.Orders.ToListAsync();
        }

        public async Task<OrderEntity> Get(Guid id)
        {
            return await _context.Orders.FindAsync(id); 
        }
    }
}
