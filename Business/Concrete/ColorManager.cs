using Business.Abstract;
using Core.Utilities.Result;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ColorManager : IColorService
    {
        private readonly IColorDal _colorDal;

        public ColorManager(IColorDal colorDal)
        {
            _colorDal = colorDal;
        }

        public IResult Add(Color color)
        {
            return _colorDal.Add(color);
        }

        public IResult Delete(Color color)
        {
            return _colorDal.Delete(color);
        }

        public IDataResult<Color> Get(Expression<Func<Color, bool>> filter)
        {
            return _colorDal.Get(filter);
        }

        public IDataResult<IEnumerable<Color>> GetAll()
        {
            return _colorDal.GetAll();
        }

        public IResult Update(Color color)
        {
            return _colorDal.Update(color);
        }
    }
}
