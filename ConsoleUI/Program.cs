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
            CarManager carManager = new CarManager(new EfCarDal());

            Console.WriteLine(carManager.GetAll().Success);

            foreach (Car car in carManager.GetAll().Data)
            {
                Console.WriteLine(car.ModelYear + " " + "");
            }

        }
    }
}
