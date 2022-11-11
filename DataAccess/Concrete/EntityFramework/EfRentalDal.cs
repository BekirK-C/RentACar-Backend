using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, CarProjectContext>, IRentalDal
    {
        public List<RentalDetailDto> GetRentalDetails()
        {
            using (CarProjectContext context = new CarProjectContext())
            {
                var result = from r in context.Rentals
                             join ca in context.Cars on r.CarId equals ca.Id
                             join b in context.Brands on ca.BrandId equals b.Id
                             join cu in context.Customers on r.CustomerId equals cu.Id
                             join u in context.Users on cu.UserId equals u.Id
                             select new RentalDetailDto { RentalId = r.Id, CarName=ca.CarName, BrandName = b.Name, CustomerFullName = u.FirstName + " " + u.LastName, RentDate = r.RentDate, ReturnDate = r.ReturnDate };

                return result.ToList();
            }
        }
    }
}
