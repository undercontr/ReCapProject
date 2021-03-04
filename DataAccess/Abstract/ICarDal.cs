﻿using System;
using System.Collections.Generic;
using System.Text;
using Entities.Concrete;

namespace DataAccess.Abstract
{
    public interface ICarDal
    {
        void Add(Car car);
        void Update(Car car);
        void Delete(Car car);
        List<Car> GetAll();
        Car GetById(int id);
        List<Car> GetByColorId(int id);
        List<Car> GetByBrandId(int id);
        List<Brand> GetAllBrands();
    }
}
