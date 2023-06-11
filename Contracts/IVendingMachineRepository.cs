using Entities.Models;
namespace Contracts
{
    public interface IVendingMachineRepository
    {
        VendingMachine GetVendingMachineModel(bool trackChanges);
        void InsertCoin(int coin);
        OperationResult SelectBeverage(string beverageId);
        OperationResult GetChange();
    }
}
