using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class BrandManager : IBrandService
    {
        IBrandDal _branDal;

        public BrandManager(IBrandDal branDal)
        {
            _branDal = branDal;
        }

        public IResult Add(Brand brand)
        {
            _branDal.Add(brand);
            return new SuccessResult();
        }

        public IResult Delete(Brand brand)
        {
            _branDal.Delete(brand);
            return new SuccessResult();
        }

        public IDataResult<List<Brand>> GetAll()
        {
            return new SuccessDataResult<List<Brand>>(_branDal.GetAll());
        }

        public IDataResult<List<Brand>> GetByBrandId(int brandId)
        {
            return new SuccessDataResult<List<Brand>>(_branDal.GetAll(b => b.Id == brandId));
        }

        public IDataResult<List<Brand>> GetByCarId(string brandName)
        {
            return new SuccessDataResult<List<Brand>>(_branDal.GetAll(b => b.Name == brandName));
        }

        public IResult Update(Brand brand)
        {
            _branDal.Update(brand);
            return new SuccessResult();
        }
    }
}
