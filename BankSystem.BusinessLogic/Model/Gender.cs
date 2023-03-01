using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystem.BusinessLogic.Model
{
    public class Gender
    {
        public Genders GenderResult { get; set; }

        public enum Genders
        {
            Male,
            Female
        }

        public Gender()
        {
            
        }

        public Gender(Genders gender)
        { 
            this.GenderResult = gender;
        }
    }
}
