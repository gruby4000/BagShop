using BagShop.Data.Base;
using BagShop.Data.ViewModels;
using BagShop.Models;
using System.Threading.Tasks;

namespace BagShop.Data.Services
{
    public interface IBagsService:IEntityBaseRepository<Bag>
    {
        Task<Bag> GetBagByIdAsync(int id);
        Task<NewBagDropdownsVM> GetNewBagDropdownsValues();
        Task AddNewBagAsync(NewBagVM data);
        Task UpdateBagAsync(NewBagVM data);
    }
}
