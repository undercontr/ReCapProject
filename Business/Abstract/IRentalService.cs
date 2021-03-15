using System;
using System.Collections.Generic;
using System.Text;
using Core.Utilities;
using Entities.Concrete;
using Entities.DTOs.Concrete;

namespace Business.Abstract
{
    public interface IRentalService
    {
        IDataResult<RentalDetailDto> GetUserRentalDetail(int userId);
        IResult Add(Rental rental);
    }
}
