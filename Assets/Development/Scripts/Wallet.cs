using UnityEngine;
using TMPro;

namespace SomethingLikeArchero
{
    public class Wallet : MonoBehaviour
    {
        [SerializeField] private TMP_Text _coinsDisplay;

        private int _coins = 0;

        private void Start()
        {
            UpdateCoinsDisplay();
        }

        public void AddCoin(int coin)
        {
            _coins += coin;
            UpdateCoinsDisplay();
        }

        private void UpdateCoinsDisplay()
        {
            _coinsDisplay.text = _coins.ToString();
        }
    }
}
