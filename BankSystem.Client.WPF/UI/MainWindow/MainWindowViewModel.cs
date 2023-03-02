using BankSystem.Client.WPF.UI.AddAndTake;
using BankSystem.Client.WPF.UI.Dep;
using BankSystem.Client.WPF.UI.StatusAccaunt;
using BankSystem.Client.WPF.UI.Transfer;
using BankSystem.DataAccess.BaseConnect;
using Castle.Windsor;
using Castle.MicroKernel.Registration;
using BankSystem.Client.WPF.Util;
using BankSystem.BusinesLogic.BaseConnect;
using BankSystem.BusinesLogic.Services;
using System.Configuration;
using BankSystem.Client.WPF.WindowsManager;
using BankSystem.Client.WPF.UI.AddUser;
using BankSystem.Client.WPF.UI.AddAccount;
using BankSystem.BusinessLogic.Model;

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

            container.Register(Component.For<ApplicationContext>().UsingFactoryMethod(() => { 
                ConnectionConfig connectionConfig = new ConnectionConfig(ConfigurationManager.AppSettings.Get("Host"),
                                                                         ConfigurationManager.AppSettings.Get("Port"),
                                                                         ConfigurationManager.AppSettings.Get("Database"),
                                                                         ConfigurationManager.AppSettings.Get("Username"),
                                                                         ConfigurationManager.AppSettings.Get("Password"));
                return new ApplicationContext(connectionConfig); } ));

            container.Register(Component.For<AddAndTakeViewModel>());
            container.Register(Component.For<TransferViewModel>());
            container.Register(Component.For<DepViewModel>());
            container.Register(Component.For<StatusAccountViewModel>());
            container.Register(Component.For<AddUserViewModel>());
            container.Register(Component.For<AddAccountViewModel>());

            container.Register(Component.For<User>());
            container.Register(Component.For<Account>());
            //container.Register(Component.For<Gender>());

        }

        public MainWindowViewModel()
        {
            InstallCastleWindsor();
            _windowManager = container.Resolve<IWindowManager>();
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

        private RelayCommand _addUser;

        public RelayCommand AddUser
        {
            get
            {
                return _addUser ??
                    (_addUser = new RelayCommand(obj =>
                    {
                        AddUserViewModel addUserViewModel = container.Resolve<AddUserViewModel>();

                        _windowManager.WindowShow(addUserViewModel);
                    }));
            }
        }

        private RelayCommand _addAccount;

        public RelayCommand AddAccount
        {
            get
            {
                return _addAccount ??
                    (_addAccount = new RelayCommand(obj =>
                    {
                        AddAccountViewModel addAccountViewModel = container.Resolve<AddAccountViewModel>();

                        _windowManager.WindowShow(addAccountViewModel);
                    }));
            }
        }
    }
}
