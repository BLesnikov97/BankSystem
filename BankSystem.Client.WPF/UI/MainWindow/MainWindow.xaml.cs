using MahApps.Metro.Controls;

namespace BankSystem.Client.WPF.UI.MainWindow
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        public MainWindow()
        {
            MainWindowViewModel mainWindowViewModel = new MainWindowViewModel();

            InitializeComponent(); 

            this.DataContext = mainWindowViewModel;
        }
    }
}
