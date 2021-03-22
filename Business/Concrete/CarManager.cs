using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs.Concrete;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        private readonly ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        public IDataResult<List<Car>> GetAll()
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(), Messages.ProductsListed);
        }

        public IDataResult<Car> GetById(int id)
        {
            return new SuccessDataResult<Car>(_carDal.Get(c => c.CarId == id), Messages.ProductGetSuccess);
        }

        public IDataResult<List<CarDetailsDto>> GetCarDetails()
        {
            return new SuccessDataResult<List<CarDetailsDto>>(_carDal.GetCarDetails(), Messages.ProductDetailsSuccess);
        }

        [ValidationAspect(typeof(ProductValidator))]
        public IResult Add(Car car)
        {

            _carDal.Add(car);

            return new SuccessResult(Messages.ProductAdded);
        }

        public IResult Update(Car car)
        {
            _carDal.Update(car);

            return new SuccessResult(Messages.ProductUpdated);
        }

        public IResult Delete(Car car)
        {
            _carDal.Delete(car);

            return new SuccessResult(Messages.ProductDeleted);
        }


    }
}
