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

        private Drink _selectedDrink = new Drink(0, "Name", 0, 0);
        private Coin _selectedCoin;
        public Drink SelectedDrink { get => _selectedDrink; set => SetProperty(ref _selectedDrink, value); }
        public Coin SelectedCoin { get => _selectedCoin; set => SetProperty(ref _selectedCoin, value); }


        private List<Drink> _drinks;
        private List<Coin> _coins;

        public List<Drink> Drinks { get => _drinks; set => SetProperty(ref _drinks, value); }
        public List<Coin> Coins { get => _coins; set => SetProperty(ref _coins, value); }

        public ICommand OnClickAddButton { get; set; }
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
            _adminManager.AddDrink(SelectedDrink);
            Drinks = _adminManager.GetAllDrinks();
            MessageBox.Show("Напиток добавлен!");
        }

        private void UpdateButtonClicked(object parametr)
        {
            _adminManager.UpdateDrinkCost(SelectedDrink.DrinkId, SelectedDrink.Cost);
            _adminManager.UpdateDrinkCount(SelectedDrink.DrinkId, SelectedDrink.Count);
            Drinks = _adminManager.GetAllDrinks();
            MessageBox.Show("Напиток изменен!");
        }

        private void DeleteButtonClicked(object parametr)
        {
            _adminManager.DeleteDrink(SelectedDrink.DrinkId);
            Drinks = _adminManager.GetAllDrinks();
            MessageBox.Show("Напиток удален!");
        }
        private void BlockButtonClicked(object parametr)
        {
            _adminManager.BlockDrink(SelectedDrink.DrinkId);
            Drinks = _adminManager.GetAllDrinks();
            MessageBox.Show("Напиток заблокирован!");
        }
        private void UnlockButtonClicked(object parametr)
        {
            _adminManager.UnlockDrink(SelectedDrink.DrinkId);
            Drinks = _adminManager.GetAllDrinks();
            MessageBox.Show("Напиток разблокирован!");
        }
        private void BlockCoinButtonClicked(object parametr)
        {
            _adminManager.BlockCoin(SelectedCoin.CoinId);
            Coins = _adminManager.GetAllCoins();
            MessageBox.Show("Номинал заблокирован!");
        }
        private void UnlockCoinButtonClicked(object parametr)
        {
            _adminManager.UnlockCoin(SelectedCoin.CoinId);
            Coins = _adminManager.GetAllCoins();
            MessageBox.Show("Номинал разблокирован!");
        }

    }
}
