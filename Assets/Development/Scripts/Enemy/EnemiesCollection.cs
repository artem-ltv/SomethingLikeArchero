using UnityEngine;
using System.Collections.Generic;
using UnityEngine.Events;

namespace SomethingLikeArchero
{
    public class EnemiesCollection : MonoBehaviour
    {
        public UnityAction EnemiesDying;

        [SerializeField] private List<Enemy> _enemies;
        [SerializeField] private Player _player;

        private Enemy _nearestEnemy;
        private PlayerHealth _playerHealth;

        private void OnEnable()
        {
            if(_player.TryGetComponent(out _playerHealth))
            {
                _playerHealth.Dying += DisableAllEnemies;
            }
        }

        private void OnDisable()
        {
            if(_playerHealth != null)
            {
                _playerHealth.Dying -= DisableAllEnemies;
            }
        }

        public void AddEnemy(Enemy enemy)
        {
            _enemies.Add(enemy);
        }

        public void RemoveEnemy(Enemy enemy)
        {
            _enemies.Remove(enemy);
        }

        public Enemy FindNearestEnemy()
        {
            float distance = float.MaxValue;
            Vector3 playerPosition = _player.transform.position;
            foreach(Enemy enemy in _enemies)
            {
                if(enemy != null)
                {
                    Vector3 difference = enemy.transform.position - playerPosition;
                    float currentDistance = difference.sqrMagnitude;
                    if(currentDistance < distance)
                    {
                        _nearestEnemy = enemy;
                        distance = currentDistance;
                    }
                }
            }

            return _nearestEnemy;
        }

        public void CheckLivingEnemies()
        {
            if(_enemies.Count == 0)
            {
                EnemiesDying?.Invoke();
            }
        }

        public void DisableAllEnemies()
        {
            foreach(Enemy enemy in _enemies)
            {
                if(enemy.TryGetComponent(out EnemyController enemyController))
                {
                    enemyController.ResetCoroutines();
                    enemyController.DisableComponents();
                    if(enemyController.TryGetComponent(out EnemyShooter enemyShooter))
                    {
                        enemyShooter.StopShoot();
                    }
                }
            }
        }
    }
}
