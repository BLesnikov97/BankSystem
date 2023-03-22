﻿using BankSystem.BusinessLogic.Exceptions;
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
            // arrange \ Организация

            string lastName = "Petrov";
            string firstName = "Petr";
            string middleName = "Petrovich";
            DateTime dateTime = new DateTime(1987, 7, 20);
            Gender genderMale = Gender.Male;

            // act \ Действие

            User addUser = new User(lastName, firstName, middleName, dateTime, genderMale);

            // assert \ Утверждение

            Assert.Equal(addUser.LastName, lastName);
            Assert.Equal(addUser.FirstName, firstName);
            Assert.Equal(addUser.MiddleName, middleName);
        }

        [Fact]   
        
        public void Attempt_To_Create_A_User_Empty_LastName()
        {
            // arrange

            string lastName = string.Empty;
            string firstName = "Petr";
            string middleName = "Petrovich";
            DateTime dateTime = new DateTime();
            Gender genderMale = Gender.Male;

            // act

            // assert
            
            var resultExcaption = Assert.Throws<Exception>(() => new User(lastName, firstName, middleName, dateTime, genderMale));
            Assert.NotNull(resultExcaption);
            Assert.Equal(resultExcaption.Message,ExceptionMessages.ExceptionLastName);
        }

        [Fact]

        public void Attempt_To_Create_A_User_Empty_FirstName()
        {
            // arrange

            string lastName = "Petrov";
            string firstName = string.Empty;
            string middleName = "Petrovich";
            DateTime dateTime = new DateTime();
            Gender genderMale = Gender.Male;

            // act

            // assert

            var resultExcaption = Assert.Throws<Exception>(() => new User(lastName, firstName, middleName, dateTime, genderMale));
            Assert.NotNull(resultExcaption);
            Assert.Equal(resultExcaption.Message, ExceptionMessages.ExceptionFirstName);
        }

        [Fact]

        public void Attempt_To_Create_A_User_Empty_MiddleName()
        {
            // arrange

            string lastName = "Petrov";
            string firstName = "Petr";
            string middleName = string.Empty;
            DateTime dateTime = new DateTime();
            Gender genderMale = Gender.Male;

            // act

            // assert

            var resultExcaption = Assert.Throws<Exception>(() => new User(lastName, firstName, middleName, dateTime, genderMale));
            Assert.NotNull(resultExcaption);
            Assert.Equal(resultExcaption.Message, ExceptionMessages.ExceptionMiddleName);
        }

        [Fact]

        public void Attempt_To_Create_A_User_Minimum_Age()
        {
            // arrange

            string lastName = string.Empty;
            string firstName = string.Empty;
            string middleName = string.Empty;
            DateTime dateTime = DateTime.Now.AddYears(-13);
            Gender genderMale = Gender.Male;

            // act

            // assert

            var resultExcaption = Assert.Throws<Exception>(() => new User(lastName, firstName, middleName, dateTime, genderMale));
            Assert.NotNull(resultExcaption);
            Assert.Equal(resultExcaption.Message, ExceptionMessages.ExceptionMinimumAge);
        }

        [Fact]
        public void Attempt_To_Create_An_Account_With_Filled_Fields_Through_The_User_Method()
        {
            // arrange

            string description = "Deposit account";
            double amount = 100.00D;
            string currency = "RUB";
            string lastName = "Petrov";
            string firstName = "Petr";
            string middleName = string.Empty;
            DateTime dateTime = new DateTime(1987, 7, 20);
            Gender genderMale = Gender.Male;
            User addUser = new User(lastName, firstName, middleName, dateTime, genderMale);

            // act

            addUser.AddAccount(description, amount, currency);
            var resultUser = addUser.Accounts.FirstOrDefault();
            // assert

            Assert.NotEmpty(addUser.Accounts);
            Assert.Equal(resultUser.Description, description);
            Assert.Equal(resultUser.Amount, amount);
            Assert.Equal(resultUser.Currency, currency);
        }

        [Fact]
        public void Attempt_To_Create_An_Account_With_Fields_Filled_In()
        {
            // arrange

            string description = "Deposit account";
            double amount = 100.00D;
            string currency = "RUB";          
            string lastName = "Petrov";
            string firstName = "Petr";
            string middleName = string.Empty;
            DateTime dateTime = new DateTime(1987, 7, 20);
            Gender genderMale = Gender.Male;

            User user = new User(lastName, firstName, middleName, dateTime, genderMale);

            Account account = Substitute.For<Account>();

            // act

            account = new Account(user, description, amount, currency);

            // assert

            Assert.NotNull(account);
            Assert.Equal(account.Description, description);
            Assert.Equal(account.Amount, amount);
            Assert.Equal(account.Currency, currency);
        }

        [Fact]
        public void Attempt_To_Create_An_Account_With_Empty_Description()
        {
            // arrange

            string description = string.Empty;
            double amount = 0;
            string currency = "RUB";
            string lastName = "Petrov";
            string firstName = "Petr";
            string middleName = string.Empty;
            DateTime dateTime = new DateTime(1987, 7, 20);
            Gender genderMale = Gender.Male;

            User user = new User(lastName, firstName, middleName, dateTime, genderMale);
            Account account = Substitute.For<Account>();

            // act

            // assert

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
            string lastName = "Petrov";
            string firstName = "Petr";
            string middleName = string.Empty;
            DateTime dateTime = new DateTime(1987, 7, 20);
            Gender genderMale = Gender.Male;

            User user = new User(lastName, firstName, middleName, dateTime, genderMale);
            Account account = Substitute.For<Account>();

            // act

            // assert

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
            string lastName = "Petrov";
            string firstName = "Petr";
            string middleName = string.Empty;
            DateTime dateTime = new DateTime(1987, 7, 20);
            Gender genderMale = Gender.Male;

            User user = new User(lastName, firstName, middleName, dateTime, genderMale);
            Account account = Substitute.For<Account>();

            // act

            // assert

            var resultExcaption = Assert.Throws<Exception>(() => new Account(user, description, amount, currency));
            Assert.NotNull(resultExcaption);
            Assert.Equal(resultExcaption.Message, ExceptionMessages.ExceptionCurrency);
        }
    }

}