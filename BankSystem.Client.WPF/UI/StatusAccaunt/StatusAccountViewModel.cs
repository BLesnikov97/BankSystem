using System.Collections.Generic;
using BankSystem.Client.WPF.Util;
using BankSystem.BusinessLogic.Model;
using BankSystem.BusinesLogic.Repositories;

namespace BankSystem.Client.WPF.UI.StatusAccaunt
{
    public class StatusAccountViewModel : BaseViewModel
    {
        private double _сheckСash;

        private Account _selectedAccount;
        private ICollection<Account> _accounts;

        private List<User> _users;
        private User _selectedUser;

        private RelayCommand statusCommand;

        public StatusAccountViewModel(IRepository repository)
        {
            _users = repository.GetUsersList();
        }

        public RelayCommand StatusCommand
        {
            get
            {
                return statusCommand ??
                    (statusCommand = new RelayCommand(user =>
                    {
                        СheckAmount = SelectedAccount.Amount;
                    }));
            }

            set
            {
                
            }
        }
        public ICollection<Account> Accounts
        {
            get { return _accounts; }
            set
            {
                _accounts = value;
                OnPropertyChanged("Accounts");
            }
        }

        public Account SelectedAccount
        {
            get { return _selectedAccount; }
            set
            {
                _selectedAccount = value;
                OnPropertyChanged("SelectedAccount");
            }
        }

        public double СheckAmount
        {
            get { return _сheckСash; }
            set
            {
                _сheckСash = value;
                OnPropertyChanged("СheckAmount");
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
            get 
            {   
                return _selectedUser; 
            }
            set
            {
                _selectedUser = value;
                OnPropertyChanged("SelectedAccount");

                Accounts = SelectedUser.Accounts;
            }
        }
    }
}
