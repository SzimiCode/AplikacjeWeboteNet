using Cars.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Cars.Domain;

namespace Cars.API.Controllers
{
    public class CarsController : BaseApiController
    {
        private readonly DataContext _context;

        public CarsController(DataContext context)
        {
            _context = context;
        }
        [HttpGet] //api/cars

        public async Task<ActionResult<List<Car>>> GetCars ()
        {
            return await _context.Cars.ToListAsync();
        }

        [HttpGet("{id}")] // /api/cars/id

        public async Task<ActionResult<Car>> GetCar(Guid id)
        {
            Console.WriteLine($"Received ID: {id}");
            return await _context.Cars.FindAsync(id);
        }
        //  Aktualizacja auta (PUT /api/cars/{id})
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCar(Guid id, Car car)
        {
            if (id != car.Id) return BadRequest();
            _context.Entry(car).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        //  Usuwanie auta (DELETE /api/cars/{id})
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCar(Guid id)
        {
            var car = await _context.Cars.FindAsync(id);
            if (car == null) return NotFound();
            _context.Cars.Remove(car);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<Car>> CreateCar(Car car)
        {
            _context.Cars.Add(car);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetCar), new { id = car.Id }, car);
        }




    }
}
