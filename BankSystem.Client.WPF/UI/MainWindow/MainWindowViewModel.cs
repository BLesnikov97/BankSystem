using BankSystem.Client.WPF.UI.AddAndTake;
using BankSystem.Client.WPF.UI.Dep;
using BankSystem.Client.WPF.UI.StatusAccaunt;
using BankSystem.Client.WPF.UI.Transfer;
using BankSystem.Client.WPF.UI.Util;
using BankSystem.DataAccess.BaseConnect;
using Castle.Windsor;
using Castle.MicroKernel.Registration;
using BankSystem.Client.WPF.Util;
using BankSystem.BusinesLogic.BaseConnect;
using BankSystem.BusinesLogic.Services;
using BankSystemWPF.UI.WindowAddUser;
using BankSystem.BusinesLogic.Model;

namespace BankSystem.Client.WPF.UI.MainWindow
{
    public class MainWindowViewModel : BaseViewModel
    {        
        private IWindowManager _windowManager;

        WindsorContainer container = new WindsorContainer();

        public  void InstallCastleWindsor()
        {
            container.Register(Component.For<IRepository>().ImplementedBy<Repository>());
            container.Register(Component.For<IServiceRepository>().ImplementedBy<ServiceRepository>());
            container.Register(Component.For<IServiceTransfer>().ImplementedBy<ServiceTransfer>());
            container.Register(Component.For<IServiceDep>().ImplementedBy<ServiceDep>());
            container.Register(Component.For<IWindowManager>().ImplementedBy<WindowManager>());

            container.Register(Component.For<ApplicationContext>());

            container.Register(Component.For<WindowAddUserViewModel>());
            container.Register(Component.For<AddAndTakeViewModel>());
            container.Register(Component.For<TransferViewModel>());
            container.Register(Component.For<DepViewModel>());
            container.Register(Component.For<StatusAccountViewModel>());

            container.Register(Component.For<UserAccount>());

            container.Register(Component.For<ConnectionConfig>());
        }

        public MainWindowViewModel()
        {
            InstallCastleWindsor();
            _windowManager = container.Resolve<IWindowManager>();
        }

        private RelayCommand _addUserCommand;

        public RelayCommand AddUserCommand
        {
            get
            {
                return _addUserCommand ??
                    (_addUserCommand = new RelayCommand(obj =>
                    {
                        WindowAddUserViewModel addUserViewModel = container.Resolve<WindowAddUserViewModel>();

                        _windowManager.WindowShow(addUserViewModel);
                    }));
            }
        }

        private RelayCommand _addAndTakeCommand;

        public RelayCommand AddAndTakeCommand
        {
            get
            {
                return _addAndTakeCommand ??
                    (_addAndTakeCommand = new RelayCommand(obj =>
                    {
                        AddAndTakeViewModel addAndTakeViewModel = container.Resolve<AddAndTakeViewModel>();

                        _windowManager.WindowShow(addAndTakeViewModel);
                    }));
            }
        }

        private RelayCommand _transferCommand;

        public RelayCommand TransferCommand
        {
            get
            {
                return _transferCommand ??
                    (_transferCommand = new RelayCommand(obj =>
                    {
                        TransferViewModel transferViewModel = container.Resolve<TransferViewModel>();

                        _windowManager.WindowShow(transferViewModel);
                    }));
            }
        }

        private RelayCommand _depCommand;

        public RelayCommand DepCommand
        {
            get
            {
                return _depCommand ??
                    (_depCommand = new RelayCommand(obj =>
                    {
                        DepViewModel depViewModel = container.Resolve<DepViewModel>();

                        _windowManager.WindowShow(depViewModel);
                    }));
            }
        }

        private RelayCommand _stausAccauntCommand;

        public RelayCommand StausAccauntCommand
        {
            get
            {
                return _stausAccauntCommand ??
                    (_stausAccauntCommand = new RelayCommand(obj =>
                    {
                        StatusAccountViewModel statusAccauntViewModel = container.Resolve<StatusAccountViewModel>();

                        _windowManager.WindowShow(statusAccauntViewModel);
                    }));
            }
        }
    }
}
