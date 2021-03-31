using Core.Utilities.Result;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Business.Abstract
{
    public interface IBrandService
    {
        IDataResult<IEnumerable<Brand>> GetAll();
        IDataResult<Brand> Get(Expression<Func<Brand, bool>> filter);

        IResult Add(Brand brand);
        IResult Update(Brand brand);
        IResult Delete(Brand brand);
    }
}
