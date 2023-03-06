using BankSystem.BusinessLogic.Model;

namespace BankSystem.BusinesLogic.Services
{
    public interface IServiceDep
    {
        void Dep(User SelectedUser, Account SelectedAccount);
    }
}
