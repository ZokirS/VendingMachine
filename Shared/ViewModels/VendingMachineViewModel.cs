using Shared.DataTransferObjects;

namespace Shared.ViewModels
{
    public class VendingMachineViewModel
    {
        public IEnumerable<BeverageDto> Beverages { get; set; }
        public IEnumerable<CoinDto> Coins { get; set; }
    }
    public class VendingMachineResponseViewModel
    {
        public BeverageDto Beverage{ get; set; }
        public IEnumerable<CoinDto> Coins { get; set; }
    }
}
