using System;
using System.Collections.Generic;
using System.Text;
using Core.EntityFramework;
using Entities.Concrete;
using Entities.DTOs.Concrete;

namespace DataAccess.Abstract
{
    public interface ICarDal : IEntityRepository<Car>
    {
        List<CarDetailsDto> GetCarDetails();
    }
}
