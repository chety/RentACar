using Core.Entities;
using Core.Utilities.Result;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Core.DataAccess
{
    public interface IEntityRepository<T> where T : IEntity, new()
    {
        IDataResult<IEnumerable<T>> GetAll(Expression<Func<T, bool>> expression = null);
        IDataResult<T> Get(Expression<Func<T, bool>> expression);

        IResult Add(T item);
        IResult Update(T item);
        IResult Delete(T item);
    }
}
