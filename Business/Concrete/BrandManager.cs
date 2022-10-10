using Business.Abstract;
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

        public void Add(Brand brand)
        {
            _branDal.Add(brand);
        }

        public void Delete(Brand brand)
        {
            _branDal.Delete(brand);
        }

        public List<Brand> GetAll()
        {
            return _branDal.GetAll();
        }

        public List<Brand> GetByBrandId(int brandId)
        {
            return _branDal.GetAll(b => b.Id == brandId);
        }

        public List<Brand> GetByCarId(string brandName)
        {
            return _branDal.GetAll(b => b.Name == brandName);
        }

        public void Update(Brand brand)
        {
            _branDal.Update(brand);
        }
    }
}
