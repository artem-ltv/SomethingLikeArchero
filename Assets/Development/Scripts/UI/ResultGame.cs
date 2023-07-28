using UnityEngine;

namespace SomethingLikeArchero
{
    public class ResultGame : MonoBehaviour
    {
        [SerializeField] private PlayerHealth _playerHealth;
        [SerializeField] private Finish _finish;
        [SerializeField] private GameObject _winPanel;
        [SerializeField] private GameObject _losePanel;

        private void OnEnable()
        {
            _playerHealth.Dying += EnableLosingPanel;
            _finish.Finishing += EnableWinningPanel;
        }

        private void OnDisable()
        {
            _playerHealth.Dying -= EnableLosingPanel;
            _finish.Finishing -= EnableWinningPanel;
        }

        private void EnableLosingPanel()
        {
            _losePanel.SetActive(true);
        }

        private void EnableWinningPanel()
        {
            _winPanel.SetActive(true);
        }
    }
}
