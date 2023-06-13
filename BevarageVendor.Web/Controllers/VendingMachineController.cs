using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DataTransferObjects;
using Shared.ViewModels;

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
            IEnumerable<BeverageDto> beverages = _serviceManager.BeverageService.GetAllBeverages();
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

            var totalFundsRequired = beverage.Price;

           // var totalFundsProvided = coinsData.Sum(c => c.Value * c.Count);

            if (0 >= totalFundsRequired)
            {

                return Json(new { success = true, message = "Purchase successful." });
            }
            else
            {
                return Json(new { success = false, message = "Insufficient funds for the selected beverage." });
            }
        }
       /*
        [HttpPost]
        public IActionResult Purchase(VendingMachineResponseViewModel viewModel)
        {
            var beverage = _serviceManager.BeverageService.GetBeverageById(viewModel.Beverage.Id);

            var totalFundsRequired = beverage.Price;
            var coinCounts = viewModel.Coins;
            var totalFundsProvided = coinCounts.Sum(c => c.Value * c.Count);

            if (totalFundsProvided >= totalFundsRequired)
            {

                return Json(new { success = true, message = "Purchase successful." });
            }
            else
            {
                return Json(new { success = false, message = "Insufficient funds for the selected beverage." });
            }
        }*/
    }
}
