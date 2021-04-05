using Core.Utilities.Result;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Business.Abstract
{
    public interface IColorService
    {
        IDataResult<IEnumerable<Color>> GetAll();
        IDataResult<Color> Get(Expression<Func<Color, bool>> filter);

        IResult Add(Color color);
        IResult Update(Color color);
        IResult Delete(Color color);
    }
}
