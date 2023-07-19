using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using YemekDünyasi.Models;

namespace YemekDünyasi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly YemekDünyasContext _dbContext;

        public ProductController(YemekDünyasContext dbContext)
        {
            _dbContext = dbContext;
        }
        [HttpGet]

        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {
            if (_dbContext.ProductTable == null)
            {
                return NotFound();
            }
            return await _dbContext.ProductTable.ToListAsync();

        }

        [HttpGet("{id}")]

        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            if (_dbContext.ProductTable == null)
            {
                return NotFound();
            }
            var product = await _dbContext.ProductTable.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            return product;

        }
        [HttpPost]
        public async Task<ActionResult<Product>> PostProduct(string name, decimal price, int restaurantId)
        {
            if (string.IsNullOrEmpty(name) || price <= 0 || restaurantId <= 0)
            {
                return BadRequest("Required fields are missing or invalid.");
            }

            Product product = new Product
            {
                Name = name,
                Price = price,
                RestaurantId = restaurantId
            };

            _dbContext.ProductTable.Add(product);
            await _dbContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetProduct), new { id = product.Id }, product);
        }
        private bool productExists(int id)
        {
            return _dbContext.ProductTable.Any(x => x.Id == id);
        }

        [HttpPut("{id}")] // UPDATE
        public async Task<IActionResult> PutProduct(int id, Product product)
        {
            if (id != product.Id)
            {
                return BadRequest();
            }

            var existingProduct = await _dbContext.ProductTable.FindAsync(id);
            if (existingProduct == null)
            {
                return BadRequest("Varolan ürün null");
            }

            existingProduct.Name=product.Name;
            existingProduct.Price=product.Price;
            

            try
            {
                _dbContext.ProductTable.Update(existingProduct);
                await _dbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!productExists(id))
                {
                    return NotFound("id yok");
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        [HttpDelete("{id}")]

        public async Task<IActionResult> DeleteProduct(int id)
        {
            if (_dbContext.ProductTable == null)
            {
                return NotFound();
            }
            var product = await _dbContext.ProductTable.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            _dbContext.Remove(product);

            await _dbContext.SaveChangesAsync();

            return Ok();
        }
    }
}

