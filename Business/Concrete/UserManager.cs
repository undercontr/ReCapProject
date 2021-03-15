using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
using Core.Utilities;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs.Concrete;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        private readonly IUserDal _userDal;
        private readonly ICustomerDal _customerDal;
        private readonly IRentalDal _rentDal;
        private readonly ICarDal _carDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;

        }

        public IDataResult<List<User>> GetAll()
        {
            return new SuccessDataResult<List<User>>(_userDal.GetAll());
        }

        public IDataResult<User> GetById(int id)
        {
            return new SuccessDataResult<User>(_userDal.Get(u => u.UserId == id));
        }
    }
}
