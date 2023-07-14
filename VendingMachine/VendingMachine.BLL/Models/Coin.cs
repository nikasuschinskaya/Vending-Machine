using VendingMachine.DAL.Enums;

namespace VendingMachine.BLL.Models
{
    public class Coin
    {
        public int CoinId { get; set; }

        public int Denomination { get; set; }

        public int Count { get; set; }

        public State CoinState { get; set; }

        public Coin(int coinId, int denomination, int count, State coinState = State.None)
        {
            CoinId = coinId;
            Denomination = denomination;
            Count = count;
            CoinState = coinState;
        }
    }
}
