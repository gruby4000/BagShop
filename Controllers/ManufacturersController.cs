using BagShop.Data;
using BagShop.Data.Services;
using BagShop.Data.Static;
using BagShop.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BagShop.Controllers
{
    [Authorize(Roles = UserRoles.Admin)]
    public class ManufacturersController : Controller
    {
        private readonly IManufacturersService _service;

        public ManufacturersController(IManufacturersService service)
        {
            _service = service;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var allManufacturers = await _service.GetAllAsync();
            return View(allManufacturers);
        }

        //GET: Manufacturers/details/1
        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
        {
            var manufacturerDetails = await _service.GetByIdAsync(id);
            if (manufacturerDetails == null) return View("NotFound");
            return View(manufacturerDetails);
        }

        //GET: Manufacturers/create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("ManufacturerLogoURL,Name,FoundationYear")]Manufacturer manufacturer)
        {
            if (!ModelState.IsValid) return View(manufacturer);

            await _service.AddAsync(manufacturer);
            return RedirectToAction(nameof(Index));
        }

        //GET: Manufacturers/edit/1
        public async Task<IActionResult> Edit(int id)
        {
            var manufacturerDetails = await _service.GetByIdAsync(id);
            if (manufacturerDetails == null) return View("NotFound");
            return View(manufacturerDetails);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ManufacturerLogoURL,Name,FoundationYear")] Manufacturer manufacturer)
        {
            if (!ModelState.IsValid) return View(manufacturer);

            if(id == manufacturer.Id)
            {
                await _service.UpdateAsync(id, manufacturer);
                return RedirectToAction(nameof(Index));
            }
            return View(manufacturer);
        }

        //GET: Manufacturers/delete/1
        public async Task<IActionResult> Delete(int id)
        {
            var manufacturerDetails = await _service.GetByIdAsync(id);
            if (manufacturerDetails == null) return View("NotFound");
            return View(manufacturerDetails);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var manufacturerDetails = await _service.GetByIdAsync(id);
            if (manufacturerDetails == null) return View("NotFound");

            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
