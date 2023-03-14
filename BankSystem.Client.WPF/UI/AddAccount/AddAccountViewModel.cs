using BankSystem.BusinesLogic.Repositories;
using BankSystem.BusinesLogic.Services;
using BankSystem.BusinessLogic.Model;
using BankSystem.Client.WPF.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace BankSystem.Client.WPF.UI.AddAccount
{
    public class AddAccountViewModel : BaseViewModel, IDataErrorInfo
    {
        private List<User> _users;

        private User _selectedUser;

        private string _description;

        private double _amount;

        private string _currency;

        private IService _service;

        public AddAccountViewModel(IService serviceRepository, IRepository repository)
        {
            _service = serviceRepository;
            _users = repository.GetUsersList();
        }


        public string Error => string.Empty;

        public string this[string columnName]
        {
            get
            {
                string error = string.Empty;

                switch (columnName)
                {
                    case nameof(Description):
                        if (string.IsNullOrWhiteSpace(Description))
                            error = "Description cannot be empty.";
                        if (Description?.Length > 50)
                            error = "Description than 50 characters.";
                        break;

                    case nameof(Currency):
                        if (string.IsNullOrWhiteSpace(Currency))
                            error = "Currency cannot be empty.";
                        break;
                    case nameof(Amount):
                        if (Convert.ToString(Amount) == null)
                            error = "Amount cannot be empty.";
                        break;
                    case nameof(SelectedUser):
                        if (SelectedUser == null)
                            error = "User cannot be empty.";
                        break;
                }

                return error;
            }
        }


        private RelayCommand addAccount;

        public RelayCommand AddAccount
        {
            get
            {
                return addAccount ??
                    (addAccount = new RelayCommand(obj =>
                    {
                        _service.AddAccount(SelectedUser, Description, Amount, Currency);
                    }));
            }
        }

        public string Description
        {
            get { return _description; }
            set
            {
                _description = value;
                OnPropertyChanged("Description");
            }
        }

        public double Amount
        {
            get { return _amount; }
            set
            {
                _amount = value;
                OnPropertyChanged("Amount");
            }
        }

        public string Currency
        {
            get { return _currency; }
            set
            {
                _currency = value;
                OnPropertyChanged("Currency");
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
    }
}
