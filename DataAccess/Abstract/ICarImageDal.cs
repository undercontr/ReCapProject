using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities;
using Core.EntityFramework;
using Entities.Concrete;
using Entities.DTOs.Concrete;

namespace DataAccess.Abstract
{
    public interface ICarImageDal : IEntityRepository<CarImage>
    {
        List<CarImageDto> GetDetailsOfAllWithImage();
        CarAllImagesDto GetAllImagesByCarId(int id);
    }
}
