using System;
using System.Collections.Generic;
using System.Text;
using Entities.Concrete;
using Entities.DTOs.Abstract;

namespace Entities.DTOs.Concrete
{
    public class CarBrandDto : IDto
    {
        public Car Car { get; set; }
        public Brand Brand { get; set; }

    }
}
