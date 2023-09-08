using BagShop.Data.Base;
using BagShop.Data.ViewModels;
using BagShop.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace BagShop.Data.Services
{
    public class BagsService : EntityBaseRepository<Bag>, IBagsService
    {
        private readonly AppDbContext _context;
        public BagsService(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task AddNewBagAsync(NewBagVM data)
        {
            var newBag = new Bag()
            {
                Name = data.Name,
                Description = data.Description,
                Price = data.Price,
                ImageURL = data.ImageURL,
                DesignerId = data.DesignerId,
                BagCategory = data.BagCategory,
                ManufacturerId = data.ManufacturerId
            };
            await _context.Bags.AddAsync(newBag);
            await _context.SaveChangesAsync();

            //Add Bag Materials
            foreach (var materialId in data.MaterialIds)
            {
                var newMaterialBag = new Material_Bag()
                {
                    BagId = newBag.Id,
                    MaterialId = materialId
                };
                await _context.Materials_Bags.AddAsync(newMaterialBag);
            }
            await _context.SaveChangesAsync();
        }

        public async Task<Bag> GetBagByIdAsync(int id)
        {
            var bagDetails = await _context.Bags
                .Include(c => c.Designer)
                .Include(p => p.Manufacturer)
                .Include(am => am.Materials_Bags).ThenInclude(a => a.Material)
                .FirstOrDefaultAsync(n => n.Id == id);

            return bagDetails;
        }

        public async Task<NewBagDropdownsVM> GetNewBagDropdownsValues()
        {
            var response = new NewBagDropdownsVM()
            {
                Materials = await _context.Materials.OrderBy(n => n.Name).ToListAsync(),
                Designers = await _context.Designers.OrderBy(n => n.Surname).ToListAsync(),
                Manufacturers = await _context.Manufacturers.OrderBy(n => n.Name).ToListAsync()
            };

            return response;
        }

        public async Task UpdateBagAsync(NewBagVM data)
        {
            var dbBag = await _context.Bags.FirstOrDefaultAsync(n => n.Id == data.Id);

            if(dbBag != null)
            {
                dbBag.Name = data.Name;
                dbBag.Description = data.Description;
                dbBag.Price = data.Price;
                dbBag.ImageURL = data.ImageURL;
                dbBag.DesignerId = data.DesignerId;
                dbBag.BagCategory = data.BagCategory;
                dbBag.ManufacturerId = data.ManufacturerId;
                await _context.SaveChangesAsync();
            }

            //Remove existing materials
            var existingMaterialsDb = _context.Materials_Bags.Where(n => n.BagId == data.Id).ToList();
            _context.Materials_Bags.RemoveRange(existingMaterialsDb);
            await _context.SaveChangesAsync();

            //Add Bag Materials
            foreach (var materialId in data.MaterialIds)
            {
                var newMaterialBag = new Material_Bag()
                {
                    BagId = data.Id,
                    MaterialId = materialId
                };
                await _context.Materials_Bags.AddAsync(newMaterialBag);
            }
            await _context.SaveChangesAsync();
        }
    }
}
