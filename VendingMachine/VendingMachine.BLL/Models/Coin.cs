using VendingMachine.BLL.Enums;

namespace VendingMachine.BLL.Models
{
    public class Coin
    {
        public int CoinId { get; }

        public int Denomination { get; set; }

        public int Count { get; set; }

        public State CoinState { get; set; }
    }
}
