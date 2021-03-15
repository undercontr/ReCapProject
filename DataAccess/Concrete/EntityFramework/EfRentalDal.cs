using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs.Concrete;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, CarContext>, IRentalDal
    {

        public RentalDetailDto GetUserRentalDetail(int userId)
        {
            using (CarContext context = new CarContext())
            {
                var result = from u in context.Set<User>()
                    join cu in context.Set<Customer>() on u.UserId equals cu.UserId
                    join re in context.Set<Rental>() on cu.CustomerId equals re.CustomerId
                    join ca in context.Set<Car>() on re.CarId equals ca.CarId
                    join co in context.Set<Color>() on ca.ColorId equals co.ColorId
                    join br in context.Set<Brand>() on ca.BrandId equals br.BrandId
                    where u.UserId == userId
                    select new RentalDetailDto
                    {
                        ModelYear = ca.ModelYear,
                        CarId = ca.CarId,
                        BrandName = br.Name,
                        ColorName = co.Name,
                        CarName = ca.Name,
                        CarDailyPrice = ca.DailyPrice,
                        CompanyName = cu.CompanyName,
                        Email = u.Email,
                        FirstName = u.FirstName,
                        LastName = u.LastName,
                        RentDate = re.RentDate,
                        ReturnDate = re.ReturnDate,
                        UserId = u.UserId
                    };

                return result.SingleOrDefault();
            }

        }
    }
}
