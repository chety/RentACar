using Core.Entities;
using Core.Utilities.Result;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Core.DataAccess.Concrete
{
    public class EfEntityRepositoryBase<TContext, TEntity> : IEntityRepository<TEntity>
        where TEntity : class, IEntity, new()
        where TContext : DbContext, new()
    {
        public IResult Add(TEntity item)
        {
            try
            {
                using var context = new TContext();
                var entry = context.Entry(item);
                entry.State = EntityState.Added;
                context.SaveChanges();
                return new SuccessResult();
            }
            catch (Exception ex)
            {
                return new ErrorResult(ex.ToString());
            }
        }

        public IResult Delete(TEntity item)
        {
            try
            {
                using var context = new TContext();
                var entry = context.Entry(item);
                entry.State = EntityState.Deleted;
                context.SaveChanges();
                return new SuccessResult();
            }
            catch (Exception ex)
            {
                return new ErrorResult(ex.ToString());
            }
        }

        public IDataResult<TEntity> Get(Expression<Func<TEntity, bool>> expression)
        {
            try
            {
                using var context = new TContext();
                var data = context.Set<TEntity>().SingleOrDefault();
                return new SuccessDataResult<TEntity>(data);
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<TEntity>(ex.ToString());
            }
        }

        public IDataResult<IEnumerable<TEntity>> GetAll(Expression<Func<TEntity, bool>> expression)
        {
            try
            {
                using var context = new TContext();
                var dbSet = context.Set<TEntity>();
                var data = expression is null ? dbSet.ToList() : dbSet.Where(expression).ToList();
                return new SuccessDataResult<IEnumerable<TEntity>>(data);
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<IEnumerable<TEntity>>(ex.ToString());
            }
        }

        public IResult Update(TEntity item)
        {
            try
            {
                using var context = new TContext();
                var entry = context.Entry(item);
                entry.State = EntityState.Modified;
                context.SaveChanges();
                return new SuccessResult();
            }
            catch (Exception ex)
            {
                return new ErrorResult(ex.ToString());
            }
        }
    }
}
