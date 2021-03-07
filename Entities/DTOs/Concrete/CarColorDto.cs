using System;
using System.Collections.Generic;
using System.Text;
using Entities.Concrete;

namespace Entities.DTOs.Concrete
{
    public class CarColorDto
    {
        public Car Car { get; set; }
        public Color Color { get; set; }
    }
}
