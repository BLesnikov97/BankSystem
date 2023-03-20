using BankSystem.BusinessLogic.Model;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace BankSystem.Testing
{
    public class XUnitTestBusinessLogicModelUser
    {
        public void TestСonstructorAddUserNull()
        {
            // arrange \ Организация

            string lastName = string.Empty;
            string firstName = string.Empty;
            string middleName = string.Empty;
            DateTime dateTime = new DateTime();
            Gender genderMale = Gender.Male;
            User expected = null;

            // act \ Действие

            User addUser = new User(lastName, firstName, middleName, dateTime, genderMale);

            // assert \ Утверждение
            
            Assert.Equal(expected, addUser);
        }

        public void TestСonstructorAddUserNormal()
        {
            // arrange 

            string lastName = "Petrov";
            string firstName = "Petr";
            string middleName = "Petrovich";
            DateTime dateTime = new DateTime(1987, 7, 20);
            Gender genderMale = Gender.Male;
            //User expected = null;                           ??

            // act

            User addUser = new User(lastName, firstName, middleName, dateTime, genderMale);

            // assert 

            //Assert.Equal(expected, addUser);                     ??
        }

        public void TestAddAccountNull()
        {
            // arrange

            string description = string.Empty;
            double amount = 0;
            string currency = string.Empty;
            User user = Substitute.For<User>();
            Account expected = null;

            // act

            Account addAccount = new Account(user,description,amount,currency);

            // assert

            Assert.Equal(expected, addAccount);
        }

        public void TestAddAccountNormal()
        {
            // arrange

            string description = "Deposit account";
            double amount = 100.00D;
            string currency = "RUB";
            User user = Substitute.For<User>();
            //Account expected = null;                             ??

            // act

            Account addAccount = new Account(user, description, amount, currency);

            // assert

            //Assert.Equal(expected, addAccount);                    ??
        }

        public void TestPropertyNull()
        {
            // arrange
            string lastName = string.Empty;
            string firstName = string.Empty;
            string middleName = string.Empty;
            DateTime dateTime = new DateTime();
            Gender genderMale = Gender.Male;

            User user = new User(lastName, firstName, middleName, dateTime, genderMale);

            // act

            user.Id = 0;
            user.LastName = string.Empty;
            user.FirstName = string.Empty;
            user.MiddleName = string.Empty;
            user.Birthday = DateTime.Now;
            user.CreatedDate = DateTime.Now;
            user.ModifiedDate = DateTime.Now;
            user.IsBlocked = false;
            user.Accounts = null;

            //assert

            //Assert.Throws<Exception>(() => user.Id = 0);                       ??
        }

        public void TestPropertyNormal()
        {
            // arrange
            string lastName = "Petrov";
            string firstName = "Petr";
            string middleName = "Petrovich";
            DateTime dateTime = new DateTime(1987, 7, 20);
            Gender genderMale = Gender.Male;

            User user = new User(lastName, firstName, middleName, dateTime, genderMale);

            // act

            user.Id = 94591;
            user.LastName = "Petrov";
            user.FirstName = "Petr";
            user.MiddleName = "Petrovich";
            user.Birthday = dateTime;
            user.CreatedDate = DateTime.Now;
            user.ModifiedDate = DateTime.Now;
            user.IsBlocked = false;
            user.Accounts = null;

            //assert

            //Assert.Throws<Exception>(() => user.Id = 0);                       ??
        }
    }

}
