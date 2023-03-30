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

            Assert.NotNull(user);
            Assert.True(user.LastName == lastName);
            Assert.True(user.FirstName == firstName);
            Assert.True(user.MiddleName == middleName);
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

            Assert.NotNull(user.Accounts);
            Assert.NotNull(user.Accounts.FirstOrDefault(x => x.Description == description));
            Assert.NotNull(user.Accounts.FirstOrDefault(x => x.Amount == amount));
            Assert.NotNull(user.Accounts.FirstOrDefault(x => x.Currency == currency));
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

            Assert.NotNull(account);
            Assert.True(account.Description == description);
            Assert.True(account.Amount == amount);
            Assert.True(account.Currency == currency);
        }
    }
}
