namespace Contracts
{
    public interface IRepositoryManager
    {
        public IBeverageRepository Beverage { get; }
        public ICoinRepository Coin { get; }
        void Save();
    }
}
