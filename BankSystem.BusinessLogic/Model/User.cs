using BankSystem.BusinessLogic.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace BankSystem.BusinessLogic.Model
{
    public class User
    {
        public int Id { get; protected set; }

        public string LastName { get; protected set; }

        public string FirstName { get; protected set; }

        public string MiddleName { get; protected set; }

        public DateTime Birthday { get; protected set; }

        public Gender Gender { get; protected set; }

        public DateTime CreatedDate { get; protected set; }

        public Nullable<DateTime> ModifiedDate { get; protected set; }

        public bool IsBlocked { get; protected set; }

        public ICollection<Account> Accounts { get; protected set; }


        protected User()
        {
            Accounts = new List<Account>();
        }

        public User(string lastName, string firstName, string middleName, DateTime birthday, Gender gender) : this()
        {
            if (string.IsNullOrEmpty(lastName))
            {
                throw new Exception(ExceptionMessages.ExceptionLastName);
            }
            if (string.IsNullOrEmpty(firstName))
            {
                throw new Exception(ExceptionMessages.ExceptionFirstName);
            }
            if (string.IsNullOrEmpty(middleName))
            {
                throw new Exception(ExceptionMessages.ExceptionMiddleName);
            }
            if (birthday >= DateTime.Now.AddYears(-14))
            {
                throw new Exception(ExceptionMessages.ExceptionMinimumAge);
            }

            Random Id = new Random();

            int value = Id.Next(0, 99999);

            this.Id = value;
            this.LastName = lastName;
            this.FirstName = firstName;
            this.MiddleName = middleName;
            this.Birthday = birthday.ToUniversalTime();
            this.Gender = gender;
            this.CreatedDate = DateTime.Now.ToUniversalTime();
            this.ModifiedDate = DateTime.Now.ToUniversalTime();
            this.IsBlocked = false;
        }

        public void AddAccount(string description, double amount, string currency)
        {
            Accounts.Add(new Account(this, description, amount, currency));
        }

        public void EditLastName(string lastName)
        {
            if (IsBlocked)
                throw new Exception(ExceptionMessages.ExceptionUserIsBlocked);

            if (string.IsNullOrEmpty(lastName))
                throw new Exception(ExceptionMessages.ExceptionLastName);

            LastName = lastName;

            ModifiedDate = DateTime.Now.ToUniversalTime();
        }

        public void EditFirstName(string firstName) 
        {
            if (IsBlocked)
                throw new Exception(ExceptionMessages.ExceptionUserIsBlocked);

            if (string.IsNullOrEmpty(firstName))
                throw new Exception(ExceptionMessages.ExceptionFirstName);

            FirstName = firstName;

            ModifiedDate = DateTime.Now.ToUniversalTime();
        }

        public void EditMiddleName(string middleName)
        {
            if (IsBlocked)
                throw new Exception(ExceptionMessages.ExceptionUserIsBlocked);

            if (string.IsNullOrEmpty(middleName))
                throw new Exception(ExceptionMessages.ExceptionMiddleName);

            MiddleName = middleName;

            ModifiedDate = DateTime.Now.ToUniversalTime();
        }

        public void EditBirthday(DateTime birthday)
        {
            if (IsBlocked)
                throw new Exception(ExceptionMessages.ExceptionUserIsBlocked);

            if (birthday >= DateTime.Now.AddYears(-14))
                throw new Exception(ExceptionMessages.ExceptionMinimumAge);

            birthday = birthday;

            ModifiedDate = DateTime.Now.ToUniversalTime();
        }

        public void BlockedUser()
        {
            if (IsBlocked == false)
            {
                IsBlocked = true;

                ModifiedDate = DateTime.Now.ToUniversalTime();
            }
            else
                throw new Exception(ExceptionMessages.ExceptionUserIsBlocked);
        }

        public void DeployUser()
        {
            if (IsBlocked == true)
            {
                IsBlocked = false;

                ModifiedDate = DateTime.Now.ToUniversalTime();
            }
            else
                throw new Exception(ExceptionMessages.ExceptionUserNotBlocked);
        }
    }
}
