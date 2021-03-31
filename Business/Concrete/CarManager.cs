using Business.Abstract;
using Business.Constants;
using Business.Validation.FluentValidation;
using Core.CrossCuttingConcerns;
using Core.Utilities.Result;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        private readonly ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        public IResult Add(Car car)
        {
            ValidationTool.Validate(new CarValidator(), car);
            return _carDal.Add(car);
        }

        public IResult Delete(Car car)
        {
            return _carDal.Delete(car);
        }

        public IDataResult<Car> Get(Expression<Func<Car, bool>> filter)
        {
            var foundedCarResponse = _carDal.Get(filter);
            if (!foundedCarResponse.Success)
            {
                return new ErrorDataResult<Car>(Messages.NoCarFound);
            }
            return new SuccessDataResult<Car>(foundedCarResponse.Data, Messages.CarFound);
        }

        public IDataResult<IEnumerable<Car>> GetAll()
        {
            return _carDal.GetAll();
        }

        public IDataResult<Car> GetById(int id)
        {
            return _carDal.Get(c => c.Id == id);
        }

        public IDataResult<IEnumerable<Car>> GetCarsByBrandId(int brandId)
        {
            return _carDal.GetAll(c => c.BrandId == brandId);
        }

        public IDataResult<IEnumerable<Car>> GetCarsByColorId(int colorId)
        {
            return _carDal.GetAll(c => c.ColorId == colorId);
        }

        public IDataResult<IEnumerable<Car>> GetCarsByModelYearAndDailyPrice(int modelYear, decimal dailyPrice)
        {
            return _carDal.GetAll(c => c.ModelYear == modelYear && c.DailyPrice <= dailyPrice);
        }

        public IResult Update(Car car)
        {
            return _carDal.Update(car);
        }
    }
}
