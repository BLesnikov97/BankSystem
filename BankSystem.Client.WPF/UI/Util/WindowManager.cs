using BankSystem.Client.WPF.Util;

namespace BankSystem.Client.WPF.UI.Util
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
