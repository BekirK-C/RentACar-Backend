using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    // İş katmanında kullanılacak servis operasyonlarını içerir.
    public interface ICarService
    {
        List<Car> GetAll();

        List<Car> GetByBrandId(int BrandId);
        List<Car> GetByColorId(int ColorId);
        void Add(Car car);
    }
}
