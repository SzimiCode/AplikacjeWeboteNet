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


       
    }
}
