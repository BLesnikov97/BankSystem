using BankSystem.BusinesLogic.Repositories;
using BankSystem.BusinessLogic.Model;

namespace BankSystem.BusinesLogic.Services
{
    public class Service : IService
    {
        private IRepository _repository;

        public Service(IRepository repository)
        {
            _repository = repository;
        }

        public void AddUser(string lastName, string firstName, string middleName, DateTime birthday, Gender gender)
        {
            User user = new User(lastName, firstName, middleName, birthday, gender);

            _repository.CreateUser(user);                        
        }

        public void AddAccount(User user, string description, double amount, string currency)
        {
            user.Accounts.Add(new Account(user, description, amount, currency));         

            _repository.Save();
        }

       public void EditUser(User user, string lastName, string firstName, string middleName, DateTime birthday)
       {
            if (user.IsBlocked == true)
            {
                throw new Exception("User is blocked");
            }
            if (lastName == "")
            {
                throw new Exception("LastName not filled");
            }
            if (firstName == "")
            {
                throw new Exception("FirstName not filled");
            }
            if (middleName == "")
            {
                throw new Exception("MiddleName not filled");
            }
            if (birthday == null)
            {
                throw new Exception("Birthday not filled");
            }


            user.LastName = lastName;
            user.FirstName = firstName;
            user.MiddleName = middleName;
            user.Birthday = birthday.ToUniversalTime();

            _repository.Save();
        }

        public void EditAccount(Account account, string description, double amount, string currency)
        {
            if (account.IsBlocked == true)
            {
                throw new Exception("Account is blocked");
            }
            if (description == "")
            {
                throw new Exception("Description not filled");
            }
            if (amount == null & amount > 0)
            {
                throw new Exception("Amount not filled");
            }
            if (currency == "")
            {
                throw new Exception("Currency not filled");
            }

            account.Description = description;
            account.Amount = amount;
            account.Currency = currency;

            _repository.Save();
        }
    }
}
