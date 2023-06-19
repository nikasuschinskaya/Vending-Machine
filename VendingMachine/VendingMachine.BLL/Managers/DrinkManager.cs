using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendingMachine.BLL.Models;
using VendingMachine.DAL.Entities;
using VendingMachine.DAL.Enums;
using VendingMachine.DAL.Repositories.Base;

namespace VendingMachine.BLL.Managers
{
    public class DrinkManager
    {
        private readonly IRepository<DrinkEntity> _drinkRepository;
        public DrinkManager(IRepository<DrinkEntity> drinkRepository) => _drinkRepository = drinkRepository;

        /// <summary>
        /// Получение доступных напитков для выбора
        /// </summary>
        /// <param name="depositSum">Внесенная сумма</param>
        /// <returns>Доступные для выбора напитки</returns>
        public List<Drink> GetAvaliableDrinks(decimal depositSum) => 
                                            _drinkRepository.GetAll()
                                                            .Where(drink => drink.Cost <= depositSum && drink.Count != 0 && drink.DrinkState != State.Block)
                                                            .Select(x => new Drink(x.Id, x.Name, x.Cost))
                                                            .ToList();

        /// <summary>
        /// Уменьшает количество напитков при покупке
        /// </summary>
        public Drink BuyDrink(int selectedDrinkId)
        {
            var drink = _drinkRepository.GetById(selectedDrinkId);
            drink.Count--;
            _drinkRepository.Update(drink);
            return new Drink(drink.Id, drink.Name, drink.Cost);
        }


        ///// <summary>
        ///// Рачет суммы к оплате
        ///// </summary>
        ///// <returns>Сумма к оплате</returns>
        //public decimal GetTotalSum() => Drink.Cost;

        ///// <summary>
        ///// Хвататет ли денег на покупку напитка
        ///// </summary>
        ///// <returns>Да или нет</returns>
        //private bool IsEnoughMoney()
        //{
        //    if (DepositedAmount < GetTotalSum()) return false;
        //    return true;
        //}

        ///// <summary>
        ///// Нужна ли сдача
        ///// </summary>
        ///// <returns>Да или нет</returns>
        //private bool IsNeedChange()
        //{
        //    if(GetChange() == 0) return false;
        //    return true;
        //}

        ///// <summary>
        ///// Расчет оставшиейся суммы после покупки напитка
        ///// </summary>
        ///// <returns>Сдача</returns>
        //public decimal GetChange() => DepositedAmount - GetTotalSum();

        //public Dictionary<int, int> GetChangeInCash()
        //{
        //    Dictionary<int, int> _changeInCash = new();
        //    if (IsEnoughMoney() && IsNeedChange())
        //    {
        //        decimal changeInCash = GetChange();
        //        if(_coin.CoinState != State.Block)
        //        {
        //            foreach (var change in _changeInCash)
        //            {
        //                //номинал
        //                change.Key = _coin.Denomination
        //                //количество монет
        //                change.Value 
        //            }
        //        }
        //        //switch (_coin.CoinState)
        //        //{
        //        //    case State.None:

        //        //        break;
        //        //    case State.Unlock:

        //        //        break;
        //        //    case State.Block:

        //        //        break;
        //        //}

        //    }
        //}
    }
}
