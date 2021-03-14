using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using Core.Utilities;
using Entities.DTOs.Concrete;

namespace Business.Abstract
{
    public interface ICarService
    {
        IDataResult<List<Car>> GetAll();
        IDataResult<Car> GetById(int id);
        IDataResult<List<CarDetailsDto>> GetCarDetails();
    }
}
