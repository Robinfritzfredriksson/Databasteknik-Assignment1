using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi_Databasteknik_Assignment1.Contexts;
using WebApi_Databasteknik_Assignment1.Models.Entities;
using WebApi_Databasteknik_Assignment1.Models;
using Microsoft.EntityFrameworkCore;

namespace WebApi_Databasteknik_Assignment1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly DataContext _context;

        public ProductController(DataContext context)
        {
            _context = context;
        }
        [HttpPost]
        public async Task<IActionResult> Create(ProductCreateModel model)
        {
            if (ModelState.IsValid)
            {
                var productEntity = new ProductEntity
                {
                    Id = Guid.NewGuid(),
                    Name = model.Name,
                    Description = model.Description,
                    Price = model.Price,
                    CategoryId = model.CategoryId,


                };
                _context.Add(productEntity);
                await _context.SaveChangesAsync();
                return new OkResult();
            }
            return BadRequest();

        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var products = new List<ProductModel>();
            foreach (var product in await _context.Products.Include(x => x.Category).ToListAsync())
                products.Add(new ProductModel 
                {  
                    Id = product.Id,
                    Name = product.Name,
                    Description = product.Description,
                    Price = product.Price,
                    CategoryId = product.CategoryId,
                    CategoryName = product.Category.CategoryName,


                });

            return new OkObjectResult(products);
        }


    }
}
