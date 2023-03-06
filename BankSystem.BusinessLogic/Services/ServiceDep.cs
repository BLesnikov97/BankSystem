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
            string Description = "Deposit 5%";

            double Amount = SelectedAccount.Amount / 100 * 5;

            string Currency = SelectedAccount.Currency;

            _db.AddAccount(SelectedUser, Description, Amount, Currency);
        }
    }
}
