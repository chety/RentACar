using Core.Utilities.Result;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        private readonly List<Car> _cars;
        public InMemoryCarDal()
        {
            _cars = new List<Car>
            {
                new Car {  BrandId = 2, ColorId = 4, DailyPrice = 125_000, Description = "A new sport car by ferrari", ModelYear = 2021},
                new Car {  BrandId = 2, ColorId = 12, DailyPrice = 500_000, Description = "Ferrari Luxury Limozin", ModelYear = 2019},
                new Car {  BrandId = 1, ColorId = 1, DailyPrice = 236_999, Description = "Bmw 3000", ModelYear = 2021},
                new Car {  BrandId = 3, ColorId = 2, DailyPrice = 145_000, Description = "Volsvagen Golf", ModelYear = 2015},
                new Car {  BrandId = 5, ColorId = 5, DailyPrice = 96_000, Description = "Honda Civic", ModelYear = 2018},
            };
            
        }
        public IResult Add(Car car)
        {
            if (car is null)
            {
                return new ErrorResult("Car can not be null");
            }
            _cars.Add(car);
            return new SuccessResult("Car added successfully");
        }

        public IResult Delete(Car car)
        {
            var foundedCarResponse = GetById(car.Id);
            if (!foundedCarResponse.Success)
            {
                return new ErrorResult("The car you provided does not exist");
            }
            _cars.Remove(foundedCarResponse.Data);
            return new SuccessResult("Car deleted successfully");            
        }

        public IDataResult<Car> Get(Expression<Func<Car, bool>> expression)
        {
            try
            {
                var foundedCar = _cars.SingleOrDefault(expression.Compile());
                return new SuccessDataResult<Car>(foundedCar);

            }
            catch (Exception ex)
            {
                return new ErrorDataResult<Car>(ex.ToString());
            }

        }

        public IDataResult<IEnumerable<Car>> GetAll(Expression<Func<Car, bool>> expression)
        {
            var data = expression is null ? _cars : _cars.Where(expression.Compile());
            return new SuccessDataResult<IEnumerable<Car>>(data, "Cars listed successfully");
        }

        public IDataResult<Car> GetById(int id)
        {
            try
            {
                var foundedCar = _cars.SingleOrDefault(c => c.Id == id);
                return new SuccessDataResult<Car>(foundedCar, "Car founded successfully");
            }
            catch (Exception)
            {
                return new ErrorDataResult<Car>($"There is no car with id {id}");
            }
        }

        public IResult Update(Car car)
        {
            var foundedCarResponse = GetById(car.Id);
            if (!foundedCarResponse.Success)
            {
                return new ErrorResult("The car you provided does not exist");
            }
            var foundedCar = foundedCarResponse.Data;
            foundedCar.BrandId = car.BrandId;
            foundedCar.ColorId = car.ColorId;
            foundedCar.DailyPrice = car.DailyPrice;
            foundedCar.Description = car.Description;
            foundedCar.ModelYear = car.ModelYear;
            return new SuccessResult("Car updated successfully");
        }
    }
}
