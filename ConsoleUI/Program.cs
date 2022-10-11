using Business.Concrete;
using DataAccess.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CarTest();
            // BrandTest();
            // ColorTest();
        }

        private static void ColorTest()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());

            foreach (var color in colorManager.GetAll())
            {
                Console.WriteLine(color.Name);
            }
        }

        private static void BrandTest()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());

            foreach (var brand in brandManager.GetAll())
            {
                Console.WriteLine(brand.Name);
            }
        }

        private static void CarTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());

            //Car car1 = new Car { BrandId = 11, CarName = "deneme", ColorId = 11, DailyPrice = 1, Description = "den", ModelYear = 11 };
            //var result = carManager.Add(car1);
            //Console.WriteLine(Convert.ToByte(result.IsSuccess) +" / "+ result.Message);

            foreach (var car in carManager.GetAll().Data)
            {
                Console.WriteLine("{0}", car.CarName);
            }

                //foreach (var car in carManager.GetCarDetails())
                //{
                //    Console.WriteLine("{0}, {1}, {2}, {3}, ", car.CarName,car.Brandname,car.ColorName,car.DailyPrice);
                //}
        }
    }
}
