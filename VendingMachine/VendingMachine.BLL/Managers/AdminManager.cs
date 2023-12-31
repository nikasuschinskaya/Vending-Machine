﻿using VendingMachine.BLL.Models;
using VendingMachine.DAL.Entities;
using VendingMachine.DAL.Enums;
using VendingMachine.DAL.Repositories.Base;

namespace VendingMachine.BLL.Managers
{
    /// <summary>
    /// Возможности админа
    /// </summary>
    public class AdminManager
    {
        private readonly IRepository<DrinkEntity> _drinkRepository;
        private readonly IRepository<CoinEntity> _coinRepository;

        public AdminManager(IRepository<DrinkEntity> drinkRepository, IRepository<CoinEntity> coinRepository)
        {
            _drinkRepository = drinkRepository;
            _coinRepository = coinRepository;
        }

        /// <summary>
        /// Добавление напитка
        /// </summary>
        /// <param name="drink">Напиток</param>
        public void AddDrink(Drink drink) =>
            _drinkRepository.Create(new DrinkEntity { Name = drink.Name, Cost = drink.Cost, Count = drink.Count, DrinkState = drink.DrinkState });

        /// <summary>
        /// Удаление напитка
        /// </summary>
        /// <param name="drinkId">Id напитка, который нужно удалить</param>
        public void DeleteDrink(int drinkId) => _drinkRepository.Delete(drinkId);

        /// <summary>
        /// Изменение количества напитка
        /// </summary>
        /// <param name="id">Id напитка, количество которого нужно изменить</param>
        /// <param name="newDrinkCount">Новое количество напитка</param>
        public void UpdateDrinkCount(int id, int newDrinkCount)
        {
            var drink = _drinkRepository.GetById(id);
            drink.Count = newDrinkCount;
            _drinkRepository.Update(drink);
        }

        /// <summary>
        /// Изменение стоимости напитка
        /// </summary>
        /// <param name="id">Id напитка, стоимость которого нужно изменить</param>
        /// <param name="newDrinkCost">Новая стоимость напитка</param>
        public void UpdateDrinkCost(int id, decimal newDrinkCost)
        {
            var drink = _drinkRepository.GetById(id);
            drink.Cost = newDrinkCost;
            _drinkRepository.Update(drink);
        }

        /// <summary>
        /// Блокировка напитка
        /// </summary>
        /// <param name="id">Id напитка, который нужно заблокировать</param>
        public void BlockDrink(int id)
        {
            var drink = _drinkRepository.GetById(id);
            drink.DrinkState = State.Block;
            _drinkRepository.Update(drink);

        }

        /// <summary>
        /// Разблокировка напитка
        /// </summary>
        /// <param name="id">Id напитка,который нужно разблокировать</param>
        public void UnlockDrink(int id)
        {
            var drink = _drinkRepository.GetById(id);
            drink.DrinkState = State.Unlock;
            _drinkRepository.Update(drink);
        }

        /// <summary>
        /// Изменение количества монет данного номинала
        /// </summary>
        /// <param name="id">Id номинала, количество которого нужно изменить</param>
        /// <param name="newCoinCount">Новое количество монет данного номинала</param>
        public void UpdateCoinCount(int id, int newCoinCount)
        {
            var coin = _coinRepository.GetById(id);
            coin.Count = newCoinCount;
            _coinRepository.Update(coin);
        }

        /// <summary>
        /// Блокировка номинала
        /// </summary>
        /// <param name="id">Id номинала, который нужно заблокировать</param>
        public void BlockCoin(int id)
        {
            var coin = _coinRepository.GetById(id);
            coin.CoinState = State.Block;
            _coinRepository.Update(coin);
        }

        /// <summary>
        /// Разблокировка номинала
        /// </summary>
        /// <param name="id">Id номинала,который нужно разблокировать</param>
        public void UnlockCoin(int id)
        {
            var coin = _coinRepository.GetById(id);
            coin.CoinState = State.Unlock;
            _coinRepository.Update(coin);
        }

        /// <summary>
        /// Получение всех напитков
        /// </summary>
        /// <returns>Напитки</returns>
        public List<Drink> GetAllDrinks() =>
            _drinkRepository.GetAll().Select(x => new Drink(x.Id, x.Name, x.Count, x.Cost, x.DrinkState)).ToList();

        /// <summary>
        /// Получение всех монет
        /// </summary>
        /// <returns>Монеты</returns>
        public List<Coin> GetAllCoins() =>
            _coinRepository.GetAll().Select(x => new Coin(x.Id, x.Denomination, x.Count, x.CoinState)).ToList();
    }
}
