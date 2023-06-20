using VendingMachine.BLL.Models;
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
            _drinkRepository.Create(new DrinkEntity { Id = drink.DrinkId, Name = drink.Name, Cost = drink.Cost, DrinkState = drink.DrinkState });

        /// <summary>
        /// Удаление напитка
        /// </summary>
        /// <param name="drinkId">Id напитка, который нужно удалить</param>
        public void DeleteDrink(int drinkId) => _drinkRepository.Delete(drinkId);

        /// <summary>
        /// Изменение количества напитков 
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
        public void UpdateDrinkCost(int id, int newDrinkCost)
        {
            var drink = _drinkRepository.GetById(id);
            drink.Cost = newDrinkCost;
            _drinkRepository.Update(drink);
        }

        /// <summary>
        /// Блокировка напитка
        /// </summary>
        /// <param name="id">Id напитка, который нужно заблокировать</param>
        public void BlockDrink(int id) => _drinkRepository.GetById(id).DrinkState = State.Block;

        /// <summary>
        /// Разблокировка напитка
        /// </summary>
        /// <param name="id">Id напитка,который нужно разблокировать</param>
        public void UnlockDrink(int id) => _drinkRepository.GetById(id).DrinkState = State.Unlock;

        /// <summary>
        /// Блокировка номинала
        /// </summary>
        /// <param name="id">Id номинала, который нужно заблокировать</param>
        public void BlockCoin(int id) => _coinRepository.GetById(id).CoinState = State.Block;


        /// <summary>
        /// Разблокировка номинала
        /// </summary>
        /// <param name="id">Id номинала,который нужно разблокировать</param>
        public void UnlockCoin(int id) => _coinRepository.GetById(id).CoinState = State.Unlock;

    }
}
