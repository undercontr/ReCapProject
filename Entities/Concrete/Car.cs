using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.InteropServices;
using System.Text;
using Core.Entities;

namespace Entities.Concrete
{
    public class Car : IEntity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CarId { get; set; }
        public int BrandId { get; set; }
        public int ColorId { get; set; }

        private string name;

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                if (value.Length > 2)
                {
                    name = value;
                }
                else
                {
                    throw new ValidationException("Car name must be bigger than 2 characters");
                }
            }

        }
        public int ModelYear { get; set; }

        private decimal dailyPrice;

        public decimal DailyPrice
        {
            get
            {
                return dailyPrice;
            }
            set
            {
                if (value > 0) dailyPrice = value; else throw new ValidationException("DailyPrice must be bigger than 0");
            }
        }
        public string Description { get; set; }

        public Brand Brand { get; set; }
        public Color Color { get; set; }
    }
}
