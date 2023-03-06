using System.Collections.Generic;
using BankSystem.Client.WPF.Util;
using BankSystem.BusinesLogic.Services;
using BankSystem.BusinesLogic.BaseConnect;
using BankSystem.BusinessLogic.Model;

namespace BankSystem.Client.WPF.UI.Transfer
{
    public class TransferViewModel : BaseViewModel
    {
        private List<User> _users;
        private User _fromUser;
        private User _toUser;

        private ICollection<Account> _fromAccounts;
        private ICollection<Account> _toAccounts;
        private Account _fromAccount;
        private Account _toAccount;

        private List<Account> _Accounts;

        private IServiceTransfer _serviceTransfer;

        public TransferViewModel(IRepository db, IServiceTransfer serviceTransfer)
        {
            _serviceTransfer = serviceTransfer;

        }

        private RelayCommand transferCommand;

        public RelayCommand TransferCommand
        {
            get
            {
                return transferCommand ??
                    (transferCommand = new RelayCommand(obj =>
                    {   

                        _serviceTransfer.Transfer(FromAccount, ToAccount);
                    }));
            }
        }

        public List<User> Users
        {
            get { return _users; }
            set
            {
                _users = value;
                OnPropertyChanged("ToAccounts");
            }
        }

        public User FromUser
        {
            get { return _fromUser; }
            set
            {
                _fromUser = value;
                OnPropertyChanged("FromUser");
            }
        }

        public User ToUser
        {
            get { return _toUser; }
            set
            {
                _toUser = value;
                OnPropertyChanged("ToUser");
            }
        }

        public Account FromAccount
        {
            get { return _fromAccount; }
            set
            {
                _fromAccount = value;
                OnPropertyChanged("FromAccount");
            }
        }

        public Account ToAccount
        {
            get { return _toAccount; }
            set
            {
                _toAccount = value;
                OnPropertyChanged("ToAccount");
            }
        }

        public ICollection<Account> FromAccounts
        {
            get { return _fromAccounts; }
            set
            {
                _fromAccounts = value;
                OnPropertyChanged("FromAccounts");
            }
        }

        public ICollection<Account> ToAccounts
        {
            get { return _toAccounts; }
            set
            {
                _toAccounts = value;
                OnPropertyChanged("ToAccounts");
            }
        }      
    }
}
