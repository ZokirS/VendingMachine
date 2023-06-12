using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DataTransferObjects;
using Shared.ViewModels;

namespace VendingMachine.Web.Controllers
{
    public class VendingMachineController : Controller
    {
        private readonly IBeverageService _beverageService;
        private readonly ICoinService _coinService;

        public VendingMachineController(IBeverageService beverageService, ICoinService coinService)
        {
            _beverageService = beverageService;
            _coinService = coinService;
        }

        public IActionResult Index()
        {
            // Get the available beverages and coins from the services
            IEnumerable<BeverageDto> beverages = _beverageService.GetAvailableBeverages();
            IEnumerable<CoinDto> coins = _coinService.GetAvailableCoins();

            // Create a model to pass to the view
            var model = new VendingMachineViewModel
            {
                Beverages = beverages,
                Coins = coins
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult PurchaseBeverage(int[] coinValues, int beverageId)
        {
            // Calculate the total value of the provided coins
            int totalCoinValue = coinValues.Sum();

            // Get the selected beverage by id
            BeverageDto selectedBeverage = _beverageService.GetBeverageById(beverageId);

            // Check if a valid beverage is available
            if (selectedBeverage == null)
            {
                return BadRequest("Invalid beverage selection");
            }

            // Calculate the surrender amount
            int surrenderAmount = totalCoinValue - (int)selectedBeverage.Price;

            // Prepare the data to be returned
            var result = new
            {
                SelectedBeverage = selectedBeverage,
                SurrenderAmount = surrenderAmount
            };

            // Return the data as a JSON result
            return Json(result);
        }
    }
}
