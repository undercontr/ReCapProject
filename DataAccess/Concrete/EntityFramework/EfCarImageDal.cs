using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs.Concrete;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarImageDal : EfEntityRepositoryBase<CarImage, CarContext>, ICarImageDal
    {

        public List<CarImageDto> GetDetailsOfAllWithImage()
        {
            using (CarContext context = new CarContext())
            {
                var result = from ci in context.Set<CarImage>()
                    join c in context.Set<Car>() on ci.CarId equals c.CarId
                    select new CarImageDto()
                    {
                        ModelYear = c.ModelYear,
                        CarId = c.CarId,
                        CarImageId = ci.CarImageId,
                        CarImageDate = ci.Date,
                        CarImagePath = ci.ImagePath,
                        CarName = c.Name
                    };

                return result.ToList();
            }
        }

        public CarAllImagesDto GetAllImagesByCarId(int carId)
        {
            using (CarContext context = new CarContext())
            {
                var result = from c in context.Set<Car>()
                    where c.CarId == carId
                    select new CarAllImagesDto
                    {
                        CarName = c.Name,
                        CarId = c.CarId,
                        CarImages = GetAll(ci => ci.CarId == carId)
                    };

                

                return result.SingleOrDefault();
            }
        }
    }
}
