using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace SomethingLikeArchero
{
    public class Menu : MonoBehaviour
    {
        [SerializeField] private GameObject _menuPanel;

        [SerializeField] private Button _menu;
        [SerializeField] private Button _continue;
        [SerializeField] private Button _restart;
        [SerializeField] private Button _exit;

        private void OnEnable()
        {
            _menu.onClick.AddListener(OpenMenu);
            _continue.onClick.AddListener(Continue);
            _restart.onClick.AddListener(Restart);
            _exit.onClick.AddListener(Exit);
        }

        private void OnDisable()
        {
            _menu.onClick.RemoveListener(OpenMenu);
            _continue.onClick.RemoveListener(Continue);
            _restart.onClick.RemoveListener(Restart);
            _exit.onClick.RemoveListener(Exit);
        }

        private void OpenMenu()
        {
            _menuPanel.SetActive(true);
            Time.timeScale = 0f;
        }

        private void Continue()
        {
            _menuPanel.SetActive(false);
            Time.timeScale = 1f;
        }

        private void Restart()
        {
            Time.timeScale = 1f;
            SceneManager.LoadScene(0);
        }

        private void Exit()
        {
            Application.Quit();
        }
    }
}
