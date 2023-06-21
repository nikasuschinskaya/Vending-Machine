using Autofac;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;
using VendingMachine.BLL.Managers;
using VendingMachine.BLL.Models;
using VendingMachine.UI.Commands;
using VendingMachine.UI.ViewModels.Base;

namespace VendingMachine.UI.ViewModels
{
    public class AdminViewModel : ViewModelBase
    {
        private readonly AdminManager _adminManager;
        private int _drinkId;
        private int _coinId;
        private string _name;
        private int _count;
        private decimal _cost;

        public List<Drink> Drinks { get; set; }
        public List<Coin> Coins { get; set; }
        public int CoinId
        {
            get => _coinId;
            set => SetProperty(ref _coinId, value);
        }

        public int DrinkId
        {
            get => _drinkId;
            set => SetProperty(ref _drinkId, value);
        }

        public string Name
        {
            get => _name;
            set => SetProperty(ref _name, value);
        }
        public int Count
        {
            get => _count;
            set => SetProperty(ref _count, value);
        }

        public decimal Cost
        {
            get => _cost;
            set => SetProperty(ref _cost, value);
        }

        public ICommand OnClickAddButton { get; }
        public ICommand OnClickUpdateButton { get; }
        public ICommand OnClickDeleteButton { get; }
        public ICommand OnClickBlockButton { get; }
        public ICommand OnClickUnlockButton { get; }
        public ICommand OnClickBlockCoinButton { get; }
        public ICommand OnClickUnlockCoinButton { get; }


        public AdminViewModel()
        {
            using (var scope = App.Container.BeginLifetimeScope())
            {
                _adminManager = scope.Resolve<AdminManager>();
            }

            Drinks = _adminManager.GetAllDrinks();
            Coins = _adminManager.GetAllCoins();

            OnClickAddButton = new RelayCommand(AddButtonClicked);
            OnClickUpdateButton = new RelayCommand(UpdateButtonClicked);
            OnClickDeleteButton = new RelayCommand(DeleteButtonClicked);
            OnClickBlockButton = new RelayCommand(BlockButtonClicked);
            OnClickUnlockButton = new RelayCommand(UnlockButtonClicked);

            OnClickBlockCoinButton = new RelayCommand(BlockCoinButtonClicked);
            OnClickUnlockCoinButton = new RelayCommand(UnlockCoinButtonClicked);
        }

        private void AddButtonClicked(object parametr)
        {
            _adminManager.AddDrink(new Drink(DrinkId, Name, Count, Cost));
            MessageBox.Show("Напиток добавлен!");
        }

        private void UpdateButtonClicked(object parametr)
        {
            _adminManager.UpdateDrinkCost(DrinkId, Cost);
            _adminManager.UpdateDrinkCount(DrinkId, Count);
            MessageBox.Show("Напиток изменен!");
        }

        private void DeleteButtonClicked(object parametr)
        {
            _adminManager.DeleteDrink(DrinkId);
            MessageBox.Show("Напиток удален!");
        }
        private void BlockButtonClicked(object parametr)
        {
            _adminManager.BlockDrink(DrinkId);
            MessageBox.Show("Напиток заблокирован!");
        }
        private void UnlockButtonClicked(object parametr)
        {
            _adminManager.UnlockDrink(DrinkId);
            MessageBox.Show("Напиток разблокирован!");
        }
        private void BlockCoinButtonClicked(object parametr)
        {
            _adminManager.BlockCoin(CoinId);
            MessageBox.Show("Номинал заблокирован!");
        }
        private void UnlockCoinButtonClicked(object parametr)
        {
            _adminManager.UnlockCoin(CoinId);
            MessageBox.Show("Номинал разблокирован!");
        }

    }
}
