using System.Collections.Generic;
using BankSystem.Client.WPF.Util;
using BankSystem.BusinesLogic.Services;
using BankSystem.BusinesLogic.BaseConnect;
using BankSystem.BusinessLogic.Model;

namespace BankSystem.Client.WPF.UI.Transfer
{
    public class TransferViewModel : BaseViewModel
    {
        private Account _fromAccount;
        private Account _toAccount;

        private List<Account> _Accounts;

        private IServiceTransfer _serviceTransfer;

        public TransferViewModel(IRepository db, IServiceTransfer serviceTransfer)
        {
            _serviceTransfer = serviceTransfer;

            _Accounts = db.GetAccountsList();
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

        public List<Account> Accounts
        {
            get { return _Accounts; }
            set
            {
                _Accounts = value;
                OnPropertyChanged("Accounts");
            }
        }



    }
}
