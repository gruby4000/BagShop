using BagShop.Data.Base;
using BagShop.Models;

namespace BagShop.Data.Services
{
    public class DesignersService:EntityBaseRepository<Designer>, IDesignersService
    {
        public DesignersService(AppDbContext context) : base(context)
        {
        }
    }
}
