using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi_Databasteknik_Assignment1.Contexts;
using WebApi_Databasteknik_Assignment1.Models.Entities;
using WebApi_Databasteknik_Assignment1.Models;
using Microsoft.EntityFrameworkCore;
using WebApi_Databastenknik_Assignment1.Services;

namespace WebApi_Databasteknik_Assignment1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly CustomerService _customerService;

        public CustomersController(CustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CustomerCreateModel model)
        {
            if (ModelState.IsValid)
            {
               await _customerService.Create(model);
                return new OkResult();
            }
            return BadRequest();
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return new OkObjectResult(await _customerService.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
           
            var result = await _customerService.Get(id);
            if(result != null)
                return new OkObjectResult(result);

            return new NotFoundResult();

        }

    }
}


    


