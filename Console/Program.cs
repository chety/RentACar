using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            var carManager = new CarManager(new EfCarDal());

            //ADD TESTS
            //var _cars =  new List<Car>
            //{
            //    new Car { BrandId = 3, ColorId = 2, DailyPrice = 1_345_678, Description = "Rollce Royce", ModelYear = 2021},
            //    new Car { BrandId = 2, ColorId = 4, DailyPrice = 125_000, Description = "A new sport car by ferrari", ModelYear = 2021},
            //    new Car { BrandId = 2, ColorId = 12, DailyPrice = 500_000, Description = "Ferrari Luxury Limozin", ModelYear = 2019},
            //    new Car { BrandId = 1, ColorId = 1, DailyPrice = 236_999, Description = "Bmw 3000", ModelYear = 2021},
            //    new Car { BrandId = 3, ColorId = 2, DailyPrice = 145_000, Description = "Volsvagen Golf", ModelYear = 2015},
            //    new Car { BrandId = 5, ColorId = 5, DailyPrice = 96_000, Description = "Honda Civic", ModelYear = 2018},
            //};
            //_cars.ForEach(car => carManager.Add(car));

            //GETALL TESTS
            //var cars = carManager.GetAll();
            //if (!cars.Success)
            //{
            //    Console.WriteLine($"There is an error while getting cars information. Details: {cars.Message}");
            //}
            //else
            //{
            //    foreach (var car in cars.Data)
            //    {
            //        Console.WriteLine($"{car.Description}");
            //    }

            //}

            //GETBYBRANDID TEST
            //var carsByBrandId = carManager.GetCarsByBrandId(2);
            //carsByBrandId.Data.ToList().ForEach(car => Console.WriteLine($"{car.BrandId} --- {car.Description}"));

            //BRAND INSERT TEST
            //var brandManager = new BrandManager(new EfBrandDal());
            //var brands = new List<Brand>
            //{
            //  new Brand
            //  {
            //      Name = "Volsvagen"
            //  },
            //  new Brand
            //  {
            //      Name = "BMW"
            //  },
            //  new Brand
            //  {
            //      Name = "Volvo"
            //  },
            //  new Brand
            //  {
            //      Name = "Suzuki"
            //  },
            //  new Brand
            //  {
            //      Name = "Ford"
            //  }
            //};

            //brands.ForEach(brand => brandManager.Add(brand));

            //CAR VALIDATION TEST
            //var car = new Car
            //{
            //    BrandId = 3,
            //    ColorId = 2,
            //    DailyPrice = 0,
            //    Name = "abcdfd",
            //    Description = "Brand new shitty car",
            //    ModelYear = 1990
            //};
            //var result = carManager.Add(car);
            //Console.WriteLine(result.Message);

            foreach (var carDetail in carManager.GetAllCarDetails())
            {
                Console.WriteLine(carDetail);
            }
        }
    }
}
