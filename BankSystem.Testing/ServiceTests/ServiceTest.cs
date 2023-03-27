using BankSystem.BusinesLogic.Repositories;
using BankSystem.BusinesLogic.Services;
using BankSystem.BusinessLogic.Exceptions;
using BankSystem.BusinessLogic.Model;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace BankSystem.UnitTests.ServiceTests
{
    public class ServiceTest
    {
        [Fact]
        public void Attempt_To_Service_Constructor_Correct_Value()
        {
            var repository = Substitute.For<IRepository>();
            Service service = new Service(repository);

            Assert.NotNull(service);
        }

        [Fact]
        public void Attempt_To_Service_Constructor_Null_Value()
        {
            IRepository repository = null;

            var resultExcaption = Assert.Throws<Exception>(() => new Service(repository));
            Assert.NotNull(resultExcaption);
            Assert.Equal(resultExcaption.Message, ExceptionMessages.ExceptionRepository);
        }

        [Fact]
        public void Attempt_To_Service_AddUser_Correct_Value()
        {
            string lastName = "Petrov";
            string firstName = "Petr";
            string middleName = "Petrovich";
            DateTime dateTime = new DateTime(1987, 7, 20);
            Gender genderMale = Gender.Male;
            var repository = Substitute.For<IRepository>();
            Service service = new Service(repository);

            service.AddUser(lastName, firstName, middleName, dateTime, genderMale);
        }

        [Fact]
        public void Attempt_To_Service_EditUser_Correct_Value()
        {
            string lastName = "Petrov";
            string firstName = "Petr";
            string middleName = "Petrovich";
            DateTime dateTime = new DateTime(1987, 7, 20);
            var user = Substitute.For<User>();
            var repository = Substitute.For<IRepository>();
            Service service = new Service(repository);

            service.EditUser(user, lastName, firstName, middleName, dateTime);
        }

        [Fact]
        public void Attempt_To_Service_AddAccount_Correct_Value()
        {
            var user = Substitute.For<User>();
            string description = "Deposit account";
            double amount = 100.00D;
            string currency = "RUB";
            var repository = Substitute.For<IRepository>();
            Service service = new Service(repository);

            service.AddAccount(user, description, amount, currency);
        }

        [Fact]
        public void Attempt_To_Service_EditAccount_Correct_Value()
        {
            var account = Substitute.For<Account>();
            string description = "Deposit account";
            double amount = 100.00D;
            string currency = "RUB";
            var repository = Substitute.For<IRepository>();
            Service service = new Service(repository);

            service.EditAccount(account, description, amount, currency);
        }

        [Fact]
        public void Attempt_To_Service_AddUser_Empty_LastName()
        {
            string lastName = string.Empty;
            string firstName = "Petr";
            string middleName = "Petrovich";
            DateTime dateTime = new DateTime(1987, 7, 20);
            Gender genderMale = Gender.Male;
            var repository = Substitute.For<IRepository>();
            Service service = new Service(repository);

            var resultExcaption = Assert.Throws<Exception>(() => service.AddUser(lastName, firstName, middleName, dateTime, genderMale));
            Assert.NotNull(resultExcaption);
            Assert.Equal(resultExcaption.Message, ExceptionMessages.ExceptionLastName);
        }

        [Fact]
        public void Attempt_To_Service_AddUser_Null_LastName()
        {
            string lastName = null;
            string firstName = "Petr";
            string middleName = "Petrovich";
            DateTime dateTime = new DateTime(1987, 7, 20);
            Gender genderMale = Gender.Male;
            var repository = Substitute.For<IRepository>();
            Service service = new Service(repository);

            var resultExcaption = Assert.Throws<Exception>(() => service.AddUser(lastName, firstName, middleName, dateTime, genderMale));
            Assert.NotNull(resultExcaption);
            Assert.Equal(resultExcaption.Message, ExceptionMessages.ExceptionLastName);
        }

        [Fact]
        public void Attempt_To_Service_AddUser_Empty_FirstName()
        {
            string lastName = "Andreyevich";
            string firstName = string.Empty;
            string middleName = "Petrovich";
            DateTime dateTime = new DateTime(1987, 7, 20);
            Gender genderMale = Gender.Male;
            var repository = Substitute.For<IRepository>();
            Service service = new Service(repository);

            var resultExcaption = Assert.Throws<Exception>(() => service.AddUser(lastName, firstName, middleName, dateTime, genderMale));
            Assert.NotNull(resultExcaption);
            Assert.Equal(resultExcaption.Message, ExceptionMessages.ExceptionFirstName);
        }

        [Fact]
        public void Attempt_To_Service_AddUser_Null_FirstName()
        {
            string lastName = "Andreyevich";
            string firstName = null;
            string middleName = "Petrovich";
            DateTime dateTime = new DateTime(1987, 7, 20);
            Gender genderMale = Gender.Male;
            var repository = Substitute.For<IRepository>();
            Service service = new Service(repository);

            var resultExcaption = Assert.Throws<Exception>(() => service.AddUser(lastName, firstName, middleName, dateTime, genderMale));
            Assert.NotNull(resultExcaption);
            Assert.Equal(resultExcaption.Message, ExceptionMessages.ExceptionFirstName);
        }

        [Fact]
        public void Attempt_To_Service_AddUser_Empty_MiddleName()
        {
            string lastName = "Andreyevich";
            string firstName = "Petr";
            string middleName = string.Empty;
            DateTime dateTime = new DateTime(1987, 7, 20);
            Gender genderMale = Gender.Male;
            var repository = Substitute.For<IRepository>();
            Service service = new Service(repository);

            var resultExcaption = Assert.Throws<Exception>(() => service.AddUser(lastName, firstName, middleName, dateTime, genderMale));
            Assert.NotNull(resultExcaption);
            Assert.Equal(resultExcaption.Message, ExceptionMessages.ExceptionMiddleName);
        }

        [Fact]
        public void Attempt_To_Service_AddUser_Null_MiddleName()
        {
            string lastName = "Andreyevich";
            string firstName = "Petr";
            string middleName = null;
            DateTime dateTime = new DateTime(1987, 7, 20);
            Gender genderMale = Gender.Male;
            var repository = Substitute.For<IRepository>();
            Service service = new Service(repository);

            var resultExcaption = Assert.Throws<Exception>(() => service.AddUser(lastName, firstName, middleName, dateTime, genderMale));
            Assert.NotNull(resultExcaption);
            Assert.Equal(resultExcaption.Message, ExceptionMessages.ExceptionMiddleName);
        }

        [Fact]
        public void Attempt_To_Service_EditAccount_Empty_Description()
        {
            var account = Substitute.For<Account>();
            string description = string.Empty;
            double amount = 100.00D;
            string currency = "RUB";
            var repository = Substitute.For<IRepository>();
            Service service = new Service(repository);

            var resultExcaption = Assert.Throws<Exception>(() => service.EditAccount(account, description, amount, currency));
            Assert.NotNull(resultExcaption);
            Assert.Equal(resultExcaption.Message, ExceptionMessages.ExceptionDescription);
        }

        [Fact]
        public void Attempt_To_Service_EditAccount_Null_Description()
        {
            var account = Substitute.For<Account>();
            string description = null;
            double amount = 100.00D;
            string currency = "RUB";
            var repository = Substitute.For<IRepository>();
            Service service = new Service(repository);

            var resultExcaption = Assert.Throws<Exception>(() => service.EditAccount(account, description, amount, currency));
            Assert.NotNull(resultExcaption);
            Assert.Equal(resultExcaption.Message, ExceptionMessages.ExceptionDescription);
        }

        [Fact]
        public void Attempt_To_Service_EditAccount_Empty_Amount()
        {
            var account = Substitute.For<Account>();
            string description = "Deposit";
            double amount = 0.00D;
            string currency = "RUB";
            var repository = Substitute.For<IRepository>();
            Service service = new Service(repository);

            var resultExcaption = Assert.Throws<Exception>(() => service.EditAccount(account, description, amount, currency));
            Assert.NotNull(resultExcaption);
            Assert.Equal(resultExcaption.Message, ExceptionMessages.ExceptionAmount);
        }

        [Fact]
        public void Attempt_To_Service_EditAccount_Null_Amount()
        {
            var account = Substitute.For<Account>();
            string description = "Deposit";
            double amount = -10.00D;
            string currency = "RUB";
            var repository = Substitute.For<IRepository>();
            Service service = new Service(repository);

            var resultExcaption = Assert.Throws<Exception>(() => service.EditAccount(account, description, amount, currency));
            Assert.NotNull(resultExcaption);
            Assert.Equal(resultExcaption.Message, ExceptionMessages.ExceptionAmount);
        }

        [Fact]
        public void Attempt_To_Service_EditAccount_Empty_Currency()
        {
            var account = Substitute.For<Account>();
            string description = "Deposit";
            double amount = 0.00D;
            string currency = string.Empty;
            var repository = Substitute.For<IRepository>();
            Service service = new Service(repository);

            var resultExcaption = Assert.Throws<Exception>(() => service.EditAccount(account, description, amount, currency));
            Assert.NotNull(resultExcaption);
            Assert.Equal(resultExcaption.Message, ExceptionMessages.ExceptionCurrency);
        }

        [Fact]
        public void Attempt_To_Service_EditAccount_Null_Currency()
        {
            var account = Substitute.For<Account>();
            string description = "Deposit";
            double amount = -10.00D;
            string currency = null;
            var repository = Substitute.For<IRepository>();
            Service service = new Service(repository);

            var resultExcaption = Assert.Throws<Exception>(() => service.EditAccount(account, description, amount, currency));
            Assert.NotNull(resultExcaption);
            Assert.Equal(resultExcaption.Message, ExceptionMessages.ExceptionCurrency);
        }

        [Fact]
        public void Attempt_To_Service_EditAccount_Null_Account()
        {
            Account account = null;
            string description = "Deposit";
            double amount = -10.00D;
            string currency = "RUB";
            var repository = Substitute.For<IRepository>();
            Service service = new Service(repository);

            var resultExcaption = Assert.Throws<Exception>(() => service.EditAccount(account, description, amount, currency));
            Assert.NotNull(resultExcaption);
            Assert.Equal(resultExcaption.Message, ExceptionMessages.ExceptionOwner);
        }

        [Fact]
        public void Attempt_To_Service_EditUser_User_Null()
        {
            string lastName = "Petrov";
            string firstName = "Petr";
            string middleName = "Petrovich";
            DateTime dateTime = new DateTime(1987, 7, 20);
            User user = null;
            var repository = Substitute.For<IRepository>();
            Service service = new Service(repository);

            var resultExcaption = Assert.Throws<Exception>(() => service.EditUser(user, lastName, firstName, middleName, dateTime));
            Assert.NotNull(resultExcaption);
            Assert.Equal(resultExcaption.Message, ExceptionMessages.ExceptionOwner);
        }

        [Fact]
        public void Attempt_To_Service_EditUser_LastName_Null()
        {
            string lastName = null;
            string firstName = "Petr";
            string middleName = "Petrovich";
            DateTime dateTime = new DateTime(1987, 7, 20);
            User user = null;
            var repository = Substitute.For<IRepository>();
            Service service = new Service(repository);

            var resultExcaption = Assert.Throws<Exception>(() => service.EditUser(user, lastName, firstName, middleName, dateTime));
            Assert.NotNull(resultExcaption);
            Assert.Equal(resultExcaption.Message, ExceptionMessages.ExceptionLastName);
        }

        [Fact]
        public void Attempt_To_Service_EditUser_LastName_Empty()
        {
            string lastName = string.Empty;
            string firstName = "Petr";
            string middleName = "Petrovich";
            DateTime dateTime = new DateTime(1987, 7, 20);
            User user = null;
            var repository = Substitute.For<IRepository>();
            Service service = new Service(repository);

            var resultExcaption = Assert.Throws<Exception>(() => service.EditUser(user, lastName, firstName, middleName, dateTime));
            Assert.NotNull(resultExcaption);
            Assert.Equal(resultExcaption.Message, ExceptionMessages.ExceptionLastName);
        }
 
        [Fact]
        public void Attempt_To_Service_EditUser_FirstName_Null()
        {
            string lastName = "Petrov";
            string firstName = null;
            string middleName = "Petrovich";
            DateTime dateTime = new DateTime(1987, 7, 20);
            User user = null;
            var repository = Substitute.For<IRepository>();
            Service service = new Service(repository);

            var resultExcaption = Assert.Throws<Exception>(() => service.EditUser(user, lastName, firstName, middleName, dateTime));
            Assert.NotNull(resultExcaption);
            Assert.Equal(resultExcaption.Message, ExceptionMessages.ExceptionFirstName);
        }

        [Fact]
        public void Attempt_To_Service_EditUser_FirstName_Empty()
        {
            string lastName = "Petrov";
            string firstName = string.Empty;
            string middleName = "Petrovich";
            DateTime dateTime = new DateTime(1987, 7, 20);
            User user = null;
            var repository = Substitute.For<IRepository>();
            Service service = new Service(repository);

            var resultExcaption = Assert.Throws<Exception>(() => service.EditUser(user, lastName, firstName, middleName, dateTime));
            Assert.NotNull(resultExcaption);
            Assert.Equal(resultExcaption.Message, ExceptionMessages.ExceptionFirstName);
        }

        [Fact]
        public void Attempt_To_Service_EditUser_MiddleName_Null()
        {
            string lastName = "Petrov";
            string firstName = "Petr";
            string middleName = null;
            DateTime dateTime = new DateTime(1987, 7, 20);
            User user = null;
            var repository = Substitute.For<IRepository>();
            Service service = new Service(repository);

            var resultExcaption = Assert.Throws<Exception>(() => service.EditUser(user, lastName, firstName, middleName, dateTime));
            Assert.NotNull(resultExcaption);
            Assert.Equal(resultExcaption.Message, ExceptionMessages.ExceptionMiddleName);
        }

        [Fact]
        public void Attempt_To_Service_EditUser_MiddleName_Empty()
        {
            string lastName = "Petrov";
            string firstName = "Petr";
            string middleName = string.Empty;
            DateTime dateTime = new DateTime(1987, 7, 20);
            User user = null;
            var repository = Substitute.For<IRepository>();
            Service service = new Service(repository);

            var resultExcaption = Assert.Throws<Exception>(() => service.EditUser(user, lastName, firstName, middleName, dateTime));
            Assert.NotNull(resultExcaption);
            Assert.Equal(resultExcaption.Message, ExceptionMessages.ExceptionMiddleName);
        }
    }
}
