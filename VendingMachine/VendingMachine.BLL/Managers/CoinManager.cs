using VendingMachine.BLL.Models;
using VendingMachine.DAL.Entities;
using VendingMachine.DAL.Enums;
using VendingMachine.DAL.Repositories.Base;

namespace VendingMachine.BLL.Managers
{
    /// <summary>
    /// Логика возможностей, связанных с монетами
    /// </summary>
    public class CoinManager
    {
        private readonly IRepository<CoinEntity> _coinRepository;
        public CoinManager(IRepository<CoinEntity> coinRepository) => _coinRepository = coinRepository;

        /// <summary>
        /// Пополнение монет
        /// </summary>
        /// <param name="id">id</param>
        public void DepositCoin(int id)
        {
            var coin = _coinRepository.GetById(id);
            coin.Count++;
            _coinRepository.Update(coin);
        }

        /// <summary>
        /// Получение доступных монет
        /// </summary>
        /// <returns>Список монет</returns>
        public List<Coin> GetAvaliableCoins() =>
                        _coinRepository.GetAll()
                                        .Where(coin => coin.CoinState != State.Block && coin.Count > 0)
                                        .Select(x => new Coin(x.Id, x.Denomination, x.Count, x.CoinState))
                                        .ToList();

        /// <summary>
        /// Получение номинала монеты по id
        /// </summary>
        /// <param name="id">id</param>
        /// <returns>Номинал монеты</returns>
        public int GetCoinDenomination(int id) => _coinRepository.GetById(id).Denomination;

        /// <summary>
        /// Обновление количества монет
        /// </summary>
        /// <param name="denomination">Номинал монеты</param>
        /// <param name="newCoinCount">Новое количество</param>
        public void UpdateCoinCount(int denomination, int newCoinCount)
        {
            var coin = _coinRepository.GetAll().FirstOrDefault(coin => coin.Denomination == denomination);
            coin.Count -= newCoinCount;
            _coinRepository.Update(coin);
        }

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
                if (z > 0) change.Add(denominations[i], z);

                var rest = changeInCash - denominations[i] * z;
                if (rest == 0) break;
                changeInCash = rest;
            }

            return change;
        }
    }
}