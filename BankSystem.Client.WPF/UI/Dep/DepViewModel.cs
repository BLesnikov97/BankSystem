using System.Collections.Generic;
using BankSystem.BusinesLogic.Repositories;
using BankSystem.BusinesLogic.Services;
using BankSystem.BusinessLogic.Model;
using BankSystem.Client.WPF.Util;

namespace BankSystem.Client.WPF.UI.Dep
{
    public class DepViewModel : BaseViewModel
    {
        private User _selectedUser;

        private List<User> _users;

        private ICollection<Account> _accounts;

        private Account _selectedAccount;

        private IServiceDep _dep;

        private RelayCommand depCommand;

        public DepViewModel(IRepository db, IService serviceRepository, IServiceDep dep)
        {
            _dep = dep;
            _users = db.GetUsersList();
        }

        public RelayCommand DepCommand
        {
            get
            {
                return depCommand ??
                    (depCommand = new RelayCommand(user =>
                    {
                        _dep.Dep(SelectedUser, SelectedAccount);
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
                Accounts = _selectedUser.Accounts;
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
    }
}
