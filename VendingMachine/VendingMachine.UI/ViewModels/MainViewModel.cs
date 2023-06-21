using Autofac;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;
using VendingMachine.BLL.Managers;
using VendingMachine.BLL.Models;
using VendingMachine.UI.Commands;
using VendingMachine.UI.ViewModels.Base;
using VendingMachine.UI.Views;

namespace VendingMachine.UI.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private readonly CoinManager _coinManager;
        private readonly DrinkManager _drinkManager;

        public List<Drink> AvailableDrinks { get; } = new List<Drink>();

        public string FantaVisibible => IsEnoughMoney(1) ? "Visible" : "Hidden";
        public string OutputFantaCost => IsEnoughMoney(1) ? $"{GetFantaCost()} руб." : " ";

        public string SpriteVisibible => IsEnoughMoney(2) ? "Visible" : "Hidden";
        public string OutputSpriteCost => IsEnoughMoney(2) ? $"{GetSpriteCost()} руб." : " ";

        public string SevenUpVisibible => IsEnoughMoney(3) ? "Visible" : "Hidden";
        public string OutputSevenUpCost => IsEnoughMoney(3) ? $"{GetSevenUpCost()} руб." : " ";

        public string ColaVisibible => IsEnoughMoney(4) ? "Visible" : "Hidden";
        public string OutputColaCost => IsEnoughMoney(4) ? $"{GetColaCost()} руб." : " ";

        public string PepsiVisibible => IsEnoughMoney(5) ? "Visible" : "Hidden";
        public string OutputPepsiCost => IsEnoughMoney(5) ? $"{GetPepsiCost()} руб." : " ";

        private decimal _depositedAmount;
        public decimal DepositedAmount
        {
            get => _depositedAmount;
            set
            {
                SetProperty(ref _depositedAmount, value);
                OnPropertyChanged(nameof(FantaVisibible));
                OnPropertyChanged(nameof(OutputFantaCost));
                OnPropertyChanged(nameof(SpriteVisibible));
                OnPropertyChanged(nameof(OutputSpriteCost));
                OnPropertyChanged(nameof(SevenUpVisibible));
                OnPropertyChanged(nameof(OutputSevenUpCost));
                OnPropertyChanged(nameof(ColaVisibible));
                OnPropertyChanged(nameof(OutputColaCost));
                OnPropertyChanged(nameof(PepsiVisibible));
                OnPropertyChanged(nameof(OutputPepsiCost));
            }
        }

        public ICommand OnClickAutorizationButton { get; }
        public ICommand OnClickOneCoinButton { get; }
        public ICommand OnClickTwoCoinButton { get; }
        public ICommand OnClickFiveCoinButton { get; }
        public ICommand OnClickTenCoinButton { get; }
        public ICommand OnClickFanta { get; }
        public ICommand OnClickSprite { get; }
        public ICommand OnClickSevenUp { get; }
        public ICommand OnClickCola { get; }
        public ICommand OnClickPepsi { get; }
        public ICommand OnClickReadyButton { get; }


        public MainViewModel()
        {
            using (var scope = App.Container.BeginLifetimeScope())
            {
                _coinManager = scope.Resolve<CoinManager>();
                _drinkManager = scope.Resolve<DrinkManager>();
            }
            RefreshAvailableDrinks();
            OnClickAutorizationButton = new RelayCommand(AutorizationButtonClicked);
            OnClickOneCoinButton = new RelayCommand(OneCoinButtonClicked);
            OnClickTwoCoinButton = new RelayCommand(TwoCoinButtonClicked);
            OnClickFiveCoinButton = new RelayCommand(FiveCoinButtonClicked);
            OnClickTenCoinButton = new RelayCommand(TenCoinButtonClicked);
            OnClickFanta = new RelayCommand(FantaClicked);
            OnClickSprite = new RelayCommand(SpriteClicked);
            OnClickSevenUp = new RelayCommand(SevenUpClicked);
            OnClickCola = new RelayCommand(ColaClicked);
            OnClickPepsi = new RelayCommand(PepsiClicked);
            OnClickReadyButton = new RelayCommand(ReadyButtonClicked);
        }

        private void RefreshAvailableDrinks()
        {
            AvailableDrinks.Clear();
            var drinks = _drinkManager.GetAvaliableDrinks(DepositedAmount);
            foreach (var drink in drinks)
                AvailableDrinks.Add(drink);
        }

        private int GetFantaCost() => Convert.ToInt32(_drinkManager.GetDrinkCost(1));
        private int GetSpriteCost() => Convert.ToInt32(_drinkManager.GetDrinkCost(2));
        private int GetSevenUpCost() => Convert.ToInt32(_drinkManager.GetDrinkCost(3));
        private int GetColaCost() => Convert.ToInt32(_drinkManager.GetDrinkCost(4));
        private int GetPepsiCost() => Convert.ToInt32(_drinkManager.GetDrinkCost(5));



        private bool IsEnoughMoney(int id) => DepositedAmount >= _drinkManager.GetDrinkCost(id);

        private bool IsNeedChange() => DepositedAmount != 0;

        private void AutorizationButtonClicked(object parameter)
        {
            AutorizationWindow autorizationWindow = new AutorizationWindow();
            autorizationWindow.Show();
        }
        private void ReadyButtonClicked(object parameter)
        {
            if (!IsNeedChange()) MessageBox.Show("Спасибо, что у вас без сдачи!");
            else
            {
                var change = _coinManager.GetChange(DepositedAmount);
                string str = string.Empty;
                foreach (var item in change)
                    str += $"{item.Key} руб. - {item.Value} шт. \n";

                MessageBox.Show($"Ваша сдача:\n{str}");
                DepositedAmount = 0;
            }
        }
        private void OneCoinButtonClicked(object parameter) => DepositedAmount += _coinManager.GetCoinDenomination(1);
        private void TwoCoinButtonClicked(object parameter) => DepositedAmount += _coinManager.GetCoinDenomination(2);
        private void FiveCoinButtonClicked(object parameter) => DepositedAmount += _coinManager.GetCoinDenomination(3);
        private void TenCoinButtonClicked(object parameter) => DepositedAmount += _coinManager.GetCoinDenomination(4);

        private void FantaClicked(object parameter)
        {
            DepositedAmount -= GetFantaCost();
            _drinkManager.BuyDrink(1);
        }

        private void SpriteClicked(object parameter)
        {
            DepositedAmount -= GetSpriteCost();
            _drinkManager.BuyDrink(2);
        }

        private void SevenUpClicked(object parameter)
        {
            DepositedAmount -= GetSevenUpCost();
            _drinkManager.BuyDrink(3);
        }

        private void ColaClicked(object parameter)
        {
            DepositedAmount -= GetColaCost();
            _drinkManager.BuyDrink(4);
        }

        private void PepsiClicked(object parameter)
        {
            DepositedAmount -= GetPepsiCost();
            _drinkManager.BuyDrink(5);
        }
    }
}
