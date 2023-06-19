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
    public class CoinManager
    {
        private readonly IRepository<CoinEntity> _coinRepository;
        public CoinManager(IRepository<CoinEntity> coinRepository) => _coinRepository = coinRepository;

        public void DepositCoins(Dictionary<int, int> coins)
        {
            var allCoins = _coinRepository.GetAll();
            foreach (var pair in coins)
            {
                var coin = allCoins.FirstOrDefault(x => x.Denomination == pair.Key);
                coin.Count += pair.Value;
                _coinRepository.Update(coin);
            }
        }

        public List<Coin> GetAvaliableCoins() => 
                        _coinRepository.GetAll()
                                        .Where(coin => coin.CoinState != State.Block)
                                        .Select(x => new Coin(x.Id, x.Denomination, x.Count))
                                        .ToList();

        /// <summary>
        ///  Возвращает сдачу в виде количества и номинала монет
        /// </summary>
        /// <param name="changeInCash">Сдача в рублях</param>
        /// <returns>Сдача в виде словаря, где ключ - номинал, значение - количество монет этого номинала</returns>
        public Dictionary<int, int> GetChange(decimal changeInCash)
        {
            Dictionary<int, int> change = new Dictionary<int, int>();
            List<int> denominations = new List<int>();

            var coins = GetAvaliableCoins().OrderByDescending(coin => coin.Denomination);

            foreach (var coin in coins)
                denominations.Add(coin.Denomination);

            foreach (int denomination in denominations)
            {
                foreach (var coin in coins)
                {
                    if (coin.Count != 0)
                        continue;
                    // Вычисляем количество монет данного номинала, которое может быть использовано
                    int count = Math.Min(Convert.ToInt32(changeInCash) / denomination, coin.Count);

                    // Обновляем остаток суммы и количество доступных монет
                    changeInCash -= count * denomination;
                    coin.Count -= count;

                    // Добавляем номинал и количество монет в словарь сдачи
                    change.Add(denomination, count);
                }
                
                // Если сумма достигла 0, выходим из цикла
                if (changeInCash == 0)
                    break;
            }

            return change;
        }

    }
}
