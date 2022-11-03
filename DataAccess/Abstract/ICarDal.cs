using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Abstract
{
    // Car ile ilgili veritabanında yapılacak işlemleri içeren interface
    public interface ICarDal : IEntityRepository<Car>
    {
        List<CarDetatailDto> GetCarDetails(Expression<Func<CarDetatailDto, bool>>? filter = null);
    }
}
