namespace Contracts
{
    public interface IRepositoryManager
    {
        IVendingMachineRepository VendingMachine { get; }
        IAdminRepository Admin { get; }
        void Save();
    }
}
