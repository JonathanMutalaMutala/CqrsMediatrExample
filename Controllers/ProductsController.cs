using CqrsMediatrExample.Commands;
using CqrsMediatrExample.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CqrsMediatrExample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ISender _sender;

        public ProductsController(ISender sender) => _sender = sender;

        [HttpGet]
        public async Task<ActionResult> GetProducts()
        {
            var products = await _sender.Send(new GetProductsQuery()); // Faire appel Au Query pour le MediatR
            return Ok(products);
        }
        [HttpGet("{id:int}",Name = "GetProductById")]
        public async Task<ActionResult> GetProductById(int id)
        {
            var product = await _sender.Send(new GetProductByIdQuery(id));
            return Ok(product);
        } 


        [HttpPost]
        public async Task<IActionResult> AddProduct([FromBody] Product product)
        {
            var addProductCommand = new AddProductCommand { Product = product };
           var productToReturn = await _sender.Send(addProductCommand);

            return  CreatedAtRoute("GetProductById",new { id = productToReturn.Id },productToReturn);

        }
    }
}
