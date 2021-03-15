using System;
using System.Collections.Generic;
using System.Text;
using Core.EntityFramework;
using Entities.Concrete;
using Entities.DTOs.Concrete;

namespace DataAccess.Abstract
{
    public interface IRentalDal : IEntityRepository<Rental>
    {
        RentalDetailDto GetUserRentalDetail(int userId);
        new void Add(Rental rental);
    }
}
