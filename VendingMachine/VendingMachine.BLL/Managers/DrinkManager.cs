using VendingMachine.BLL.Models;
using VendingMachine.DAL.Entities;
using VendingMachine.DAL.Enums;
using VendingMachine.DAL.Repositories.Base;

namespace VendingMachine.BLL.Managers
{
    /// <summary>
    /// Логика возможностей, связанных с напитками
    /// </summary>
    public class DrinkManager
    {
        private readonly IRepository<DrinkEntity> _drinkRepository;
        public DrinkManager(IRepository<DrinkEntity> drinkRepository) => _drinkRepository = drinkRepository;

        /// <summary>
        /// Получение доступных напитков для выбора
        /// </summary>
        /// <returns>Доступные для выбора напитки</returns>
        public List<Drink> GetAvaliableDrinks() =>
                                            _drinkRepository.GetAll()
                                                            .Where(drink => drink.Count > 0 && drink.DrinkState != State.Block)
                                                            .Select(x => new Drink(x.Id, x.Name, x.Count, x.Cost, x.DrinkState))
                                                            .ToList();
        /// <summary>
        /// Получение напитка по id
        /// </summary>
        /// <param name="id">id</param>
        /// <returns>Напиток</returns>
        public Drink GetDrinkById(int id)
        {
            var drink = _drinkRepository.GetById(id);
            return new Drink(drink.Id, drink.Name, drink.Count, drink.Cost, drink.DrinkState);
        }

        /// <summary>
        /// Получение напитка по имени
        /// </summary>
        /// <param name="imgName">Название картинки</param>
        /// <returns>Напиток</returns>
        public Drink GetDrinkByImgName(string imgName)
        {
            var drink = _drinkRepository.GetAll().FirstOrDefault(drink => drink.Name.Equals(imgName));
            return new Drink(drink.Id, drink.Name, drink.Count, drink.Cost, drink.DrinkState);
        }

        /// <summary>
        /// Уменьшает количество напитков при покупке
        /// </summary>
        public Drink BuyDrink(int selectedDrinkId)
        {
            var drink = _drinkRepository.GetById(selectedDrinkId);
            drink.Count--;
            _drinkRepository.Update(drink);
            return new Drink(drink.Id, drink.Name, drink.Count, drink.Cost);
        }

        /// <summary>
        /// Получает цены напитков
        /// </summary>
        /// <param name="id">Id напитка, цену которого нужно получить</param>
        /// <returns>цена напитка</returns>
        public decimal GetDrinkCost(int id) => _drinkRepository.GetById(id).Cost;

    }
}
