using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DataTransferObjects;

namespace VendingMachine.Web.Controllers
{
    public class CoinController : Controller
    {
        private readonly ICoinService _coinService;
        public CoinController(ICoinService coinService)
        {
            _coinService = coinService;
        }
        public IActionResult Index()
        {
            var coins = _coinService.GetAllCoins();
            return View(coins);
        }
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(CoinDto coin)
        {
            if (ModelState.IsValid)
            {
                _coinService.AddCoin(coin.Id, coin.Count);
                return RedirectToAction(nameof(Index));
            }
            return View(coin);
        }

        public IActionResult Edit(int id)
        {
            var coin = _coinService.GetCoinById(id);
            if (coin == null)
            {
                return NotFound();
            }
            return View(coin);
        }

        // POST: /Beverage/Edit/1
        [HttpPost]
        public IActionResult Edit(int id, CoinDto coin)
        {
            if (id != coin.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _coinService.UpdateCoin(coin.Id);
                return RedirectToAction(nameof(Index));
            }
            return View(coin);
        }
    }
}
