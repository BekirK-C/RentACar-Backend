using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    // İş katmanında kullanılacak servis operasyonlarını içerir.
    public interface ICarService
    {
        IDataResult<List<Car>> GetAll();
        IDataResult<List<Car>> GetByBrandId(int BrandId);
        IDataResult<List<Car>> GetByColorId(int ColorId);
        IDataResult<List<CarDetatailDto>> GetCarDetails();
        IDataResult<List<CarDetatailDto>> GetCarDetailsByCarId(int CarId);
        IResult Add(Car car);
        IResult Delete(Car car);
        IResult Update(Car car);
        IResult AddTransactionalTest(Car car);
    }
}
