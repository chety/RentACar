using Core.DataAccess;
using Entities.Concrete;
using Entities.DTO;
using System.Collections.Generic;

namespace DataAccess.Abstract
{
    public interface ICarDal : IEntityRepository<Car>
    {
        List<CarDetail> GetCarDetails();
    }
}
