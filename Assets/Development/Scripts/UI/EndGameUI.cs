using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace SomethingLikeArchero
{
    public class EndGameUI : MonoBehaviour
    {
        [SerializeField] private Button _restart;
        [SerializeField] private Button _exit;

        private void OnEnable()
        {
            _restart.onClick.AddListener(Restart);
            _exit.onClick.AddListener(Exit);
        }

        private void OnDisable()
        {
            _restart.onClick.RemoveListener(Restart);
            _exit.onClick.RemoveListener(Exit);
        }

        private void Restart()
        {
            SceneManager.LoadScene(0);
        }

        private void Exit()
        {
            Application.Quit();
        }
    }
}
