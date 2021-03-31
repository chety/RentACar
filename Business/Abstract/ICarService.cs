using Core.Utilities.Result;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Business.Abstract
{
    public interface ICarService
    {
        IDataResult<Car> GetById(int id);
        IDataResult<IEnumerable<Car>> GetAll();
        IDataResult<Car> Get(Expression<Func<Car, bool>> filter);
        IDataResult<IEnumerable<Car>> GetCarsByModelYearAndDailyPrice(int modelYear, decimal dailyPrice);
        IDataResult<IEnumerable<Car>> GetCarsByBrandId(int brandId);
        IDataResult<IEnumerable<Car>> GetCarsByColorId(int colorId);

        IResult Add(Car car);
        IResult Update(Car car);
        IResult Delete(Car car);
    }
}
