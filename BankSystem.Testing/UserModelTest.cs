using BankSystem.BusinessLogic.Model;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace BankSystem.Testing
{
    public class UserModelTest
    {
        [Fact]
        public void Attempt_To_Create_A_User_With_Filled_Fields()
        {
            // arrange 

            string lastName = "Petrov";
            string firstName = "Petr";
            string middleName = "Petrovich";
            DateTime dateTime = new DateTime(1987, 7, 20);
            Gender genderMale = Gender.Male;

            // act

            User addUser = new User(lastName, firstName, middleName, dateTime, genderMale);

            // assert 

            Assert.NotNull(addUser);
        }

        [Fact]   
        
        public void Attempt_To_Create_A_User_Empty_Fields()
        {
            // arrange \ Организация

            string lastName = string.Empty;
            string firstName = string.Empty;
            string middleName = string.Empty;
            DateTime dateTime = new DateTime();
            Gender genderMale = Gender.Male;

            // act \ Действие

            User addUser = new User(lastName, firstName, middleName, dateTime, genderMale);

            // assert \ Утверждение
            
            Assert.NotNull(addUser);
        }

        [Fact]

        public void Attempt_To_Create_A_User_With_An_Empty_LastName()
        {
            // arrange

            string lastName = string.Empty;
            string firstName = "Petr";
            string middleName = "Petrovich";
            DateTime dateTime = new DateTime(1987, 7, 20);
            Gender genderMale = Gender.Male;

            // act

            User addUser = new User(lastName, firstName, middleName, dateTime, genderMale);

            // assert

            Assert.NotNull(addUser);
        }

        [Fact]

        public void Attempt_To_Create_A_User_With_An_Empty_FirstName()
        {
            // arrange

            string lastName = "Petrov";
            string firstName = string.Empty;
            string middleName = "Petrovich";
            DateTime dateTime = new DateTime(1987, 7, 20);
            Gender genderMale = Gender.Male;

            // act

            User addUser = new User(lastName, firstName, middleName, dateTime, genderMale);

            // assert

            Assert.NotNull(addUser);
        }

        [Fact]

        public void Attempt_To_Create_A_User_With_An_Empty_MiddleName()
        {
            // arrange

            string lastName = "Petrov";
            string firstName = "Petr";
            string middleName = string.Empty;
            DateTime dateTime = new DateTime(1987, 7, 20);
            Gender genderMale = Gender.Male;

            // act

            User addUser = new User(lastName, firstName, middleName, dateTime, genderMale);

            // assert

            Assert.NotNull(addUser);
        }

        [Fact]
        public void Attempt_To_Create_An_Account_With_Filled_Fields_Through_The_User_Method()
        {
            // arrange

            string description = "Deposit account";
            double amount = 100.00D;
            string currency = "RUB";
            User user = Substitute.For<User>();

            // act

            user.AddAccount(description, amount, currency);

            // assert

            Assert.Throws<Exception>(() => user.AddAccount(description, amount, currency));
        }

        [Fact]
        public void Attempt_To_Create_An_Account_With_Fields_Filled_In()
        {
            // arrange

            string description = "Deposit account";
            double amount = 100.00D;
            string currency = "RUB";
            Account account = Substitute.For<Account>();
            User user = Substitute.For<User>();

            // act

            account = new Account(user, description, amount, currency);

            // assert

            Assert.NotNull(account);                   
        }

        [Fact]
        public void Attempt_To_Create_An_Account_With_Empty_Fields()
        {
            // arrange

            string description = string.Empty;
            double amount = 0;
            string currency = string.Empty;
            Account account = Substitute.For<Account>();
            User user = Substitute.For<User>();

            // act

            account = new Account(user, description, amount, currency);

            // assert

            Assert.NotNull(account);
        }

        [Fact]
        public void Attempt_To_Fill_Properties_With_Empty_Data()
        {
            // arrange

            string lastName = string.Empty;
            string firstName = string.Empty;
            string middleName = string.Empty;
            DateTime dateTime = new DateTime();
            Gender genderMale = Gender.Male;

            // act


            //assert

            //Assert.Throws<Exception>(() => user.Id = 0);                       
        }

        [Fact]
        public void Attempt_To_Fill_Properties_With_Valid_Data()
        {
            // arrange

            string lastName = "Petrov";
            string firstName = "Petr";
            string middleName = "Petrovich";
            DateTime dateTime = new DateTime(1987, 7, 20);
            Gender genderMale = Gender.Male;

            // act



            //assert

            //Assert.Throws<Exception>(() => user.Id = 0);                       
        }
    }

}
