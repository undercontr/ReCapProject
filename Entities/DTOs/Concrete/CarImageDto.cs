using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities;

namespace Entities.DTOs.Concrete
{
    public class CarImageDto : IDto
    {
        public int CarImageId { get; set; }
        public int CarId { get; set; }
        public string CarName { get; set; }
        public string CarImagePath { get; set; }
        public DateTime CarImageDate { get; set; }
        public int ModelYear { get; set; }
    }
}
