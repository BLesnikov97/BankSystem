using BankSystem.Client.WPF.UI;
using BankSystem.Client.WPF.Util;
using BankSystem.Client.WPF.UI.AdditionalWindows;

namespace BankSystem.Client.WPF.WindowsManager
{
    internal class WindowManager : IWindowManager
    {
        public void WindowShow(BaseViewModel baseViewModel)
        {
            AdditionalWindow additionalWindow = new AdditionalWindow(baseViewModel);

            additionalWindow.Show();
        }
    }
}
