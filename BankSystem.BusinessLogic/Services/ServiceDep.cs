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

        public void Dep(Account account)
        {
            //_db.AddAccount(account.UserId, account.Description = Convert.ToString(account.UserId.Id + " Вклад 5%"), (account.Amount / 100 * 5), account.Currency = "Рублевый");
        }
    }
}
