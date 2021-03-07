using System;
using System.Runtime.InteropServices;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using Entities.DTOs.Concrete;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {

            //EfBrandDal efBrand = new EfBrandDal();

            //efBrand.Add(new Brand { Name = "Fiat" });
            //efBrand.Add(new Brand { Name = "Ferrari" });
            //efBrand.Add(new Brand { Name = "Ford" });

            //EfColorDal efColor = new EfColorDal();

            //efColor.Add(new Color { Name = "Blue" });
            //efColor.Add(new Color { Name = "Orange" });
            //efColor.Add(new Color { Name = "Red" });
            //efColor.Add(new Color { Name = "Black" });

            //EfCarDal efCar = new EfCarDal();

            //efCar.Add(new Car { BrandId = 1, ColorId = 3, DailyPrice = 45000, Description = "Hybrid Hatchback", ModelYear = 2014 });
            //efCar.Add(new Car { BrandId = 1, ColorId = 3, DailyPrice = 60000, Description = "Slightly Expensive Hybrid Hatchback", ModelYear = 2005 });
            //efCar.Add(new Car { BrandId = 2, ColorId = 1, DailyPrice = 1000000, Description = "Super Expensive Ferrari", ModelYear = 2021 });
            //efCar.Add(new Car { BrandId = 3, ColorId = 4, DailyPrice = 165000, Description = "Average Hybrid Hatchback", ModelYear = 2014 });

            CarManager carManager = new CarManager(new EfCarDal(), new EfBrandDal(), new EfColorDal());

            foreach (CarAllInfoDto dto in carManager.GetAllWithRelations())
            {
                Console.WriteLine($@"Car: {dto.Brand.Name}, {dto.Car.Name} | Year: {dto.Car.ModelYear} | Color: {dto.Color.Name} | Desc: {dto.Car.Description} | Price: {dto.Car.DailyPrice.ToString("C")}");
            }


            //foreach (Car car in carManager.GetAll())
            //{
            //    Console.WriteLine($@"Car: {car.Brand.Name}, {car.Name} | Year: {car.ModelYear} | Color: {car.Color.Name} | Desc: {car.Description} | Price: {car.DailyPrice.ToString("C")}");
            //}

            Console.ReadKey();
        }
    }
}
