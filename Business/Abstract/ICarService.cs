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
        List<CarAllInfoDto> GetAllWithRelations();
        Car GetById(int id);
        List<CarBrandDto> GetCarsByBrandId(int id);
        List<CarColorDto> GetCarsByColorId(int id);

    }
}
