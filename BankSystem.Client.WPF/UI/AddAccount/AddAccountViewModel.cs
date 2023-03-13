using BankSystem.BusinesLogic.Repositories;
using BankSystem.BusinesLogic.Services;
using BankSystem.BusinessLogic.Model;
using BankSystem.Client.WPF.Util;
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


        public string Error => throw new System.NotImplementedException();

        public string this[string columnName] => throw new System.NotImplementedException();


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
