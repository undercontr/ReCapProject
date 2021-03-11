using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities;

namespace Entities.DTOs.Concrete
{
    public class CarDetailsDto : IDto
    {
        public int CarId { get; set; }
        public string CarName { get; set; }
        public string BrandName { get; set; }
        public string ColorName { get; set; }
        public decimal DailyPrice { get; set; }
    }
}
