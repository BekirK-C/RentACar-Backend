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
            // CustomerTest();

        }

        private static void CustomerTest()
        {
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
            var result = customerManager.GetAll();
            foreach (var customer in result.Data)
            {
                Console.WriteLine(customer.CompanyName);
            }
        }

        private static void ColorTest()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());

            foreach (var color in colorManager.GetAll().Data)
            {
                Console.WriteLine(color.Name);
            }
        }

        private static void BrandTest()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());

            foreach (var brand in brandManager.GetAll().Data)
            {
                Console.WriteLine(brand.Name);
            }
        }

        private static void CarTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());

            Car car1 = new Car { BrandId = 11, CarName = "test", ColorId = 11, DailyPrice = 1, Description = "den", ModelYear = 11 };
            var result = carManager.Add(car1);
            Console.WriteLine(result.IsSuccess + " " + result);


            //foreach (var car in carManager.GetAll().Data)
            //{
            //    Console.WriteLine("{0}", car.CarName);
            //}

            //foreach (var car in carManager.GetCarDetails())
            //{
            //    Console.WriteLine("{0}, {1}, {2}, {3}, ", car.CarName,car.Brandname,car.ColorName,car.DailyPrice);
            //}
        }
    }
}
