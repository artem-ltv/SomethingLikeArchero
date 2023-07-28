using UnityEngine;
using UnityEngine.Events;
using System.Collections;

namespace SomethingLikeArchero
{
    public class Battle : MonoBehaviour
    {
        public UnityAction Starting;
        public UnityAction Ending;

        [SerializeField] private float _delayBeforeBattle;
        [SerializeField] private EnemiesCollection _enemiesCollection;

        private void OnEnable()
        {
            _enemiesCollection.EnemiesDying += EndBattle;
        }

        private void OnDisable()
        {
            _enemiesCollection.EnemiesDying -= EndBattle;
        }

        private IEnumerator Start()
        {
            yield return new WaitForSeconds(_delayBeforeBattle);
            StartBattle();
        }

        private void StartBattle()
        {
            Starting?.Invoke();
        }
        
        private void EndBattle()
        {
            Ending?.Invoke();
        }
    }
}
