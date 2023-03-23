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
            user.AddAccount(description, amount, currency);       

            _repository.Save();
        }

       public void EditUser(User user, string lastName, string firstName, string middleName, DateTime birthday)
       {
            user.EditLastName(lastName);
            user.EditFirstName(firstName);
            user.EditMiddleName(middleName);
            user.EditBirthday(birthday);

            _repository.Save();
        }

        public void EditAccount(Account account, string description, double amount, string currency)
        {
            account.EditDescription(description);
            account.EditAmount(amount);
            account.EditCurrency(currency);

            _repository.Save();
        }
    }
}
