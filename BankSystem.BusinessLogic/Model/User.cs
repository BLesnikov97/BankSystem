using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystem.BusinessLogic.Model
{
    public class User
    {
        public int Id { get; set; }

        public string LastName { get; set; }

        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public DateTime Birthday { get; set; }

        public Genders Gender { get; set; }

        public DateTime CreatedDate { get; set; }

        public Nullable<DateTime> ModifiedDate { get; set; }

        public bool IsBlocked { get; set; }

        public enum Genders
        {
            male,
            female
        }

        public User()
        {

        }

        public User(string LastName, string FirstName, string MiddleName, DateTime Birthday, Genders Gender)
        {
            Random Id = new Random();

            int value = Id.Next(0, 99999);

            this.Id = value;
            this.LastName = LastName;
            this.FirstName = FirstName;
            this.MiddleName = MiddleName;
            this.Birthday = Birthday;
            this.Gender = Gender;
            this.CreatedDate = DateTime.Now;
            this.ModifiedDate = null;
            this.IsBlocked = false;

        }
    }
}
