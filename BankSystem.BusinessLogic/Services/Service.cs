using BankSystem.BusinesLogic.Repositories;
using BankSystem.BusinessLogic.Exceptions;
using BankSystem.BusinessLogic.Model;
using System.Security.Principal;

namespace BankSystem.BusinesLogic.Services
{
    public class Service : IService
    {
        private IRepository _repository;

        public Service(IRepository repository)
        {
            if (repository == null)
                throw new Exception(ExceptionMessages.ExceptionRepository);

            _repository = repository;
        }

        public void AddUser(string lastName, string firstName, string middleName, DateTime birthday, Gender gender)
        {
            User user = new User(lastName, firstName, middleName, birthday, gender);

            _repository.CreateUser(user);                        
        }

        public void AddAccount(User user, string description, double amount, string currency)
        {
            if (user == null)
                throw new Exception(ExceptionMessages.ExceptionNullUser);

            user.AddAccount(description, amount, currency);       

            _repository.Save();
        }

       public void EditUser(User user, string lastName, string firstName, string middleName, DateTime birthday)
       {
            if (user == null)
                throw new Exception(ExceptionMessages.ExceptionNullUser);

            user.EditLastName(lastName);
            user.EditFirstName(firstName);
            user.EditMiddleName(middleName);
            user.EditBirthday(birthday);

            _repository.Save();
        }

        public void EditAccount(Account account, string description, double amount, string currency)
        {
            if (account == null)
                throw new Exception(ExceptionMessages.ExceptionOwner);

            account.EditDescription(description);
            account.EditAmount(amount);
            account.EditCurrency(currency);

            _repository.Save();
        }
    }
}
