namespace Service.Contracts
{
    public interface IServiceManager
    {
        ICoinService CoinService { get; }
        IBeverageService BeverageService { get; }
    }
}
