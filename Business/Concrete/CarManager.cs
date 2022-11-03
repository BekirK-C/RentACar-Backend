using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;
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

        //[SecuredOperation("admin")]
        //[ValidationAspect(typeof(CarValidator))]
        [CacheRemoveAspect("ICarService.Get")]
        public IResult Add(Car car)
        {
            IResult result = BusinessRules.Run(CheckIfCarsCountOfBrandCorrect(car.BrandId));
            if (result != null)
            {
                return result;
            }
            _carDal.Add(car);
            return new SuccessResult(Messages.CarAdded);
        }

        public IResult AddTransactionalTest(Car car)
        {
            throw new NotImplementedException();
        }

        [SecuredOperation("car.delete")]
        public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            return new SuccessResult();
        }

        [CacheAspect]
        public IDataResult<List<Car>> GetAll()
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(), Messages.CarListed);
        }

        [CacheAspect]
        public IDataResult<List<Car>> GetByBrandId(int BrandId)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.BrandId == BrandId), Messages.CarListed);
        }

        public IDataResult<List<Car>> GetByColorId(int ColorId)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.ColorId == ColorId));
        }

        public IDataResult<List<CarDetatailDto>> GetCarDetails()
        {
            return new SuccessDataResult<List<CarDetatailDto>>(_carDal.GetCarDetails());
        }

        public IDataResult<List<CarDetatailDto>> GetCarDetailsById(int CarId)
        {
            return new SuccessDataResult<List<CarDetatailDto>>(_carDal.GetCarDetails(c => c.Id == CarId));
        }

        [CacheRemoveAspect("ICarService.Get")]
        public IResult Update(Car car)
        {
            _carDal.Update(car);
            return new SuccessResult();
        }

        private IResult CheckIfCarsCountOfBrandCorrect(int brandId)
        {
            // Bir markada en fazla 10 araba olacak.
            var result = _carDal.GetAll(c => c.BrandId == brandId).Count;
            if (result >= 10)
            {
                return new ErrorResult(Messages.CarCountofBrandError);
            }
            return new SuccessResult(Messages.CarAdded);
        }
    }
}
