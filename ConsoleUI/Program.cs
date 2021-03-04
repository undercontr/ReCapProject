using System;
using Business.Concrete;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {

            CarManager carManager = new CarManager(new InMemoryCarDal());

            foreach (Car car in carManager.GetAll())
            {
                Console.WriteLine(car.Description);
            }

            Console.ReadKey();
        }
    }
}
