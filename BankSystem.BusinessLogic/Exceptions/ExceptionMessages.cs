using BankSystem.BusinessLogic.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace BankSystem.BusinessLogic.Exceptions
{
    public class ExceptionMessages
    {
        //Exception_User
        public const string ExceptionLastName = "LastName not filled";
        public const string ExceptionFirstName = "FirstName not filled";
        public const string ExceptionMiddleName = "MiddleName not filled";
        public const string ExceptionMinimumAge = "Age under 14";
        public const string ExceptionUserIsBlocked = "User is blocked";
        public const string ExceptionUserNotBlocked = "User is not blocked";
        public const string ExceptionNullUser = "User is empty";

        //Exception_Account
        public const string ExceptionDescription = "Description not filled";
        public const string ExceptionAmount = "Amount not filled";
        public const string ExceptionCurrency = "Currency not filled";
        public const string ExceptionOwner = "Owner is empty";
        public const string ExceptionInsufficientAmount = "Not the correctness of the completed accounts or the amount";
        public const string ExceptionAccountIsBlocked = "Account is blocked";
        public const string ExceptionAccountNotBlocked = "Account is not blocked";
        public const string ExceptionNullAccount = "Account is empty";

        //Exception_Service
        public const string ExceptionRepository = "No connect repository";
        public const string ExceptionService = "No connect service";
        public const string ExceptionUserAndAccount = "User or account not value";
        public const string ExceptionMinAmount = "Transfer amount not set or less than zero";
        public const string ExceptionAccounts = "Same accounts";
        public const string ExceptionWithdrawal = "Withdrawal account not set";
        public const string ExceptionUp = "Top up account not set";
    }
}
