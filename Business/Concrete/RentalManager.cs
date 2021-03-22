using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs.Concrete;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        private readonly IRentalDal _rentalDal;

        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }
        public IDataResult<RentalDetailDto> GetUserRentalDetail(int userId)
        {
            return new SuccessDataResult<RentalDetailDto>(_rentalDal.GetUserRentalDetail(userId));
        }

        public IResult Add(Rental rental)
        {
            var rentalControl = _rentalDal.GetAll(r => (r.CarId == rental.CarId) && (r.ReturnDate.HasValue || r.ReturnDate == null));

            if (rentalControl.Count > 0)
            {
                return new ErrorResult();
            }
            else
            {
                _rentalDal.Add(rental);
                return new SuccessResult();
            }
        }
    }
}
