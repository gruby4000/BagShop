using BagShop.Data.Base;
using BagShop.Models;

namespace BagShop.Data.Services
{
    public class MaterialsService : EntityBaseRepository<Material>, IMaterialsService
    {
        public MaterialsService(AppDbContext context) : base(context) { }
    }
}
