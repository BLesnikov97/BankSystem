using MahApps.Metro.Controls;
using BankSystem.Client.WPF.Util;
using BankSystem.Client.WPF.WindowsManager;
using BankSystem.Client.WPF.UI;
using BankSystem.Client.WPF.UI.Dep;

namespace BankSystem.Client.WPF.UI.AdditionalWindows
{
    /// <summary>
    /// Логика взаимодействия для AdditionalWindow.xaml
    /// </summary>
    public partial class AdditionalWindow : MetroWindow
    {
        public AdditionalWindow(BaseViewModel baseViewModel)
        {
            InitializeComponent();
            this.DataContext= baseViewModel;
        }
    }
}
