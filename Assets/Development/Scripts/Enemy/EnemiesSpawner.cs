using UnityEngine;

namespace SomethingLikeArchero
{
    [RequireComponent(typeof(EnemiesCollection))]
    public class EnemiesSpawner : MonoBehaviour
    {
        [SerializeField] private Enemy[] _enemies;
        [SerializeField] private Player _player;
        [SerializeField] private Battle _battle;
        [SerializeField] private Payment _payment;
        [SerializeField] private float _minPositionX, _maxPositionX, _minPositionZ, _maxPositionZ;

        private EnemiesCollection _enemiesCollection;
        private float _positionY = 0.1f;

        private void Start()
        {
            _enemiesCollection = GetComponent<EnemiesCollection>();
            Spawn();
        }

        private void Spawn()
        {
            for(int i = 0; i<_enemies.Length; i++)
            {
                Vector3 position = new Vector3(Random.Range(_minPositionX, _maxPositionX), _positionY, Random.Range(_minPositionZ, _maxPositionZ));
                Enemy newEnemy = Instantiate(_enemies[i], position, transform.rotation);
                
                if(newEnemy.TryGetComponent(out EnemyMovement enemyMovement))
                {
                    enemyMovement.SetPlayer(_player);
                }

                if(newEnemy.TryGetComponent(out EnemyController enemyController))
                {
                    enemyController.Initialize(_enemiesCollection, _battle, _payment);
                }

                _enemiesCollection.AddEnemy(newEnemy);
            }
        }
    }
}
