using BankSystem.Client.WPF.Util;
using BankSystem.BusinesLogic.Services;

namespace BankSystem.Client.WPF.UI.WindowAddUser
{
    public class WindowAddUserViewModel : BaseViewModel
    {
        private string _fullName = "ФИО";
        private string _cash = "0";

        private IServiceRepository _service;

        public WindowAddUserViewModel(IServiceRepository serviceRepository)
        {
            _service = serviceRepository;
        }

        private RelayCommand addCommand;

        public RelayCommand AddCommand
        {
            get
            {
                return addCommand ??
                    (addCommand = new RelayCommand(obj =>
                    {
                        _service.AddUser(FullName, Cash);                    
                    }));
            }
        }

        public string FullName
        {
            get { return _fullName; }
            set
            {
                _fullName = value;
                OnPropertyChanged("FullName");
            }
        }

        public string Cash
        {
            get { return _cash; }
            set
            {
                _cash = value;
                OnPropertyChanged("Cash");
            }
        }


    }
}
