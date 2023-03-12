using BankSystem.BusinesLogic.Services;
using BankSystem.BusinessLogic.Model;
using BankSystem.Client.WPF.Util;
using System;
using System.Collections.Generic;

namespace BankSystem.Client.WPF.UI.EditUser
{
    public class EditUserViewModel : BaseViewModel
    {
        private List<User> _users;

        private User _selectedUser;

        private string _lastName;

        private string _firstName;

        private string _middleName;

        private DateTime _birthday;

        private Gender _genders;

        private IService _service;

        public EditUserViewModel(IService service)
        {
            _service = service;
        }

        private RelayCommand editUser;

        public RelayCommand EditUser
        {
            get
            {
                return editUser ??
                    (editUser = new RelayCommand(obj =>
                    {
                        _service.EditUser(SelectedUser, LastName, FirstName, MiddleName, Birthday);   
                    }));
            }
        }

        public List<User> Users
        {
            get { return _users; }
            set
            {
                _users = value;
                OnPropertyChanged("Users");
            }
        }

        public User SelectedUser
        {
            get { return _selectedUser; }
            set
            {
                _selectedUser = value;
                OnPropertyChanged("SelectedUser");
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
