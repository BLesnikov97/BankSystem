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
        public class AccountStub : Account
        {
            public AccountStub(User owner, string description, double amount, string currency) : base(owner, description, amount, currency)
            {

            }
            public void EditId()
            {
                Random random = new Random();
                int value = random.Next(0, 99999);

                UserId = value;
                Id = value;
            }
        }

        [Fact]
        public void Attempt_To_Transfer_Constructor_Correct_Value()
        {
            var repository = Substitute.For<IRepository>();

            ServiceTransfer serviceTransfer = new ServiceTransfer(repository);

            Assert.NotNull(serviceTransfer);
        }

        [Fact]
        public void Attempt_To_Transfer_Constructor_Null_Value()
        {
            IRepository repository = null;

            var resultExcaption = Assert.Throws<Exception>(() => new ServiceTransfer(repository));
            Assert.NotNull(resultExcaption);
            Assert.Equal(resultExcaption.Message, ExceptionMessages.ExceptionRepository);
        }

        [Fact]
        public void Attempt_To_Transfer_Correct_Values()
        {   
            var user = Substitute.For<User>();
            var accountFor = new AccountStub(user, "DepositFor", 1000.00D, "RUB");
            accountFor.EditId();
            var accountTo = new AccountStub(user, "DepositTo", 100.00D, "RUB");
            accountTo.EditId();
            var repository = Substitute.For<IRepository>();
            double age = 100.00D;
            ServiceTransfer serviceTransfer = new ServiceTransfer(repository);

            serviceTransfer.Transfer(accountFor, accountTo, age);

            Assert.NotNull(serviceTransfer);
            Assert.NotNull(accountFor);
            Assert.NotNull(accountTo);
            Assert.Equal(accountFor.Amount, 900.00D);
            Assert.Equal(accountTo.Amount, 200.00D);
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
            Assert.Equal(resultExcaption.Message, ExceptionMessages.ExceptionWithdrawal);
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
            Assert.Equal(resultExcaption.Message, ExceptionMessages.ExceptionUp);
        }

        [Fact]
        public void Attempt_To_Transfer_Age_Zero()
        {   
            var accountFor = Substitute.For<Account>();
            var accountTo = Substitute.For<Account>();
            var repository = Substitute.For<IRepository>();
            double age = 0.00D;
            ServiceTransfer serviceTransfer = new ServiceTransfer(repository);

            serviceTransfer.Transfer(accountFor, accountTo, age);

            Assert.NotNull(serviceTransfer);
            Assert.NotNull(accountFor);
            Assert.NotNull(accountTo);
            var resultExcaption = Assert.Throws<Exception>(() => serviceTransfer.Transfer(accountFor, accountTo, age));
            Assert.NotNull(resultExcaption);
            Assert.Equal(resultExcaption.Message, ExceptionMessages.ExceptionMinAmount);
        }

        [Fact]
        public void Attempt_To_Transfer_Age_Negative()
        {
            Account accountFor = Substitute.For<Account>();
            var accountTo = Substitute.For<Account>();
            var repository = Substitute.For<IRepository>();
            double age = -10.00D;
            ServiceTransfer serviceTransfer = new ServiceTransfer(repository);

            serviceTransfer.Transfer(accountFor, accountTo, age);

            Assert.NotNull(serviceTransfer);
            Assert.NotNull(accountFor);
            Assert.NotNull(accountTo);
            var resultExcaption = Assert.Throws<Exception>(() => serviceTransfer.Transfer(accountFor, accountTo, age));
            Assert.NotNull(resultExcaption);
            Assert.Equal(resultExcaption.Message, ExceptionMessages.ExceptionAmount);
        }
    }
}

