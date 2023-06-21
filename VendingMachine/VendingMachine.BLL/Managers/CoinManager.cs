using VendingMachine.BLL.Models;
using VendingMachine.DAL.Entities;
using VendingMachine.DAL.Enums;
using VendingMachine.DAL.Repositories.Base;

namespace VendingMachine.BLL.Managers
{
    /// <summary>
    /// Логика возможностей, связанных  с монетами
    /// </summary>
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
                                        .Where(coin => coin.CoinState != State.Block && coin.Count != 0)
                                        .Select(x => new Coin(x.Id, x.Denomination, x.Count))
                                        .ToList();

        public int GetCoinDenomination(int id) => _coinRepository.GetById(id).Denomination;

        //Делим сдачу на максимальный номинал,
        //если целая часть от деления больше нуля,
        //тогда эту часть умножаем на максимальный номинал,
        //затем отнимаем от сдачи это число, смотрим что там осталось,
        //ищем снова более подходящий максимальный номинал,
        //таким образом эта целая часть от деления - количество монет этого номинала

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

            for (int i = 0; i < denominations.Count; i++)
            {
                var z = Convert.ToInt32(changeInCash) / denominations[i]; //получаем целую часть от деления - то есть количество монет данного номинала
                //if (z <= 0) i++;
                if (z > 0) change.Add(denominations[i], z);

                var rest = changeInCash - denominations[i] * z;
                if (rest == 0) break;
                changeInCash = rest;
            }

            return change;
        }
    }
}