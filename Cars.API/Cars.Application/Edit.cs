using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cars.Domain;
using Cars.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore.Query.Internal;

namespace Cars.Application
{
    public class Edit
    {
        public class Command : IRequest<Unit>
        {
            public required Car Car { get; set; }
        }

        public class Handler : IRequestHandler<Command, Unit>
        {
            private readonly DataContext _context;

            public Handler(DataContext context)
            {
                _context = context;
            }
            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                var car = await _context.Cars.FindAsync(request.Car.Id);
                car.Brand = request.Car.Brand ?? car.Brand;
                car.Model = request.Car.Model ?? car.Model;
                car.DoorsNumber = request.Car.DoorsNumber;
                car.LuggageCapactiy = request.Car.LuggageCapactiy;
                car.EngineCapactiy = request.Car.EngineCapactiy;
                car.FuelType = request.Car.FuelType;
                car.ProductionDate = request.Car.ProductionDate;
                car.CarFuelConsumption = request.Car.CarFuelConsumption;
                car.BodyType = request.Car.BodyType;

                await _context.SaveChangesAsync();
                return Unit.Value;
            }
        }
    }
}
