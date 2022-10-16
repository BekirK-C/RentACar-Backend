using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
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

        [ValidationAspect(typeof(CarValidator))]
        public IResult Add(Car car)
        {
            if ((CheckIfProductCountOfCategoryCorrect(car.BrandId)).IsSuccess)
            {
                _carDal.Add(car);
                return new SuccessResult(Messages.ProductAdded);
            }
            return new ErrorResult();
        }

        public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            return new SuccessResult();
        }

        public IDataResult<List<Car>> GetAll()
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(), Messages.ProductsListed);
        }

        public IDataResult<List<Car>> GetByBrandId(int BrandId)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.BrandId == BrandId), Messages.ProductsListed);
        }

        public IDataResult<List<Car>> GetByColorId(int ColorId)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.ColorId == ColorId));
        }

        public IDataResult<List<CarDetatailDto>> GetCarDetails()
        {
            return new SuccessDataResult<List<CarDetatailDto>>(_carDal.GetCarDetails());
        }

        public IResult Update(Car car)
        {
            _carDal.Update(car);
            return new SuccessResult();
        }

        private IResult CheckIfProductCountOfCategoryCorrect(int brandId)
        {
            // Bir kategoride en fazla 10 ürün olacak.
            var result = _carDal.GetAll(c => c.BrandId == brandId).Count;
            if (result >= 10)
            {
                return new ErrorResult(Messages.ProductCountofBrandError);
            }
            return new SuccessResult();
        }
    }
}
