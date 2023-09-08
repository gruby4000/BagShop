using BagShop.Data.Base;
using BagShop.Models;

namespace BagShop.Data.Services
{
    public class ManufacturersService: EntityBaseRepository<Manufacturer>, IManufacturersService
    {
        public ManufacturersService(AppDbContext context) : base(context)
        {
        }
    }
}
