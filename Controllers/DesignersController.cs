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
    public class DesignersController : Controller
    {
        private readonly IDesignersService _service;

        public DesignersController(IDesignersService service)
        {
            _service = service;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var allDesigners = await _service.GetAllAsync();
            return View(allDesigners);
        }


        //Get: Designer/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("Surname,Name,BirthdayYear,Nationality")]Designer designer)
        {
            if (!ModelState.IsValid) return View(designer);
            await _service.AddAsync(designer);
            return RedirectToAction(nameof(Index));
        }

        //Get: Designers/Details/1
        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
        {
            var designerDetails = await _service.GetByIdAsync(id);
            if (designerDetails == null) return View("NotFound");
            return View(designerDetails);
        }

        //Get: Designers/Edit/1
        public async Task<IActionResult> Edit(int id)
        {
            var designerDetails = await _service.GetByIdAsync(id);
            if (designerDetails == null) return View("NotFound");
            return View(designerDetails);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Surname,Name,BirthdayYear,Nationality")] Designer designer)
        {
            if (!ModelState.IsValid) return View(designer);
            await _service.UpdateAsync(id, designer);
            return RedirectToAction(nameof(Index));
        }

        //Get: Designers/Delete/1
        public async Task<IActionResult> Delete(int id)
        {
            var designerDetails = await _service.GetByIdAsync(id);
            if (designerDetails == null) return View("NotFound");
            return View(designerDetails);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirm(int id)
        {
            var designerDetails = await _service.GetByIdAsync(id);
            if (designerDetails == null) return View("NotFound");

            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
