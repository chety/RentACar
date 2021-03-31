using Business.Abstract;
using Core.Utilities.Result;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Business.Concrete
{
    public class BrandManager : IBrandService
    {
        private readonly IBrandDal _brandDal;

        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }

        public IResult Add(Brand brand)
        {
            return _brandDal.Add(brand);
        }

        public IResult Delete(Brand brand)
        {
            return _brandDal.Delete(brand);
        }

        public IDataResult<Brand> Get(Expression<Func<Brand, bool>> filter)
        {
            return _brandDal.Get(filter);
        }

        public IDataResult<IEnumerable<Brand>> GetAll()
        {
            return _brandDal.GetAll();
        }

        public IResult Update(Brand brand)
        {
            return _brandDal.Update(brand);
        }
    }
}
