using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IPaymentService
    {
        IResult Pay(Payment payment);

        IResult Add(Payment payment);
        IResult Update(Payment payment);
        IResult Delete(Payment payment);
        IDataResult<Payment> GetById(int id);
        IDataResult<List<Payment>> GetAll();
        IDataResult<List<Payment>> GetAllByUserId(int userId);

    }
}
