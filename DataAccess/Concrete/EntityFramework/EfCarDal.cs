using Core.DataAccess.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTO;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<RentCarContext, Car>, ICarDal
    {
        public List<CarDetail> GetCarDetails()
        {
            using var context = new RentCarContext();
            var result = from ca in context.Cars
                         join br in context.Brands
                         on ca.BrandId equals br.Id
                         join co in context.Colors
                         on ca.ColorId equals co.Id
                         select new CarDetail
                         {
                             BrandName = br.Name,
                             CarName = ca.Name,
                             ColorName = co.Name,
                             DailyPrice = ca.DailyPrice
                         };
            return result.ToList();
        }
    }
}
