using BankSystem.BusinessLogic.Exceptions;
using BankSystem.BusinessLogic.Model;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace BankSystem.UnitTests.ModelTests
{
    public class AccountModelTest
    {
        [Fact]
        public void Attempt_To_Create_An_Account_With_Fields_Filled_In()
        {
            string description = "Deposit account";
            double amount = 100.00D;
            string currency = "RUB";
            var user = Substitute.For<User>();

            Account account = new Account(user, description, amount, currency);

            Assert.NotNull(account);
            Assert.Equal(account.Description, description);
            Assert.Equal(account.Amount, amount);
            Assert.Equal(account.Currency, currency);
        }

        [Fact]
        public void Attempt_To_Create_An_Account_With_Filled_Fields_Through_The_User_Method()
        {
            string description = "Deposit account";
            double amount = 100.00D;
            string currency = "RUB";
            var addUser = Substitute.For<User>();

            addUser.AddAccount(description, amount, currency);
            var resultUser = addUser.Accounts.FirstOrDefault();

            Assert.NotNull(resultUser);
            Assert.NotEmpty(addUser.Accounts);
            Assert.Equal(resultUser.Description, description);
            Assert.Equal(resultUser.Amount, amount);
            Assert.Equal(resultUser.Currency, currency);
        }

        [Fact]
        public void Attempt_To_Create_An_Account_With_Empty_Description()
        {
            string description = string.Empty;
            double amount = 100.00D;
            string currency = "RUB";
            var user = Substitute.For<User>();

            var resultExcaption = Assert.Throws<Exception>(() => new Account(user, description, amount, currency));
            Assert.NotNull(resultExcaption);
            Assert.Equal(resultExcaption.Message, ExceptionMessages.ExceptionDescription);
        }

        [Fact]
        public void Attempt_To_Create_An_Account_With_Empty_Amount()
        {
            // arrange

            string description = "Deposit";
            double amount = 0;
            string currency = "RUB";
            var user = Substitute.For<User>();

            var resultExcaption = Assert.Throws<Exception>(() => new Account(user, description, amount, currency));
            Assert.NotNull(resultExcaption);
            Assert.Equal(resultExcaption.Message, ExceptionMessages.ExceptionAmount);
        }

        [Fact]
        public void Attempt_To_Create_An_Account_With_Empty_Currency()
        {
            // arrange

            string description = "Deposit";
            double amount = 100;
            string currency = string.Empty;
            var user = Substitute.For<User>();

            var resultExcaption = Assert.Throws<Exception>(() => new Account(user, description, amount, currency));
            Assert.NotNull(resultExcaption);
            Assert.Equal(resultExcaption.Message, ExceptionMessages.ExceptionCurrency);
        }

        [Fact]
        public void Attempt_To_AddAmount_Correct_value()
        {
            string description = "Deposit";
            double amount = 100.00D;
            string currency = "RUB";
            double age = 100.00D;
            var user = Substitute.For<User>();

            var account = new Account(user, description, amount, currency);            
            account.AddAmount(age);

            Assert.NotNull(account);
            Assert.Equal(account.Description, description);
            Assert.Equal(account.Currency, currency);
            Assert.NotEqual(account.Amount, amount);
        }

        [Fact]
        public void Attempt_To_AddAmount_IsBlocked_True()
        {
            string description = "Deposit";
            double amount = 100.00D;
            string currency = "RUB";
            double age = 100.00D;
            var user = Substitute.For<User>();

            var account = new Account(user, description, amount, currency);
            account.BlockedAccount();

            Assert.NotNull(account);
            Assert.Equal(account.Description, description);
            Assert.Equal(account.Amount, amount);
            Assert.Equal(account.Currency, currency);
            Assert.NotEqual(account.CreatedDate, account.ModifiedDate);
            var resultExcaption = Assert.Throws<Exception>(() => account.AddAmount(age));
            Assert.NotNull(resultExcaption);
            Assert.Equal(resultExcaption.Message, ExceptionMessages.ExceptionAccountIsBlocked);
        }

        [Fact]
        public void Attempt_To_AddAmount_IsSum_Null()
        {
            string description = "Deposit";
            double amount = 100.00D;
            string currency = "RUB";
            double age = 0.00D;
            var user = Substitute.For<User>();

            var account = new Account(user, description, amount, currency);


            var resultExcaption = Assert.Throws<Exception>(() => account.AddAmount(age));
            Assert.NotNull(resultExcaption);
            Assert.Equal(resultExcaption.Message, ExceptionMessages.ExceptionAmount);
        }

        [Fact]
        public void Attempt_To_TakeAmount_Correct_value()
        {
            string description = "Deposit";
            double amount = 100.00D;
            string currency = "RUB";
            double age = 100.00D;
            var user = Substitute.For<User>();

            var account = new Account(user, description, amount, currency);
            account.TakeAmount(age);

            Assert.NotNull(account);
            Assert.Equal(account.Description, description);
            Assert.Equal(account.Currency, currency);
            Assert.NotEqual(account.Amount, amount);
        }

        [Fact]
        public void Attempt_To_TakeAmount_IsBlocked_True()
        {
            string description = "Deposit";
            double amount = 100.00D;
            string currency = "RUB";
            double age = 100.00D;
            var user = Substitute.For<User>();

            var account = new Account(user, description, amount, currency);
            account.BlockedAccount();

            Assert.NotNull(account);
            Assert.Equal(account.Description, description);
            Assert.Equal(account.Amount, amount);
            Assert.Equal(account.Currency, currency);
            Assert.NotEqual(account.CreatedDate, account.ModifiedDate);
            var resultExcaption = Assert.Throws<Exception>(() => account.TakeAmount(age));
            Assert.NotNull(resultExcaption);
            Assert.Equal(resultExcaption.Message, ExceptionMessages.ExceptionAccountIsBlocked);
        }

        [Fact]
        public void Attempt_To_TakeAmount_Is_Value_Null()
        {
            string description = "Deposit";
            double amount = 100.00D;
            string currency = "RUB";
            double age = 0.00D;
            var user = Substitute.For<User>();

            var account = new Account(user, description, amount, currency);


            var resultExcaption = Assert.Throws<Exception>(() => account.TakeAmount(age));
            Assert.NotNull(resultExcaption);
            Assert.Equal(resultExcaption.Message, ExceptionMessages.ExceptionAmount);
        }

        [Fact]
        public void Attempt_To_EditDescription_Correct_value()
        {
            string description = "Deposit";
            double amount = 100.00D;
            string currency = "RUB";
            string editDescription = "Deposit_2";
            var user = Substitute.For<User>();

            var account = new Account(user, description, amount, currency);
            account.EditDescription(editDescription);

            Assert.NotNull(account);
            Assert.Equal(account.Description, editDescription);
            Assert.Equal(account.Currency, currency);
            Assert.Equal(account.Amount, amount);
        }

        [Fact]
        public void Attempt_To_EditDescription_IsBlocked_True()
        {
            string description = "Deposit";
            double amount = 100.00D;
            string currency = "RUB";
            string editDescription = "Deposit_2";
            var user = Substitute.For<User>();

            var account = new Account(user, description, amount, currency);
            account.BlockedAccount();

            Assert.NotNull(account);
            Assert.Equal(account.Description, description);
            Assert.Equal(account.Currency, currency);
            Assert.Equal(account.Amount, amount);
            var resultExcaption = Assert.Throws<Exception>(() => account.EditDescription(editDescription));
            Assert.NotNull(resultExcaption);
            Assert.Equal(resultExcaption.Message, ExceptionMessages.ExceptionAccountIsBlocked);
        }

        [Fact]
        public void Attempt_To_EditDescription_IsValue_Empty()
        {
            string description = "Deposit";
            double amount = 100.00D;
            string currency = "RUB";
            string editDescription = string.Empty;
            var user = Substitute.For<User>();

            var account = new Account(user, description, amount, currency);

            Assert.NotNull(account);
            Assert.Equal(account.Description, description);
            Assert.Equal(account.Currency, currency);
            Assert.Equal(account.Amount, amount);
            var resultExcaption = Assert.Throws<Exception>(() => account.EditDescription(editDescription));
            Assert.NotNull(resultExcaption);
            Assert.Equal(resultExcaption.Message, ExceptionMessages.ExceptionDescription);
        }

        [Fact]
        public void Attempt_To_EditDescription_IsValue_Null()
        {
            string description = "Deposit";
            double amount = 100.00D;
            string currency = "RUB";
            string editDescription = string.Empty;
            var user = Substitute.For<User>();

            var account = new Account(user, description, amount, currency);

            Assert.NotNull(account);
            Assert.Equal(account.Description, description);
            Assert.Equal(account.Currency, currency);
            Assert.Equal(account.Amount, amount);
            var resultExcaption = Assert.Throws<Exception>(() => account.EditDescription(editDescription));
            Assert.NotNull(resultExcaption);
            Assert.Equal(resultExcaption.Message, ExceptionMessages.ExceptionDescription);
        }

        [Fact]
        public void Attempt_To_EditCurrency_Correct_value()
        {
            string description = "Deposit";
            double amount = 100.00D;
            string currency = "RUB";
            string editCurrency = "EUR";
            var user = Substitute.For<User>();

            var account = new Account(user, description, amount, currency);
            account.EditCurrency(editCurrency);

            Assert.NotNull(account);
            Assert.Equal(account.Description, description);
            Assert.Equal(account.Currency, editCurrency);
            Assert.Equal(account.Amount, amount);
        }

        [Fact]
        public void Attempt_To_EditCurrency_IsBlocked_True()
        {
            string description = "Deposit";
            double amount = 100.00D;
            string currency = "RUB";
            string editCurrency = "EUR";
            var user = Substitute.For<User>();

            var account = new Account(user, description, amount, currency);
            account.BlockedAccount();

            Assert.NotNull(account);
            Assert.Equal(account.Description, description);
            Assert.Equal(account.Currency, currency);
            Assert.Equal(account.Amount, amount);
            var resultExcaption = Assert.Throws<Exception>(() => account.EditDescription(editCurrency));
            Assert.NotNull(resultExcaption);
            Assert.Equal(resultExcaption.Message, ExceptionMessages.ExceptionAccountIsBlocked);
        }

        [Fact]
        public void Attempt_To_EditCurrency_IsValue_Empty()
        {
            string description = "Deposit";
            double amount = 100.00D;
            string currency = "RUB";
            string editCurrency = string.Empty;
            var user = Substitute.For<User>();

            var account = new Account(user, description, amount, currency);

            Assert.NotNull(account);
            Assert.Equal(account.Description, description);
            Assert.Equal(account.Currency, currency);
            Assert.Equal(account.Amount, amount);
            var resultExcaption = Assert.Throws<Exception>(() => account.EditCurrency(editCurrency));
            Assert.NotNull(resultExcaption);
            Assert.Equal(resultExcaption.Message, ExceptionMessages.ExceptionCurrency);
        }

        [Fact]
        public void Attempt_To_EditCurrency_IsValue_Null()
        {
            string description = "Deposit";
            double amount = 100.00D;
            string currency = "RUB";
            string editCurrency = string.Empty;
            var user = Substitute.For<User>();

            var account = new Account(user, description, amount, currency);

            Assert.NotNull(account);
            Assert.Equal(account.Description, description);
            Assert.Equal(account.Currency, currency);
            Assert.Equal(account.Amount, amount);
            var resultExcaption = Assert.Throws<Exception>(() => account.EditCurrency(editCurrency));
            Assert.NotNull(resultExcaption);
            Assert.Equal(resultExcaption.Message, ExceptionMessages.ExceptionCurrency);
        }

        [Fact]
        public void Attempt_To_EditAmount_Correct_value()
        {
            string description = "Deposit";
            double amount = 100.00D;
            string currency = "RUB";
            double editAmount = 50.00D;
            var user = Substitute.For<User>();

            var account = new Account(user, description, amount, currency);
            account.EditAmount(editAmount);

            Assert.NotNull(account);
            Assert.Equal(account.Description, description);
            Assert.Equal(account.Currency, currency);
            Assert.Equal(account.Amount, editAmount);
        }

        [Fact]
        public void Attempt_To_EditAmount_Less_Zero_value()
        {
            string description = "Deposit";
            double amount = 100.00D;
            string currency = "RUB";
            double editAmount = -50.00D;
            var user = Substitute.For<User>();

            var account = new Account(user, description, amount, currency);

            Assert.NotNull(account);
            Assert.Equal(account.Description, description);
            Assert.Equal(account.Currency, currency);
            Assert.Equal(account.Amount, amount);
            var resultExcaption = Assert.Throws<Exception>(() => account.EditAmount(editAmount));
            Assert.NotNull(resultExcaption);
            Assert.Equal(resultExcaption.Message, ExceptionMessages.ExceptionAmount);
        }

        [Fact]
        public void Attempt_To_EditAmount_IsBlocked()
        {
            string description = "Deposit";
            double amount = 100.00D;
            string currency = "RUB";
            double editAmount = 50.00D;
            var user = Substitute.For<User>();

            var account = new Account(user, description, amount, currency);
            account.BlockedAccount();

            Assert.NotNull(account);
            Assert.Equal(account.Description, description);
            Assert.Equal(account.Currency, currency);
            Assert.Equal(account.Amount, amount);
            var resultExcaption = Assert.Throws<Exception>(() => account.EditAmount(editAmount));
            Assert.NotNull(resultExcaption);
            Assert.Equal(resultExcaption.Message, ExceptionMessages.ExceptionAccountIsBlocked);
        }
    }
}
