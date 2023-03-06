using BankSystem.BusinesLogic.BaseConnect;
using BankSystem.BusinessLogic.Model;

namespace BankSystem.BusinesLogic.Services
{
    public class ServiceDep : IServiceDep
    {
        private IServiceRepository _service;

        private IRepository _db;

        public ServiceDep(IRepository db , IServiceRepository service)
        {
            _service = service;
            _db = db;
        }

        public void Dep(User SelectedUser, Account SelectedAccount)
        {
            string Description = "Deposit 5%";

            double Amount = SelectedAccount.Amount / 100 * 5;

            string Currency = SelectedAccount.Currency;

            _service.AddAccount(SelectedUser, Description, Amount, Currency);
            _db.Save();
        }
    }
}
