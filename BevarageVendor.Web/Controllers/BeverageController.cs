using Entities.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Service.Contracts;
using Shared.DataTransferObjects;

namespace VendingMachine.Web.Controllers
{
    public class BeverageController : Controller
    {
        private readonly IBeverageService _beverageService;
        public BeverageController(IBeverageService beverageService)
        {
            _beverageService = beverageService;
        }
        public IActionResult Index()
        {
            var beverages = _beverageService.GetAllBeverages();
            return View(beverages);
        }
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(BeverageDto beverage)
        {
            if (ModelState.IsValid)
            {
                _beverageService.Addbeverage(beverage.Id, beverage.Count);
                return RedirectToAction(nameof(Index));
            }
            return View(beverage);
        }

        public IActionResult Edit(int id)
        {
            var beverage = _beverageService.GetBeverageById(id);
            if (beverage == null)
            {
                return NotFound();
            }
            return View(beverage);
        }

        // POST: /Beverage/Edit/1
        [HttpPost]
        public IActionResult Edit(int id, BeverageDto beverage)
        {
            if (id != beverage.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _beverageService.UpdateBeverage(beverage);
                return RedirectToAction(nameof(Index));
            }
            return View(beverage);
        }

        // GET: /Beverage/Delete/1
        public IActionResult Delete(int id)
        {
            var beverage = _beverageService.GetBeverageById(id);
            if (beverage == null)
            {
                return NotFound();
            }
            return View(beverage);
        }

        // POST: /Beverage/Delete/1
        [HttpPost]
        public IActionResult DeleteConfirmed(int id)
        {
            var beverage = _beverageService.GetBeverageById(id);
            if (beverage == null)
            {
                return NotFound();
            }

            _beverageService.DeleteBeverage(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
