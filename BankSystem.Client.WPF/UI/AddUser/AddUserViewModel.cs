﻿using System;
using BankSystem.Client.WPF.Util;
using BankSystem.BusinesLogic.Services;
using BankSystem.BusinessLogic.Model;
using System.ComponentModel;

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

        public AddUserViewModel(IService service)
        {
            _service = service;
        }

        public string Error => string.Empty;

        public string this[string columnName]
        {
            get
            {
                string error = string.Empty;

                DateTime currentDate = DateTime.Now;

                switch (columnName)
                {
                    case nameof(LastName):
                        if (string.IsNullOrWhiteSpace(LastName))
                            error = "Description cannot be empty.";
                        if (LastName?.Length > 50)
                            error = "LastName than 50 characters.";
                        break;

                        case nameof(FirstName):
                        if (string.IsNullOrWhiteSpace(FirstName))
                            error = "FirstName cannot be empty.";
                        if (FirstName?.Length > 50)
                            error = "FirstName than 50 characters.";
                        break;

                        case nameof(MiddleName):
                        if (string.IsNullOrWhiteSpace(MiddleName))
                            error = "MiddleName cannot be empty.";
                        if (MiddleName?.Length > 50)
                            error = "MiddleName than 50 characters.";
                        break;

                    case nameof(Birthday):
                        if (Birthday == null)
                            error = "Birthday cannot be empty.";
                        if (Birthday > currentDate.AddYears(-100))
                            error = "Cannot be more than 100 years old.";
                        break;
                }

                return error;
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
                OnPropertyChanged("LastName");
            }
        }

        public string FirstName
        {
            get { return _firstName; }
            set
            {
                _firstName = value;
                OnPropertyChanged("FirstName");
            }
        }

        public string MiddleName
        {
            get { return _middleName; }
            set
            {
                _middleName = value;
                OnPropertyChanged("MiddleName");
            }
        }

        public DateTime Birthday
        {
            get { return _birthday; }
            set
            {   
                _birthday = value;
                OnPropertyChanged("Birthday");
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
    }
}
