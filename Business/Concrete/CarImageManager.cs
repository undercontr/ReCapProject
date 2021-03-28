using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.FileUploads;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs.Concrete;
using Microsoft.AspNetCore.Http;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        private readonly ICarImageDal _carImageDal;

        public CarImageManager(ICarImageDal carImageDal)
        {
            _carImageDal = carImageDal;
        }

        [ValidationAspect(typeof(CarImageValidator))]
        public IResult Add(CarImage carImage, IFormFile formFile)
        {

            var result = BusinessRules.Run(CheckCarImageCountPerCar(carImage));

            if (result != null)
            {
                return result;
            }

            var uploadedPath = FileUploadHelper.CreateImage(formFile);

            carImage.ImagePath = uploadedPath.Data;
            carImage.Date = DateTime.Now;

            _carImageDal.Add(carImage);

            return new SuccessResult(Messages.CarImageAdded);
        }
        [ValidationAspect(typeof(CarImageValidator))]
        public IResult Update(CarImage carImage, IFormFile formFile)
        {

            var carImageRef = _carImageDal.Get(ci => ci.CarImageId == carImage.CarImageId);

            carImageRef.CarId = carImage.CarId;
            carImageRef.ImagePath = carImage.ImagePath;
            carImageRef.Date = DateTime.Now;

            FileUploadHelper.UpdateImage(carImage.ImagePath, formFile);

            _carImageDal.Update(carImage);

            return new SuccessResult(Messages.CarImageUpdated);
        }
        [ValidationAspect(typeof(CarImageValidator))]
        public IResult Delete(CarImage carImage)
        {

            var carImageRef = _carImageDal.Get(ci => ci.CarImageId == carImage.CarImageId);

            FileUploadHelper.DeleteImage(carImageRef.ImagePath);

            _carImageDal.Delete(carImageRef);

            return new SuccessResult(Messages.CarImageDeleted);
        }

        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll());
        }

        public IDataResult<CarImage> GetById(int id)
        {

            var result = BusinessRules.Run(CheckIfCarImageExists(id));


            return new SuccessDataResult<CarImage>(_carImageDal.Get(p => p.CarImageId == id));
        }

        public IDataResult<CarAllImagesDto> GetAllImagesByCarId(int carId)
        {
            return new SuccessDataResult<CarAllImagesDto>(_carImageDal.GetAllImagesByCarId(carId));
        }

        public IDataResult<List<CarImageDto>> GetAllDetailsWithImage()
        {
            return new SuccessDataResult<List<CarImageDto>>(_carImageDal.GetDetailsOfAllWithImage());
        }

        private IResult CheckCarImageCountPerCar(CarImage carImage)
        {
            var result = _carImageDal.GetAll(ci => ci.CarId == carImage.CarId).Count;

            if (result > 5)
            {
                return new ErrorResult();
            }

            return new SuccessResult();
        }

        private IDataResult<List<CarImage>> CheckIfCarImageExists(int carId)
        {
            var defaultImage = FileUploadHelper.UploadDir + @"\Default.png";

            var result = _carImageDal.GetAll(ci => ci.CarId == carId).Any();

            if (!result)
            {
                List<CarImage> carImages = new List<CarImage>
                {
                    new CarImage
                    {
                        CarId = carId, ImagePath = defaultImage, Date = DateTime.Now
                    }
                };
                return new SuccessDataResult<List<CarImage>>(carImages);
            }

            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(ci => ci.CarId == carId));

        }
    }
}
