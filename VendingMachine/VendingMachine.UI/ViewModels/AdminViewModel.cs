using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using VendingMachine.BLL.Managers;
using VendingMachine.BLL.Models;
using VendingMachine.DAL.Entities;
using VendingMachine.DAL.Repositories.Base;
using VendingMachine.UI.Commands;

namespace VendingMachine.UI.ViewModels
{
    public class AdminViewModel : INotifyPropertyChanged
    {
        private readonly AdminManager _adminManager;

        public AdminViewModel(AdminManager adminManager)
        {
            _adminManager = adminManager;   
        }

        private Drink _inputDrink;

        public Drink InputDrink
        { 
            get => _inputDrink;
            set
            {
                _inputDrink = value;
                OnPropertyChanged("Input Drink");
            }
        }

        // команда добавления нового объекта
        private RelayCommand _addCommand;
        public RelayCommand AddCommand
        {
            get => _addCommand ?? (_addCommand = new RelayCommand(obj => 
            {
            //    AdminManager adminManager = new AdminManager(_adminRepository, _drinkRepository, _coinRepository);
                _adminManager.AddDrink(InputDrink);
            }));
            
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
