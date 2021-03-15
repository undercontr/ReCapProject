using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
using Core.Utilities;
using DataAccess.Abstract;
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
    }
}
