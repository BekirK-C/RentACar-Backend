using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalDal;

        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }

        [ValidationAspect(typeof(RentalValidator))]
        public IResult Add(Rental rental)
        {
            IResult result = BusinessRules.Run(CheckIfTheCarIsAlreadyRentedInTheSelectedDateRange(rental), CheckIfThereIsARentalCarOnTheNextDatesWhenTheDeliveryDateIsNull(rental), CheckIfTheCarHasBeenDelivered(rental));
            if (result != null)
            {
                return result;
            }
            _rentalDal.Add(rental);
            return new SuccessResult(Messages.RentalAdded);
        }

        public IResult Delete(Rental rental)
        {
            _rentalDal.Delete(rental);
            return new SuccessResult();
        }

        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll());
        }

        public IDataResult<Rental> GetRental(int rentalId)
        {
            return new SuccessDataResult<Rental>(_rentalDal.Get(r => r.Id == rentalId));
        }

        public IDataResult<List<RentalDetailDto>> GetRentalDetails()
        {
            return new SuccessDataResult<List<RentalDetailDto>>(_rentalDal.GetRentalDetails(), Messages.RentalListed);
        }

        public IResult Update(Rental rental)
        {
            _rentalDal.Update(rental);
            return new SuccessResult();
        }

        private IResult CheckIfTheCarHasBeenDelivered(Rental rental)
        {
            var result = _rentalDal.Get(r => r.CarId == rental.CarId && r.ReturnDate == null);
            if (result != null)
                if (rental.ReturnDate == null || rental.ReturnDate > result.RentDate)
                    return new ErrorResult(Messages.RentalNotAdded);

            return new SuccessResult();
        }
        private IResult CheckIfTheCarIsAlreadyRentedInTheSelectedDateRange(Rental rental)
        {
            var result = _rentalDal.Get(r =>
                r.CarId == rental.CarId
                && (r.RentDate.Date == rental.RentDate.Date
                || (r.RentDate.Date < rental.RentDate.Date
                && (r.ReturnDate == null || ((DateTime)r.ReturnDate).Date > rental.RentDate.Date))));

            if (result != null)
                return new ErrorResult(Messages.TheCarIsAlreadyRentedInTheSelectedDateRange);

            return new SuccessResult();
        }

        private IResult CheckIfThereIsARentalCarOnTheNextDatesWhenTheDeliveryDateIsNull(Rental rental)
        {
            var result = _rentalDal.GetAll(r => r.CarId == rental.CarId && rental.ReturnDate == null && r.RentDate.Date > rental.RentDate);
            if (result.Any()) return new ErrorResult(Messages.TheDeliveryDateCannotBeLeftBlankWhenThereIsARentedVehicleInTheFuture);

            return new SuccessResult();
        }
    }
}
