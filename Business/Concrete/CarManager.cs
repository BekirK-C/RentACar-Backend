using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        // BİR İŞ SINIFI BAŞKA SINIFLARI NEW'LEMEZ. INJECTION EDİLİR.

        ICarDal _carDal;

        public CarManager(ICarDal carDal)   // CarManager New'lendiğinde bir ICarDal referansı ister.
        {
            _carDal = carDal;
        }

        public void Add(Car car)
        {
            if (car.Description.Length >=2 && car.DailyPrice > 0)
            {
                _carDal.Add(car);
            }
            else
            {
                Console.WriteLine("Hatalı");
            }
        }

        public List<Car> GetAll()
        {
            return _carDal.GetAll();
        }

        public List<Car> GetByBrandId(int BrandId)
        {
            return _carDal.GetAll(c => c.BrandId == BrandId);
        }

        public List<Car> GetByColorId(int ColorId)
        {
            return _carDal.GetAll(c => c.ColorId == ColorId);
        }
    }
}
