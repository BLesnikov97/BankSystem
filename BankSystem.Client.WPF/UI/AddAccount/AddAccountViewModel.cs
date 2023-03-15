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

        protected Dictionary<string, string> ValidationErrors = new Dictionary<string, string>();

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

        public AddAccountViewModel(IService serviceRepository, IRepository repository)
        {
            _service = serviceRepository;
            _users = repository.GetUsersList();
        }


        private RelayCommand addAccount;

        public RelayCommand AddAccount
        {
            get
            {
                return addAccount ??
                    (addAccount = new RelayCommand(obj =>
                    {
                        Validate();

                        if(ValidationErrors.Count == 0)
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

                Validate();
                OnPropertyChanged("");
            }
        }

        public double Amount
        {
            get { return _amount; }
            set
            {
                _amount = value;

                Validate();
                OnPropertyChanged("");
            }
        }

        public string Currency
        {
            get { return _currency; }
            set
            {
                _currency = value;

                Validate();
                OnPropertyChanged("");
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

                Validate();
                OnPropertyChanged("");
            }
        }

        private void Validate()
        {
            ValidationErrors.Clear();

            if (string.IsNullOrWhiteSpace(Description))
                ValidationErrors.Add(nameof(Description), "Description cannot be empty.");
            if (Description?.Length > 50)
            ValidationErrors.Add(nameof(Description), "Description than 50 characters.");
            if (string.IsNullOrWhiteSpace(Currency))
                ValidationErrors.Add(nameof(Currency),"Currency cannot be empty.");
            if (Amount <= 0)
                ValidationErrors.Add(nameof(Amount), "Amount cannot be empty or negative.");
            if (SelectedUser == null)
                ValidationErrors.Add(nameof(SelectedUser), "User cannot be empty.");

            OnPropertyChanged("");
        }
    }
}
