using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using YemekDünyasi.Models;

namespace YemekDünyasi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantController : ControllerBase
    {
        private readonly YemekDünyasContext _dbContext;

        public RestaurantController(YemekDünyasContext dbContext)
        {
            _dbContext = dbContext;
        }
        [HttpGet]

        public async Task<ActionResult<IEnumerable<Restaurant>>> GetRestorants()
        {
            if (_dbContext.RestaurantTable == null)
            {
                return NotFound();
            }
            return await _dbContext.RestaurantTable.ToListAsync();

        }

        [HttpGet("{id}")]

        public async Task<ActionResult<Restaurant>> GetRestorant(int id)
        {
            if (_dbContext.RestaurantTable == null)
            {
                return NotFound();
            }
            var restoran = await _dbContext.RestaurantTable.FindAsync(id);
            if (restoran == null)
            {
                return NotFound();
            }
            return restoran;

        }

        [HttpPost]
        public async Task<ActionResult<Restaurant>> PostRest(string name, string Address, string TelNo, string CategoryId)
        {
            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(Address) || string.IsNullOrEmpty(TelNo) || string.IsNullOrEmpty(CategoryId))
            {
                return BadRequest("Required fields are missing.");
            }

            if (!int.TryParse(CategoryId, out int parsedCategoryId))
            {
                return BadRequest("Invalid CategoryId.");
            }


            Restaurant restaurant = new Restaurant
            {
                Name = name,
                Address = Address,
                CategoryId = parsedCategoryId,
                TelNo = TelNo,
                
               
            };

            _dbContext.RestaurantTable.Add(restaurant);
            await _dbContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetRestorant), new { id = restaurant.Id }, restaurant);
        }
        private bool RestoranExists(int id)
        {
            return _dbContext.UsersTable.Any(x => x.Id == id);
        }

        [HttpPut("{id}")] // UPDATE
        public async Task<IActionResult> PutRestoran(int id, Restaurant restaurant)
        {
            if (id != restaurant.Id)
            {
                return BadRequest();
            }

            var existingRestoran = await _dbContext.RestaurantTable.FindAsync(id);

            if (existingRestoran == null)
            {
                return NotFound();
            }
            existingRestoran.Name = restaurant.Name;
            existingRestoran.Address = restaurant.Address;
            existingRestoran.TelNo = restaurant.TelNo;
            existingRestoran.CategoryId = restaurant.CategoryId;

            try
            {
                _dbContext.RestaurantTable.Update(existingRestoran);
                await _dbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RestoranExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok();
        }

        [HttpDelete("{id}")]

        public async Task<IActionResult> DeleteRestoran(int id)
        {
            if (_dbContext.RestaurantTable == null)
            {
                return NotFound();
            }
            var restorant = await _dbContext.RestaurantTable.FindAsync(id);
            if (restorant == null)
            {
                return NotFound();
            }
            _dbContext.Remove(restorant);

            await _dbContext.SaveChangesAsync();

            return Ok();
        }
    }
}
