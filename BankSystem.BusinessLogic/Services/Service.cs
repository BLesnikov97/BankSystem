using BankSystem.BusinesLogic.Repositories;
using BankSystem.BusinessLogic.Exceptions;
using BankSystem.BusinessLogic.Model;

namespace BankSystem.BusinesLogic.Services
{
    public class Service : IService
    {
        private IRepository _repository;

        public Service(IRepository repository)
        {   
            if(repository != null)
                _repository = repository;

            else
                throw new Exception(ExceptionMessages.ExceptionRepository);
        }

        public void AddUser(string lastName, string firstName, string middleName, DateTime birthday, Gender gender)
        {
            if (string.IsNullOrEmpty(lastName))
            {
                throw new Exception(ExceptionMessages.ExceptionLastName);
            }
            if (string.IsNullOrEmpty(firstName))
            {
                throw new Exception(ExceptionMessages.ExceptionFirstName);
            }
            if (string.IsNullOrEmpty(middleName))
            {
                throw new Exception(ExceptionMessages.ExceptionMiddleName);
            }
            if (birthday >= DateTime.Now.AddYears(-14))
            {
                throw new Exception(ExceptionMessages.ExceptionMinimumAge);
            }

            User user = new User(lastName, firstName, middleName, birthday, gender);

            _repository.CreateUser(user);                        
        }

        public void AddAccount(User user, string description, double amount, string currency)
        {
            if (user == null)
            {
                throw new Exception(ExceptionMessages.ExceptionOwner);
            }
            if (string.IsNullOrEmpty(description))
            {
                throw new Exception(ExceptionMessages.ExceptionDescription);
            }
            if (amount <= 0)
            {
                throw new Exception(ExceptionMessages.ExceptionAmount);
            }
            if (string.IsNullOrEmpty(currency))
            {
                throw new Exception(ExceptionMessages.ExceptionCurrency);
            }

            user.AddAccount(description, amount, currency);       

            _repository.Save();
        }

       public void EditUser(User user, string lastName, string firstName, string middleName, DateTime birthday)
       {
            if (user == null)
            {
                throw new Exception(ExceptionMessages.ExceptionOwner);
            }
            if (string.IsNullOrEmpty(lastName))
            {
                throw new Exception(ExceptionMessages.ExceptionLastName);
            }
            if (string.IsNullOrEmpty(firstName))
            {
                throw new Exception(ExceptionMessages.ExceptionFirstName);
            }
            if (string.IsNullOrEmpty(middleName))
            {
                throw new Exception(ExceptionMessages.ExceptionMiddleName);
            }
            if (birthday >= DateTime.Now.AddYears(-14))
            {
                throw new Exception(ExceptionMessages.ExceptionMinimumAge);
            }

            user.EditLastName(lastName);
            user.EditFirstName(firstName);
            user.EditMiddleName(middleName);
            user.EditBirthday(birthday);

            _repository.Save();
        }

        public void EditAccount(Account account, string description, double amount, string currency)
        {
            if (account == null)
            {
                throw new Exception(ExceptionMessages.ExceptionOwner);
            }
            if (string.IsNullOrEmpty(description))
            {
                throw new Exception(ExceptionMessages.ExceptionDescription);
            }
            if (amount <= 0)
            {
                throw new Exception(ExceptionMessages.ExceptionAmount);
            }
            if (string.IsNullOrEmpty(currency))
            {
                throw new Exception(ExceptionMessages.ExceptionCurrency);
            }

            account.EditDescription(description);
            account.EditAmount(amount);
            account.EditCurrency(currency);

            _repository.Save();
        }
    }
}
