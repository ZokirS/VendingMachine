using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Repository.Configuration;
using Service.Contracts;
using Shared.DataTransferObjects;
using Shared.ViewModels;
using System.Text;

namespace VendingMachine.Web.Controllers
{
    public class VendingMachineController : Controller
    {
        private readonly IServiceManager _serviceManager;

        public VendingMachineController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        public IActionResult Index()
        {
            // Get the available beverages and coins from the services
            IEnumerable<BeverageDto> beverages = _serviceManager.BeverageService.GetAvailableBeverages();
            IEnumerable<CoinDto> coins = _serviceManager.CoinService.GetAvailableCoins();

            // Create a model to pass to the view
            var model = new VendingMachineViewModel
            {
                Beverages = beverages,
                Coins = coins
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult Purchase(int selectedBeverageId,  int[] coinsData)
        {
            var beverage = _serviceManager.BeverageService.GetBeverageById(selectedBeverageId);
            var coins = _serviceManager.CoinService.GetAvailableCoins().ToList();
            List<CoinDto> newCoins = new List<CoinDto>();
            for (int i = 0; i < coinsData.Length; i++)
            {
                newCoins.Add(new CoinDto
                (
                    coins[i].Id,
                    coins[i].Value,
                    coins[i].Available,
                    coinsData[i]
               ));
            }
            var totalFundsRequired = beverage.Price;

            var totalFundsProvided = newCoins.Sum(c => c.Value * c.Count);
            var change = totalFundsProvided - totalFundsRequired;
            if (change >= 0)
            {
                _serviceManager.BeverageService.SubtractBeverage(selectedBeverageId);
                foreach (var coin in newCoins)
                    _serviceManager.CoinService.AddCoin(coin.Id, coin.Count);
                if(change > 0)
                {
                    var changeCoins = _serviceManager.CoinService.Surrender(change).ToList();
                    var totalSum = changeCoins.Sum(x=>x.Value * x.Count);
                    var coinsText = new StringBuilder();
                    changeCoins.ForEach(x => coinsText.AppendLine($"Coin value and count: {x.Value} - {x.Count}"));
                    return Json(new { success = true, message = $"Purchase successful. Get your coins \n {coinsText}. Total: {totalSum}" });
                }
                return Json(new { success = true, message = "Purchase successful." });
            }
            else
            {
                return Json(new { success = false, message = "Insufficient funds for the selected beverage." });
            }
        }
    }
}
