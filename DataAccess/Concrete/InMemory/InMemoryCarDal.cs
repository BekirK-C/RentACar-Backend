using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars; // Metotların üstünde tanımlanan global değişken alt çizgi (_) ile adlandırılır.

        public InMemoryCarDal() // Bu class new'lenince (Bellekte referans alınca) bellekte yeni bir Car listesi oluşacak.
        {
            // Bir veritabanından geliyormuş gibi veri ekliyoruz.
            _cars = new List<Car>
            {
                new Car {Id = 001, BrandId = 001, ColorId = 001, DailyPrice = 250000, ModelYear = 2015, Description = "Spor araba"},
                new Car {Id = 002, BrandId = 001, ColorId = 002, DailyPrice = 300000, ModelYear = 2018, Description = "Spor araba"},
                new Car {Id = 003, BrandId = 002, ColorId = 002, DailyPrice = 150000, ModelYear = 2008, Description = "Ticari araba"},
                new Car {Id = 004, BrandId = 003, ColorId = 003, DailyPrice = 400000, ModelYear = 1975, Description = "Klasik araba"},
            };
        }

        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete = _cars.SingleOrDefault(c => c.Id == car.Id);
            _cars.Remove(carToDelete);
        }

        public Car Get(Expression<Func<Car, bool>> filter)
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

        public List<Car> GetById(int Id)
        {
            return _cars.Where(c => c.Id == Id).ToList();
        }

        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(c => c.Id == car.Id);
            carToUpdate.BrandId = car.Id;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.ModelYear = car.ModelYear;
            carToUpdate.Description = car.Description;
        }
    }
}
