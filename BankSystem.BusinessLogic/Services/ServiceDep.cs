using BankSystem.BusinessLogic.Model;

namespace BankSystem.BusinesLogic.Services
{
    public class ServiceDep : IServiceDep
    {
        private IServiceRepository _db;

        public ServiceDep(IServiceRepository db)
        {
            _db = db;
        }

        public void Dep(User SelectedUser, Account SelectedAccount)
        {
            _db.AddAccount(SelectedUser, "Deposit 5%", SelectedAccount.Amount / 100 * 5, "Рублевый");
        }
    }
}
