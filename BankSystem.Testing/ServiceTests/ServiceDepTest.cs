using BankSystem.BusinesLogic.Repositories;
using BankSystem.BusinesLogic.Services;
using BankSystem.BusinessLogic.Exceptions;
using BankSystem.BusinessLogic.Model;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace BankSystem.UnitTests.ServiceTests
{
    public class ServiceDepTest
    {
        [Fact]
        public void Attempt_To_Dep_Constructor_Correct_Value()
        {
            var repository = Substitute.For<IRepository>();
            var service = Substitute.For<IService>();

            ServiceDep serviceDep = new ServiceDep(repository, service);

            Assert.NotNull(serviceDep);
        }

        [Fact]
        public void Attempt_To_Dep_Constructor_Null_Value_Repository()
        {
            var service = Substitute.For<IService>();
            IRepository repository = null;

            var resultExcaption = Assert.Throws<Exception>(() => new ServiceDep(repository, service));
            Assert.NotNull(resultExcaption);
            Assert.Equal(resultExcaption.Message, ExceptionMessages.ExceptionRepository);
        }

        [Fact]
        public void Attempt_To_Dep_Constructor_Null_Value_Service()
        {
            IService service = null;
            var repository = Substitute.For<IRepository>();

            var resultExcaption = Assert.Throws<Exception>(() => new ServiceDep(repository, service));
            Assert.NotNull(resultExcaption);
            Assert.Equal(resultExcaption.Message, ExceptionMessages.ExceptionService);
        }

        [Fact]
        public void Attempt_To_Dep_Correct_Values()
        {
            var repository = Substitute.For<IRepository>();
            var service = Substitute.For<IService>();
            double amount = 100.00D;
            string currency = "RUB";
            string lastName = "Petrov";
            string firstName = "Petr";
            string middleName = "Petrovich";
            DateTime dateTime = new DateTime(1987, 7, 20);
            Gender genderMale = Gender.Male;
            User user = new User(lastName, firstName, middleName, dateTime, genderMale);
            Account account = new Account(user, "Deposit", amount, currency);
            ServiceDep serviceDep = new ServiceDep(repository, service);
            double fiveProcentDeposit = amount / 100 * 5;

            serviceDep.Dep(user, account);
            repository.Received().Save();
            service.Received().AddAccount(user, ServiceDep.DepositDescription,fiveProcentDeposit , currency);
        }

        [Fact]
        public void Attempt_To_Dep_Null_User()
        {
            var repository = Substitute.For<IRepository>();
            var service = Substitute.For<IService>();
            User user = null;
            var account = Substitute.For<Account>();
            ServiceDep serviceDep = new ServiceDep(repository, service);

            var resultExcaption = Assert.Throws<Exception>(() => serviceDep.Dep(user, account));
            Assert.NotNull(resultExcaption);
            Assert.Equal(resultExcaption.Message, ExceptionMessages.ExceptionNullUser);
        }

        [Fact]
        public void Attempt_To_Dep_Null_Account()
        {
            var repository = Substitute.For<IRepository>();
            var service = Substitute.For<IService>();
            var user = Substitute.For<User>();
            Account account = null;
            ServiceDep serviceDep = new ServiceDep(repository, service);

            var resultExcaption = Assert.Throws<Exception>(() => serviceDep.Dep(user, account));
            Assert.NotNull(resultExcaption);
            Assert.Equal(resultExcaption.Message, ExceptionMessages.ExceptionNullAccount);
        }
    }
}
