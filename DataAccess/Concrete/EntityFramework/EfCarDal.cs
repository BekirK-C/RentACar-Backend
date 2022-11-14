using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    // IPCar, car'a özel db işlemleri yapabilmemizi sağlar.
    public class EfCarDal : EfEntityRepositoryBase<Car, CarProjectContext>, ICarDal
    {
        // DTO kullanımı
        public List<CarDetatailDto> GetCarDetails(Expression<Func<CarDetatailDto, bool>>? filter = null)
        {
            using (CarProjectContext context = new CarProjectContext())
            {
                var result = from ca in context.Cars
                             join br in context.Brands on ca.BrandId equals br.Id
                             join co in context.Colors on ca.ColorId equals co.Id
                             join ci in context.CarImages on ca.Id equals ci.CarId
                             select new CarDetatailDto { Id = ca.Id, CarName = ca.CarName, BrandName = br.Name, BrandId = br.Id, ColorName = co.Name, ColorId = co.Id, DailyPrice = ca.DailyPrice, Description = ca.Description, ModelYear = ca.ModelYear, ImagePath = ci.ImagePath };

                return filter != null ? result.Where(filter).ToList() : result.ToList();
            }
        }
    }
}
