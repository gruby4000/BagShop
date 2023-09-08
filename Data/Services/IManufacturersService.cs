using BagShop.Data.Base;
using BagShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BagShop.Data.Services
{
    public interface IManufacturersService:IEntityBaseRepository<Manufacturer>
    {
    }
}
