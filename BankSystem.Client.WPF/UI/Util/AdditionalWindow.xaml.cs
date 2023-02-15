using MahApps.Metro.Controls;
using BankSystem.Client.WPF.Util;

namespace BankSystem.Client.WPF.UI
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
