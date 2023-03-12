using System;
using BankSystem.Client.WPF.Util;
using BankSystem.BusinesLogic.Services;
using BankSystem.BusinessLogic.Model;

namespace BankSystem.Client.WPF.UI.AddUser
{
    public class AddUserViewModel : BaseViewModel
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
