using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities;
using Entities.Concrete;

namespace Entities.DTOs.Concrete
{
    public class CarAllImagesDto : IDto
    {
        public int CarId { get; set; }
        public string CarName { get; set; }
        public List<CarImage> CarImages { get; set; }
    }
}
