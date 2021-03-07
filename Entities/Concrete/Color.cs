using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Entities.Abstract;

namespace Entities.Concrete
{
    public class Color : IEntity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ColorId { get; set; }
        public string Name { get; set; }

        public List<Car> Cars { get; set; }
    }
}