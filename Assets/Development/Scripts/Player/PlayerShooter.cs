using UnityEngine;

namespace SomethingLikeArchero
{
    [RequireComponent(typeof(PlayerMovement))]
    [RequireComponent(typeof(PlayerHealth))]
    public class PlayerShooter : Shooter
    {
        [SerializeField] private EnemiesCollection _enemiesCollection;
        [SerializeField] private Battle _battle;

        private PlayerMovement _movement;
        private PlayerHealth _playerHealth;
        private Enemy _targetForShooting;
        private bool _canShoot = true;

        private void Awake()
        {
            _movement = GetComponent<PlayerMovement>();
            _playerHealth = GetComponent<PlayerHealth>();
        }

        private void OnEnable()
        {
            _battle.Ending += ProhibitShoot;
            _playerHealth.Dying += ProhibitShoot;
        }

        private void OnDisable()
        {
            _battle.Ending -= ProhibitShoot;
            _playerHealth.Dying -= ProhibitShoot;
        }

        public override void StartShoot()
        {
            if (_canShoot)
            {
                _targetForShooting = _enemiesCollection.FindNearestEnemy();
                if(_targetForShooting != null)
                {
                    _movement.LookAtEnemy(_targetForShooting);
                    base.StartShoot();
                }
            }
        }

        private void ProhibitShoot()
        {
            _canShoot = false;
            StopShoot();
        }
    }
}
