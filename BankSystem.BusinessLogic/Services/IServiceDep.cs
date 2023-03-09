using BankSystem.BusinessLogic.Model;

namespace BankSystem.BusinesLogic.Services
{
    public interface IServiceDep
    {
        void Dep(User selectedUser, Account selectedAccount);
    }
}
