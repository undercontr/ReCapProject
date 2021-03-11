using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs.Concrete;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        private readonly List<Car> _cars;
        private readonly List<Brand> _brands;
        private readonly List<Color> _colors;

        public InMemoryCarDal()
        {

            //hafıza usulü fake veritabanı
            _cars = new List<Car>
            {
                new Car {CarId = 1, BrandId = 1, ColorId = 3, DailyPrice = 45000, Description = "Hybrid Hatchback", ModelYear = 2014},
                new Car {CarId = 2, BrandId = 1, ColorId = 3, DailyPrice = 60000, Description = "Slightly Expensive Hybrid Hatchback", ModelYear = 2005},
                new Car {CarId = 3, BrandId = 2, ColorId = 1, DailyPrice = 1000000, Description = "Super Expensive Ferrari", ModelYear = 2021},
                new Car {CarId = 2, BrandId = 3, ColorId = 4, DailyPrice = 165000, Description = "Average Hybrid Hatchback", ModelYear = 2014}
            };

            _brands = new List<Brand>
            {
                new Brand {BrandId = 1, Name = "Fiat"},
                new Brand {BrandId = 2, Name = "Ferrari"},
                new Brand {BrandId = 3, Name = "Ford"}
            };

            _colors = new List<Color>
            {
                new Color {ColorId = 1, Name = "Blue"},
                new Color {ColorId = 2, Name = "Orange"},
                new Color {ColorId = 3, Name = "Red"},
                new Color {ColorId = 4, Name = "Black"}
            };
        }

        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            // BrandId unique olduğu için RemoveAll demekte bir problem. Sonuçta tek eşleşme olacak.
            _cars.RemoveAll(c => c.CarId == car.CarId);
        }

        public Car Get(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<CarDetailsDto> GetCarDetails()
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Brand> GetAllBrands()
        {
            return _brands;
        }

        public List<Car> GetByBrandId(int id)
        {
            return _cars.Where(c => c.BrandId == id).ToList();
        }

        public List<Car> GetByColorId(int id)
        {
            return _cars.Where(c => c.ColorId == id).ToList();
        }

        public Car GetById(int id)
        {
            return _cars.SingleOrDefault(c => c.CarId == id);
        }

        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(c => c.CarId == car.CarId);

            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.ModelYear = car.ModelYear;
            carToUpdate.Description = car.Description;

        }
    }
}
