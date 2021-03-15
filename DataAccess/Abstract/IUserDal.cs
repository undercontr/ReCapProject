using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities;
using Core.EntityFramework;
using Entities.Concrete;
using Entities.DTOs.Concrete;

namespace DataAccess.Abstract
{
    public interface IUserDal : IEntityRepository<User>
    {
    }
}
