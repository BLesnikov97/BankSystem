using System;
using BankSystem.Client.WPF.Util;
using BankSystem.BusinesLogic.Services;
using BankSystem.BusinessLogic.Model;
using System.ComponentModel;
using System.Windows.Controls;
using System.Collections.Generic;

namespace BankSystem.Client.WPF.UI.AddUser
{
    public class AddUserViewModel : BaseViewModel, IDataErrorInfo
    {
        private string _lastName;

        private string _firstName;

        private string _middleName;

        private DateTime _birthday;

        private Gender _genders;

        private IService _service;

        protected Dictionary<string, string> ValidationErrors = new Dictionary<string, string>();

        public AddUserViewModel(IService service)
        {
            _service = service;
        }

        public string Error
        {
            get
            {
                if (ValidationErrors.Count > 0)
                {
                    return string.Empty;
                }

                return null;
            }
        }

        public string this[string columnName]
        {
            get
            {
                if (ValidationErrors.ContainsKey(columnName))
                {
                    return ValidationErrors[columnName];
                }

                return null;
            }
        }

        private RelayCommand addUser;

        public RelayCommand AddUser
        {
            get
            {
                return addUser ??
                    (addUser = new RelayCommand(obj =>
                    {
                        Validate();

                        _service.AddUser(LastName, FirstName, MiddleName, Birthday, Gender);   
                    }));
            }
        }


        public string LastName
        {
            get { return _lastName; }
            set
            {
                _lastName = value;
                Validate();
                OnPropertyChanged("");
            }
        }

        public string FirstName
        {
            get { return _firstName; }
            set
            {
                _firstName = value;
                Validate();
                OnPropertyChanged("");
            }
        }

        public string MiddleName
        {
            get { return _middleName; }
            set
            {
                _middleName = value;
                Validate();
                OnPropertyChanged("");
            }
        }

        public DateTime Birthday
        {
            get { return _birthday; }
            set
            {   
                _birthday = value;
                Validate();
                OnPropertyChanged("");
            }
        }

        public Gender Gender
        {
            get { return _genders; }
            set
            {
                _genders = value;
                OnPropertyChanged("Gender");
            }
        }

        private void Validate()
        {
            ValidationErrors.Clear();

            DateTime currentDate = DateTime.Now;

            if (string.IsNullOrWhiteSpace(LastName))
                ValidationErrors.Add(nameof(LastName), "LastName cannot be empty.");
            if (LastName?.Length > 50)
                ValidationErrors.Add(nameof(LastName), "LastName than 50 characters.");
            if (string.IsNullOrWhiteSpace(FirstName))
                ValidationErrors.Add(nameof(FirstName), "FirstName cannot be empty.");
            if (FirstName?.Length > 50)
                ValidationErrors.Add(nameof(FirstName), "FirstName than 50 characters.");
            if (string.IsNullOrWhiteSpace(MiddleName))
                ValidationErrors.Add(nameof(MiddleName), "MiddleName cannot be empty.");
            if (MiddleName?.Length > 50)
                ValidationErrors.Add(nameof(MiddleName), "MiddleName than 50 characters.");
            if (Birthday == null)
                ValidationErrors.Add(nameof(Birthday), "Birthday cannot be empty.");
            if (Birthday > currentDate.AddYears(-100))
                ValidationErrors.Add(nameof(Birthday), "Cannot be more than 100 years old.");

            OnPropertyChanged("");
        }
    }
}
