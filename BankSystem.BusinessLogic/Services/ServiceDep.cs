using BankSystem.BusinesLogic.Repositories;
using BankSystem.BusinessLogic.Exceptions;
using BankSystem.BusinessLogic.Model;

namespace BankSystem.BusinesLogic.Services
{
    public class ServiceDep : IServiceDep
    {
        private IService _service;

        private IRepository _repository;

        public ServiceDep(IRepository repository, IService service)
        {
            if (repository != null)
            {
                if (service != null)
                {
                    _service = service;
                    _repository = repository;
                }
                else
                    throw new Exception(ExceptionMessages.ExceptionService);
            }
            else
                throw new Exception(ExceptionMessages.ExceptionRepository);

        }

        public void Dep(User selectedUser, Account selectedAccount)
        {
            if (selectedUser != null && selectedAccount != null)
            {
                string Description = "Deposit 5%";

                double Amount = selectedAccount.Amount / 100 * 5;

                string Currency = selectedAccount.Currency;

                _service.AddAccount(selectedUser, Description, Amount, Currency);

                _repository.Save();
            }
            else
                throw new Exception(ExceptionMessages.ExceptionUserAndAccount);
        }
    }
}
