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

        public string LastName { get; set; }

        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public DateTime Birthday { get; set; }

        public Gender Gender { get; set; }

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
            if (lastName == "")
            {
                throw new Exception(ExceptionMessages.ExceptionLastName);
            }
            if (firstName == "")
            {
                throw new Exception(ExceptionMessages.ExceptionFirstName);
            }
            if (middleName == "")
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
    }
}
