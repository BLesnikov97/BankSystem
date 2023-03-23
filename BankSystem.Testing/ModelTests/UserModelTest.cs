using BankSystem.BusinessLogic.Exceptions;
using BankSystem.BusinessLogic.Model;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace BankSystem.UnitTests.ModelTests
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
            Assert.Equal(addUser.Birthday, dateTime);
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
            Assert.Equal(resultExcaption.Message, ExceptionMessages.ExceptionLastName);
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

            string lastName = "Petrov";
            string firstName = "Petr";
            string middleName = "Petrovich";
            DateTime dateTime = DateTime.Now.AddYears(-13);
            Gender genderMale = Gender.Male;

            // act

            // assert

            var resultExcaption = Assert.Throws<Exception>(() => new User(lastName, firstName, middleName, dateTime, genderMale));
            Assert.NotNull(resultExcaption);
            Assert.Equal(resultExcaption.Message, ExceptionMessages.ExceptionMinimumAge);
        }

        [Fact]
        public void Attempt_To_Edit_LastName_Is_Blocked_User()
        {
            string lastName = "Petrov";
            string editLastName = "Popov";
            string firstName = "Petr";
            string middleName = "Petrovich";
            DateTime dateTime = new DateTime(1987, 7, 20);
            Gender genderMale = Gender.Male;

            User user = new User(lastName, firstName, middleName, dateTime, genderMale);
            user.BlockedUser();

            var resultExcaption = Assert.Throws<Exception>(() => user.EditLastName(editLastName));
            Assert.NotNull(resultExcaption);
            Assert.Equal(resultExcaption.Message, ExceptionMessages.ExceptionUserIsBlocked);
        }

        [Fact]
        public void Attempt_To_Edit_LastName_With_Value_Null()
        {
            string lastName = "Petrov";
            string editLastName = null;
            string firstName = "Petr";
            string middleName = "Petrovich";
            DateTime dateTime = new DateTime(1987, 7, 20);
            Gender genderMale = Gender.Male;

            User user = new User(lastName, firstName, middleName, dateTime, genderMale);

            var resultExcaption = Assert.Throws<Exception>(() => user.EditLastName(editLastName));
            Assert.NotNull(resultExcaption);
            Assert.Equal(resultExcaption.Message, ExceptionMessages.ExceptionLastName);
        }

        [Fact]
        public void Attempt_To_Edit_LastName_With_Value_Empty()
        {
            string lastName = "Petrov";
            string editLastName = string.Empty;
            string firstName = "Petr";
            string middleName = "Petrovich";
            DateTime dateTime = new DateTime(1987, 7, 20);
            Gender genderMale = Gender.Male;

            User user = new User(lastName, firstName, middleName, dateTime, genderMale);

            var resultExcaption = Assert.Throws<Exception>(() => user.EditLastName(editLastName));
            Assert.NotNull(resultExcaption);
            Assert.Equal(resultExcaption.Message, ExceptionMessages.ExceptionLastName);
        }

        [Fact]
        public void Attempt_To_Edit_LastName_With_Value_Normal()
        {
            string lastName = "Petrov";
            string editLastName = "Popov";
            string firstName = "Petr";
            string middleName = "Petrovich";
            DateTime dateTime = new DateTime(1987, 7, 20);
            Gender genderMale = Gender.Male;

            User user = new User(lastName, firstName, middleName, dateTime, genderMale);
            user.EditLastName(editLastName);

            Assert.Equal(user.LastName, editLastName);
            Assert.Equal(user.FirstName, firstName);
            Assert.Equal(user.MiddleName, middleName);
            Assert.Equal(user.Birthday, dateTime);
        }

        [Fact]
        public void Attempt_To_Edit_LastName_With_Value_Normal_With_ModifiedDate()
        {
            string lastName = "Petrov";
            string editLastName = "Popov";
            string firstName = "Petr";
            string middleName = "Petrovich";
            DateTime dateTime = new DateTime(1987, 7, 20);
            Gender genderMale = Gender.Male;

            User user = new User(lastName, firstName, middleName, dateTime, genderMale);
            user.EditLastName(editLastName);

            Assert.Equal(user.LastName, editLastName);
            Assert.Equal(user.FirstName, firstName);
            Assert.Equal(user.MiddleName, middleName);
            Assert.Equal(user.Birthday, dateTime);
            Assert.NotEqual(user.CreatedDate, user.ModifiedDate);
        }

        [Fact]
        public void Attempt_To_Edit_FirstName_Is_Blocked_User()
        {
            string lastName = "Petrov";
            string editfirstName = "Andrey";
            string firstName = "Petr";
            string middleName = "Petrovich";
            DateTime dateTime = new DateTime(1987, 7, 20);
            Gender genderMale = Gender.Male;

            User user = new User(lastName, firstName, middleName, dateTime, genderMale);
            user.BlockedUser();

            var resultExcaption = Assert.Throws<Exception>(() => user.EditFirstName(editfirstName));
            Assert.NotNull(resultExcaption);
            Assert.Equal(resultExcaption.Message, ExceptionMessages.ExceptionUserIsBlocked);
        }

        [Fact]
        public void Attempt_To_Edit_MiddleName_Is_Blocked_User()
        {
            string lastName = "Petrov";
            string editMiddleName = "Andreyevich";
            string firstName = "Petr";
            string middleName = "Petrovich";
            DateTime dateTime = new DateTime(1987, 7, 20);
            Gender genderMale = Gender.Male;

            User user = new User(lastName, firstName, middleName, dateTime, genderMale);
            user.BlockedUser();

            var resultExcaption = Assert.Throws<Exception>(() => user.EditMiddleName(editMiddleName));
            Assert.NotNull(resultExcaption);
            Assert.Equal(resultExcaption.Message, ExceptionMessages.ExceptionUserIsBlocked);
        }

        [Fact]
        public void Attempt_To_Edit_FirstName_With_Value_Null()
        {
            string lastName = "Petrov";
            string editFirstName = null;
            string firstName = "Petr";
            string middleName = "Petrovich";
            DateTime dateTime = new DateTime(1987, 7, 20);
            Gender genderMale = Gender.Male;

            User user = new User(lastName, firstName, middleName, dateTime, genderMale);

            var resultExcaption = Assert.Throws<Exception>(() => user.EditFirstName(editFirstName));
            Assert.NotNull(resultExcaption);
            Assert.Equal(resultExcaption.Message, ExceptionMessages.ExceptionFirstName);
        }

        [Fact]
        public void Attempt_To_Edit_MiddleName_With_Value_Null()
        {
            string lastName = "Petrov";
            string editMiddleName = null;
            string firstName = "Petr";
            string middleName = "Petrovich";
            DateTime dateTime = new DateTime(1987, 7, 20);
            Gender genderMale = Gender.Male;

            User user = new User(lastName, firstName, middleName, dateTime, genderMale);

            var resultExcaption = Assert.Throws<Exception>(() => user.EditMiddleName(editMiddleName));
            Assert.NotNull(resultExcaption);
            Assert.Equal(resultExcaption.Message, ExceptionMessages.ExceptionMiddleName);
        }

        [Fact]
        public void Attempt_To_Edit_FirstName_With_Value_Normal()
        {
            string lastName = "Petrov";
            string editFirstName = "Andrey";
            string firstName = "Petr";
            string middleName = "Petrovich";
            DateTime dateTime = new DateTime(1987, 7, 20);
            Gender genderMale = Gender.Male;

            User user = new User(lastName, firstName, middleName, dateTime, genderMale);
            user.EditFirstName(editFirstName);

            Assert.Equal(user.LastName, lastName);
            Assert.Equal(user.FirstName, editFirstName);
            Assert.Equal(user.MiddleName, middleName);
            Assert.Equal(user.Birthday, dateTime);
        }

        [Fact]
        public void Attempt_To_Edit_MiddleName_With_Value_Normal()
        {
            string lastName = "Petrov";
            string editMiddleName = "Andreevich";
            string firstName = "Petr";
            string middleName = "Petrovich";
            DateTime dateTime = new DateTime(1987, 7, 20);
            Gender genderMale = Gender.Male;

            User user = new User(lastName, firstName, middleName, dateTime, genderMale);
            user.EditMiddleName(editMiddleName);

            Assert.Equal(user.LastName, lastName);
            Assert.Equal(user.FirstName, firstName);
            Assert.Equal(user.MiddleName, editMiddleName);
            Assert.Equal(user.Birthday, dateTime);
        }
    }

}
