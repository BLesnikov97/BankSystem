using System.Collections.Generic;
using BankSystem.Client.WPF.Util;
using BankSystem.BusinesLogic.Model;
using BankSystem.BusinesLogic.Services;
using BankSystem.BusinesLogic.BaseConnect;

namespace BankSystem.Client.WPF.UI.Transfer
{
    public class TransferViewModel : BaseViewModel
    {
        private Account _fromUser;
        private Account _toUser;

        private List<Account> _userAccounts;

        private IServiceTransfer _serviceTransfer;

        public TransferViewModel(IRepository db, IServiceTransfer serviceTransfer)
        {
            _serviceTransfer = serviceTransfer;

            _userAccounts = db.GetUsersAccountList();
        }

        private RelayCommand transferCommand;

        public RelayCommand TransferCommand
        {
            get
            {
                return transferCommand ??
                    (transferCommand = new RelayCommand(obj =>
                    {
                        _serviceTransfer.Transfer(FromUser, ToUser);
                    }));
            }
        }

        public Account FromUser
        {
            get { return _fromUser; }
            set
            {
                _fromUser = value;
                OnPropertyChanged("FromUser");
            }
        }

        public Account ToUser
        {
            get { return _toUser; }
            set
            {
                _toUser = value;
                OnPropertyChanged("ToUser");
            }
        }

        public List<Account> UserAccounts
        {
            get { return _userAccounts; }
            set
            {
                _userAccounts = value;
                OnPropertyChanged("UserAccounts");
            }
        }



    }
}
