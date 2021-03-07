using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs.Concrete;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        private readonly ICarDal _carDal;
        private readonly IBrandDal _brandDal;
        private readonly IColorDal _colorDal;

        public CarManager(ICarDal carDal, IBrandDal brandDal, IColorDal colorDal)
        {
            _carDal = carDal;
            _brandDal = brandDal;
            _colorDal = colorDal;
        }

        public List<Car> GetAll()
        {
            return _carDal.GetAll();
        }

        public Car GetById(int id)
        {
            return _carDal.Get(p => p.CarId == id);
        }

        public List<CarBrandDto> GetCarsByBrandId(int id)
        {

            var result = from p in _carDal.GetAll()
                join b in _brandDal.GetAll() on p.BrandId equals b.BrandId
                where p.BrandId == id
                select new CarBrandDto
                {
                    Car = p,
                    Brand = b
                };

        return result.ToList();
        }

        public List<CarColorDto> GetCarsByColorId(int id)
        {

            var result = from c in _carDal.GetAll()
                join co in _colorDal.GetAll() on c.ColorId equals co.ColorId
                where c.ColorId == id
                select new CarColorDto()
                {
                    Car = c,
                    Color = co
                };

            return result.ToList();
        }

        public List<CarAllInfoDto> GetAllWithRelations()
        {
            var result = from c in _carDal.GetAll()
                join co in _colorDal.GetAll() on c.ColorId equals co.ColorId
                join b in _brandDal.GetAll() on c.BrandId equals  b.BrandId
                select new CarAllInfoDto()
                {
                    Car = c,
                    Color = co,
                    Brand = b
                };

            return result.ToList();
        }
    }
}
