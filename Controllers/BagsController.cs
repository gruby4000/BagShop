using BagShop.Data;
using BagShop.Data.Services;
using BagShop.Data.Static;
using BagShop.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace BagShop.Controllers
{
    [Authorize(Roles = UserRoles.Admin)]
    public class BagsController : Controller
    {
        private readonly IBagsService _service;

        public BagsController(IBagsService service)
        {
            _service = service;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var allBags = await _service.GetAllAsync(n => n.Manufacturer, d => d.Designer);
            return View(allBags);
        }

        [AllowAnonymous]
        public async Task<IActionResult> Filter(string searchString)
        {
            var allBags = await _service.GetAllAsync(n => n.Manufacturer);

            if (!string.IsNullOrEmpty(searchString))
            {
                //var filteredResult = allBags.Where(n => n.Name.ToLower().Contains(searchString.ToLower()) || n.Description.ToLower().Contains(searchString.ToLower())).ToList();

                var filteredResultNew = allBags.Where(n => string.Equals(n.Name, searchString, StringComparison.CurrentCultureIgnoreCase) || string.Equals(n.Description, searchString, StringComparison.CurrentCultureIgnoreCase)).ToList();

                return View("Index", filteredResultNew);
            }

            return View("Index", allBags);
        }

        //GET: Bags/Details/1
        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
        {
            var bagDetail = await _service.GetBagByIdAsync(id);
            return View(bagDetail);
        }

        //GET: Bags/Create
        public async Task<IActionResult> Create()
        {
            var bagDropdownsData = await _service.GetNewBagDropdownsValues();

            ViewBag.Designers = new SelectList(bagDropdownsData.Designers, "Id", "Surname");
            ViewBag.Manufacturers = new SelectList(bagDropdownsData.Manufacturers, "Id", "Name");
            ViewBag.Materials = new SelectList(bagDropdownsData.Materials, "Id", "Name");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(NewBagVM bag)
        {
            if (!ModelState.IsValid)
            {
                var bagDropdownsData = await _service.GetNewBagDropdownsValues();

                ViewBag.Designers = new SelectList(bagDropdownsData.Designers, "Id", "Surname");
                ViewBag.Manufacturers = new SelectList(bagDropdownsData.Manufacturers, "Id", "Name");
                ViewBag.Materials = new SelectList(bagDropdownsData.Materials, "Id", "Name");

                return View(bag);
            }

            await _service.AddNewBagAsync(bag);
            return RedirectToAction(nameof(Index));
        }


        //GET: Bags/Edit/1
        public async Task<IActionResult> Edit(int id)
        {
            var bagDetails = await _service.GetBagByIdAsync(id);
            if (bagDetails == null) return View("NotFound");

            var response = new NewBagVM()
            {
                Id = bagDetails.Id,
                Name = bagDetails.Name,
                Description = bagDetails.Description,
                Price = bagDetails.Price,
                ImageURL = bagDetails.ImageURL,
                BagCategory = bagDetails.BagCategory,
                DesignerId = bagDetails.DesignerId,
                ManufacturerId = bagDetails.ManufacturerId,
                MaterialIds = bagDetails.Materials_Bags.Select(n => n.MaterialId).ToList(),
            };

            var bagDropdownsData = await _service.GetNewBagDropdownsValues();
            ViewBag.Designers = new SelectList(bagDropdownsData.Designers, "Id", "Surname");
            ViewBag.Manufacturers = new SelectList(bagDropdownsData.Manufacturers, "Id", "Name");
            ViewBag.Materials = new SelectList(bagDropdownsData.Materials, "Id", "Name");

            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, NewBagVM bag)
        {
            if (id != bag.Id) return View("NotFound");

            if (!ModelState.IsValid)
            {
                var bagDropdownsData = await _service.GetNewBagDropdownsValues();

                ViewBag.Designers = new SelectList(bagDropdownsData.Designers, "Id", "Surname");
                ViewBag.Manufacturers = new SelectList(bagDropdownsData.Manufacturers, "Id", "Name");
                ViewBag.Materials = new SelectList(bagDropdownsData.Materials, "Id", "Name");

                return View(bag);
            }

            await _service.UpdateBagAsync(bag);
            return RedirectToAction(nameof(Index));
        }
    }
}