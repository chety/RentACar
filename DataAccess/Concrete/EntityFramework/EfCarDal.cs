using Core.DataAccess.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<RentCarContext, Car>, ICarDal
    {

    }
}
