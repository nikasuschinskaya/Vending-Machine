using Autofac;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using VendingMachine.BLL.Managers;
using VendingMachine.UI.Commands;
using VendingMachine.UI.ViewModels.Base;
using VendingMachine.UI.Views;

namespace VendingMachine.UI.ViewModels
{
    public class AutorizationViewModel : ViewModelBase
    {
        private string _login;
        private string _password;
        private readonly AutorizationManager _autorizationManager;

        public ICommand OnclickAutorization { get; }

        public string Login
        {
            get => _login;
            set => SetProperty(ref _login, value);
        }

        public string Password
        {
            get => _password;
            set => SetProperty(ref _password, value);
        }

        public AutorizationViewModel()
        {
            using (var scope = App.Container.BeginLifetimeScope())
            {
                _autorizationManager = scope.Resolve<AutorizationManager>();
            }
            OnclickAutorization = new RelayCommand(ButtonClicked);
        }

        private void ButtonClicked(object parameter)
        {
            var passwordBox = parameter as PasswordBox;
            _password = passwordBox.Password;

            if (_autorizationManager.IsCorrectData(Login, Password))
            {
                AdminWindow adminWindow = new AdminWindow();
                adminWindow.Show();
            }
            else MessageBox.Show("Введены неверные данные!");
        }
    }
}
