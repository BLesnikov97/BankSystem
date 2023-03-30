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
            if (repository == null)
                throw new Exception(ExceptionMessages.ExceptionRepository);

            if (service == null)
                throw new Exception(ExceptionMessages.ExceptionService);

            _service = service;
            _repository = repository;

        }

        public void Dep(User selectedUser, Account selectedAccount)
        {
            if (selectedUser == null)
                throw new Exception(ExceptionMessages.ExceptionNullUser);
              
            if (selectedAccount == null)
                throw new Exception(ExceptionMessages.ExceptionNullAccount);

            string Description = "Deposit 5%";
            double Amount = selectedAccount.Amount / 100 * 5;

            _service.AddAccount(selectedUser, Description, Amount, selectedAccount.Currency);

            _repository.Save();

        }
    }
}
