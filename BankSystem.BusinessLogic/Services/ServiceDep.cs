using BankSystem.BusinesLogic.Repositories;
using BankSystem.BusinessLogic.Model;

namespace BankSystem.BusinesLogic.Services
{
    public class ServiceDep : IServiceDep
    {
        private IService _service;

        private IRepository _repository;

        public ServiceDep(IRepository repository, IService service)
        {
            _service = service;
            _repository = repository;
        }

        public void Dep(User selectedUser, Account selectedAccount)
        {
            string Description = "Deposit 5%";

            double Amount = selectedAccount.Amount / 100 * 5;

            string Currency = selectedAccount.Currency;

            _service.AddAccount(selectedUser, Description, Amount, Currency);

            _repository.Save();
        }
    }
}
