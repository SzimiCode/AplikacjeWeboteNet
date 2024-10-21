using Cars.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cars.Infrastructure
{
    public class Seed
    {
        public static async Task SeedData(DataContext context)
        {
            if (context.Cars.Any()) return;

            var cars = new List<Car>
            {
                new Car  {
                            Brand = "Mazda",
                            Model = "СХ60",
                            DoorsNumber = 5,
                            LuggageCapactiy = 570,
                            EngineCapactiy = 2488,
                            FuelType = FuelType.Hybrid,
                            ProductionDate = DateTime.UtcNow.AddMonths(-1),
                            CarFuelConsumption = 18.1,
                            BodyType = BodyType.SUV
                },

                new Car
                {
                    Brand = "Mazda2",
                    Model = "СХ602",
                    DoorsNumber = 51,
                    LuggageCapactiy = 5701,
                    EngineCapactiy = 24881,
                    FuelType = FuelType.Hybrid,
                    ProductionDate = DateTime.UtcNow.AddMonths(-1),
                    CarFuelConsumption = 18.12,
                    BodyType = BodyType.SUV
                },
                new Car
                {
                    Id = Guid.NewGuid(),
                    Brand = "Toyota",
                    Model = "Corolla",
                    DoorsNumber = 4,
                    LuggageCapactiy = 500,
                    EngineCapactiy = 1600,
                    FuelType = FuelType.Petrol,
                    ProductionDate = new DateTime(2020, 5, 15),
                    CarFuelConsumption = 5.8,
                    BodyType = BodyType.Sedan
                },
                new Car
                {
                    Id = Guid.NewGuid(),
                    Brand = "Ford",
                    Model = "Focus",
                    DoorsNumber = 5,
                    LuggageCapactiy = 550,
                    EngineCapactiy = 1800,
                    FuelType = FuelType.Diesel,
                    ProductionDate = new DateTime(2018, 8, 25),
                    CarFuelConsumption = 6.1,
                    BodyType = BodyType.Hatchback
                }
              };
 
    }
    }
}
