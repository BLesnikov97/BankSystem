using BankSystem.BusinesLogic.Repositories;
using BankSystem.BusinesLogic.Services;
using BankSystem.BusinessLogic.Exceptions;
using BankSystem.BusinessLogic.Model;
using NSubstitute;
using Xunit;

namespace BankSystem.UnitTests.ServiceTests
{
    public class ServiceTransferTest
    {
        [Fact]
        public void Attempt_To_Transfer_Constructor_Correct_Value()
        {
            var accountFor = Substitute.For<Account>();
            var accountTo = Substitute.For<Account>();
            var repository = Substitute.For<IRepository>();

            ServiceTransfer serviceTransfer = new ServiceTransfer(repository);

            Assert.NotNull(serviceTransfer);
        }

        [Fact]
        public void Attempt_To_Transfer_Constructor_Null_Value()
        {
            var accountFor = Substitute.For<Account>();
            var accountTo = Substitute.For<Account>();
            IRepository repository = null;

            var resultExcaption = Assert.Throws<Exception>(() => new ServiceTransfer(repository));
            Assert.NotNull(resultExcaption);
            Assert.Equal(resultExcaption.Message, ExceptionMessages.ExceptionRepository);
        }

        [Fact]
        public void Attempt_To_Transfer_Correct_Values()
        {
            var accountFor = Substitute.For<Account>();
            accountFor.Id = 123;
            accountFor.AddAmount(100);
            var accountTo = Substitute.For<Account>();
            accountTo.Id = 124;
            accountTo.AddAmount(100);
            var repository = Substitute.For<IRepository>();
            double age = 10.00D;
            ServiceTransfer serviceTransfer = new ServiceTransfer(repository);

            serviceTransfer.Transfer(accountFor, accountTo, age);

            Assert.NotNull(serviceTransfer);
            Assert.NotNull(accountFor);
            Assert.NotNull(accountTo);
            Assert.Equal(accountFor.Amount, 90.00D);
            Assert.Equal(accountTo.Amount, 110.00D);
        }

        [Fact]
        public void Attempt_To_Transfer_Account_For_Null()
        {
            Account accountFor = null;
            var accountTo = Substitute.For<Account>();
            var repository = Substitute.For<IRepository>();
            double age = 10.00D;
            ServiceTransfer serviceTransfer = new ServiceTransfer(repository);

            Assert.NotNull(serviceTransfer);
            Assert.NotNull(accountTo);
            var resultExcaption = Assert.Throws<Exception>(() => serviceTransfer.Transfer(accountFor, accountTo, age));
            Assert.NotNull(resultExcaption);
            Assert.Equal(resultExcaption.Message, ExceptionMessages.ExceptionNullAccount);
        }

        [Fact]
        public void Attempt_To_Transfer_Account_To_Null()
        {
            Account accountTo = null;
            var accountFor = Substitute.For<Account>();
            var repository = Substitute.For<IRepository>();
            double age = 10.00D;
            ServiceTransfer serviceTransfer = new ServiceTransfer(repository);

            Assert.NotNull(serviceTransfer);
            Assert.NotNull(accountFor);
            var resultExcaption = Assert.Throws<Exception>(() => serviceTransfer.Transfer(accountFor, accountTo, age));
            Assert.NotNull(resultExcaption);
            Assert.Equal(resultExcaption.Message, ExceptionMessages.ExceptionNullAccount);
        }

        public class AccountStub : Account
        {
            public AccountStub(User owner, string description, double amount, string currency) : base (owner, description, amount, currency)
            {
                
            }
            public void EditId(int id)
            {
                UserId = id;
            }
        }

        [Fact]
        public void Attempt_To_Transfer_Age_Zero()
        {   
            var accountFor = Substitute.For<Account>();
            accountFor.Id = 123;
            accountFor.AddAmount(100);
            var accountTo = Substitute.For<Account>();
            accountTo.Id = 124;
            accountTo.AddAmount(100);
            var repository = Substitute.For<IRepository>();
            double age = 0.00D;
            ServiceTransfer serviceTransfer = new ServiceTransfer(repository);

            serviceTransfer.Transfer(accountFor, accountTo, age);

            Assert.NotNull(serviceTransfer);
            Assert.NotNull(accountFor);
            Assert.NotNull(accountTo);
            var resultExcaption = Assert.Throws<Exception>(() => serviceTransfer.Transfer(accountFor, accountTo, age));
            Assert.NotNull(resultExcaption);
            Assert.Equal(resultExcaption.Message, ExceptionMessages.ExceptionInsufficientAmount);
        }

        [Fact]
        public void Attempt_To_Transfer_Age_Negative()
        {
            var accountFor = Substitute.For<Account>();
            accountFor.Id = 123;
            accountFor.AddAmount(100);
            var accountTo = Substitute.For<Account>();
            accountTo.Id = 124;
            accountTo.AddAmount(100);
            var repository = Substitute.For<IRepository>();
            double age = -10.00D;
            ServiceTransfer serviceTransfer = new ServiceTransfer(repository);

            serviceTransfer.Transfer(accountFor, accountTo, age);

            Assert.NotNull(serviceTransfer);
            Assert.NotNull(accountFor);
            Assert.NotNull(accountTo);
            var resultExcaption = Assert.Throws<Exception>(() => serviceTransfer.Transfer(accountFor, accountTo, age));
            Assert.NotNull(resultExcaption);
            Assert.Equal(resultExcaption.Message, ExceptionMessages.ExceptionInsufficientAmount);
        }
    }
}

