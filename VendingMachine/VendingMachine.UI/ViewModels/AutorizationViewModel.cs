using Autofac;
using Autofac.Core;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using VendingMachine.BLL.Managers;
using VendingMachine.UI.Commands;
using VendingMachine.UI.Views;

namespace VendingMachine.UI.ViewModels
{
    public class AutorizationViewModel : INotifyPropertyChanged
    {
        private string _login;
        private string _password;

        //private AdminWindow _adminWindow = new AdminWindow();
        //private AutorizationWindow _autorizationWindow =  new AutorizationWindow();
        private readonly AutorizationManager _autorizationManager;
      

        public ICommand OnclickAutorization { get; }

        public string Login
        {
            get => _login;
            set
            {
                _login = value;
                OnPropertyChanged(nameof(Login));
            }
        }

        public string Password
        {
            get => _password;
            set
            {
                _password = value;
                OnPropertyChanged(nameof(Password));
            }
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

            // Проверка пароля и выполнение логики авторизации
            if (_autorizationManager.IsCorrectData(Login, Password))
            {
                //_autorizationWindow = new AutorizationWindow();
                //_autorizationWindow.Close();
                AdminWindow adminWindow = new AdminWindow();
                adminWindow.Show();
            }
            else MessageBox.Show("Введены неверные данные!");
        }


        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
