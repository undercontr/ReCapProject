using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Data;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using DataAccess.Abstract;
using Entities.Concrete;

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
                new Car {Id = 1, BrandId = 1, ColorId = 5, DailyPrice = 45000, Description = "Hybrid Hatchback", ModelYear = 2014},
                new Car {Id = 2, BrandId = 1, ColorId = 3, DailyPrice = 60000, Description = "Slightly Expensive Hybrid Hatchback", ModelYear = 2014},
                new Car {Id = 3, BrandId = 2, ColorId = 8, DailyPrice = 1000000, Description = "Super Expensive Hybrid Hatchback", ModelYear = 2021},
                new Car {Id = 4, BrandId = 3, ColorId = 4, DailyPrice = 165000, Description = "Average Hybrid Hatchback", ModelYear = 2019}
            };

            _brands = new List<Brand>
            {
                new Brand {Id = 1, BrandName = "Fiat", Cars = _cars.FindAll(c => c.BrandId == 1)},
                new Brand {Id = 2, BrandName = "Ferrari", Cars = _cars.FindAll(c => c.BrandId == 2)},
                new Brand {Id = 3, BrandName = "Ford", Cars = _cars.FindAll(c => c.BrandId == 3)}
            };

            _colors = new List<Color>
            {
                new Color {Id = 5, ColorName = System.Drawing.Color.Blue},
                new Color {Id = 3, ColorName = System.Drawing.Color.Orange},
                new Color {Id = 8, ColorName = System.Drawing.Color.Red},
                new Color {Id = 4, ColorName = System.Drawing.Color.Black}
            };
        }

        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            // Id unique olduğu için RemoveAll demekte bir problem. Sonuçta tek eşleşme olacak.
            _cars.RemoveAll(c => c.Id == car.Id);
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Brand> GetAllBrands()
        {
            return _brands;
        }

        public List<Car> GetByBrand(Brand brand)
        {
            return _brands.SingleOrDefault(b => b.Id == brand.Id).Cars;
        }

        public List<Car> GetByColor(Color color)
        {
            return _cars.FindAll(c => c.ColorId == color.Id);
        }

        public Car GetById(int id)
        {
            return _cars.SingleOrDefault(c => c.Id == id);
        }

        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(c => c.Id == car.Id);

            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.ModelYear = car.ModelYear;
            carToUpdate.Description = car.Description;

        }
    }
}
