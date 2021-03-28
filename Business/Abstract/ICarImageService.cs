using System;
using System.Collections.Generic;
using System.Text;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs.Concrete;
using Microsoft.AspNetCore.Http;

namespace Business.Abstract
{
    public interface ICarImageService
    {
        IResult Add(CarImage carImage, IFormFile formfile);
        IResult Update(CarImage carImage, IFormFile formFile);
        IResult Delete(CarImage carImage);
        IDataResult<List<CarImage>> GetAll();
        IDataResult<CarImage> GetById(int id);
        IDataResult<CarAllImagesDto> GetAllImagesByCarId(int carId);
        IDataResult<List<CarImageDto>> GetAllDetailsWithImage();
    }
}
