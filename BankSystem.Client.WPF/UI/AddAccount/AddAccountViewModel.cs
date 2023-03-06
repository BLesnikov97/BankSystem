using BankSystem.BusinesLogic.BaseConnect;
using BankSystem.BusinesLogic.Services;
using BankSystem.BusinessLogic.Model;
using BankSystem.Client.WPF.Util;
using System.Collections.Generic;

namespace BankSystem.Client.WPF.UI.AddAccount
{
    public class AddAccountViewModel : BaseViewModel
    {
        private List<User> _usersId;

        private User _selectedUserId;

        private string _description;

        private double _amount;

        private string _currency;

        private IServiceRepository _service;

        private IRepository _db;

        public AddAccountViewModel(IServiceRepository serviceRepository, IRepository repository)
        {
            _service = serviceRepository;
            _db = repository;
            _usersId = _db.GetUsersList();
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
                        _db.Save();
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
            get { return _usersId; }
            set
            {
                _usersId = value;
                OnPropertyChanged("Users");
            }
        }

        public User SelectedUser
        {
            get { return _selectedUserId; }
            set
            {
                _selectedUserId = value;
                OnPropertyChanged("SelectedUser");
            }
        }
    }
}
