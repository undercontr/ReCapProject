using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Xml.Xsl;
using Core.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, CarContext>, ICarDal
    {
        public List<CarDetailsDto> GetCarDetails()
        {
            using (CarContext context = new CarContext())
            {
                var result =

                    from c in context.Cars
                    join b in context.Brands on c.BrandId equals b.BrandId
                    join co in context.Colors on c.ColorId equals co.ColorId
                    select new CarDetailsDto
                    {
                        CarId = c.CarId,
                        CarName = c.Name,
                        DailyPrice = c.DailyPrice,
                        ColorName = co.Name,
                        BrandName = b.Name
                    };

                return result.ToList();
            }
        }
    }
}
