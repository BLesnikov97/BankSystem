using System.Collections.Generic;
using BankSystem.Client.WPF.Util;
using BankSystem.BusinesLogic.Model;
using BankSystem.BusinesLogic.Services;
using BankSystem.BusinesLogic.BaseConnect;

namespace BankSystem.Client.WPF.UI.Transfer
{
    public class TransferViewModel : BaseViewModel
    {
        private UserAccount _fromUser;
        private UserAccount _toUser;

        private List<UserAccount> _userAccounts;

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

        public UserAccount FromUser
        {
            get { return _fromUser; }
            set
            {
                _fromUser = value;
                OnPropertyChanged("FromUser");
            }
        }

        public UserAccount ToUser
        {
            get { return _toUser; }
            set
            {
                _toUser = value;
                OnPropertyChanged("ToUser");
            }
        }

        public List<UserAccount> UserAccounts
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
