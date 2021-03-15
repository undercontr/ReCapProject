using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities;

namespace Entities.DTOs.Concrete
{
    public class RentalDetailDto : IDto
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string CompanyName { get; set; }
        public int CarId { get; set; }
        public string CarName { get; set; }
        public decimal CarDailyPrice { get; set; }
        public int ModelYear { get; set; }
        public string BrandName { get; set; }
        public string ColorName { get; set; }

        public DateTime RentDate { get; set; }
        public DateTime? ReturnDate { get; set; }
    }
}
