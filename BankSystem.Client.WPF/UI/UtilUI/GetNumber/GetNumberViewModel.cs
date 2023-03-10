using BankSystem.BusinesLogic.Repositories;
using BankSystem.BusinesLogic.Services;
using BankSystem.BusinessLogic.Model;
using BankSystem.Client.WPF.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystem.Client.WPF.UI.UtilUI.GetNumber
{
    public class GetNumberViewModel : BaseViewModel
    {
        private double _number;

        public GetNumberViewModel()
        {

        }

        private RelayCommand getNumber;

        public RelayCommand GetNumber
        {
            get
            {
                return getNumber ??
                    (getNumber = new RelayCommand(obj =>
                    {

                    }));
            }
        }

        public double Number
        {
            get { return _number; }
            set
            {
                _number = value;
                OnPropertyChanged("Number");
            }
        }
    }
}
