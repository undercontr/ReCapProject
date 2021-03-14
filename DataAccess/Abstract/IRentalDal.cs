using System;
using System.Collections.Generic;
using System.Text;
using Core.EntityFramework;
using Entities.Concrete;

namespace DataAccess.Abstract
{
    public interface IRentalDal : IEntityRepository<Rental>
    {
        
    }
}
