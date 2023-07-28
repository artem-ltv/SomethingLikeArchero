using UnityEngine;

namespace SomethingLikeArchero
{
    public class Payment : MonoBehaviour
    {
        [SerializeField] private Wallet _wallet;

        private int _priceOfMurder = 1;

        public void PayCoinForKillingEnemy()
        {
            _wallet.AddCoin(_priceOfMurder);
        }
    }
}
