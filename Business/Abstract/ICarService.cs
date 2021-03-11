using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using Entities.DTOs.Concrete;

namespace Business.Abstract
{
    public interface ICarService
    {
        List<Car> GetAll();
        Car GetById(int id);
        List<CarDetailsDto> GetCarDetails();
    }
}
