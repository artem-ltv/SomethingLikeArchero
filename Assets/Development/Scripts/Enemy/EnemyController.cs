using System.Collections;
using UnityEngine;

namespace SomethingLikeArchero
{
    [RequireComponent(typeof(EnemyStateHandler))]
    [RequireComponent(typeof(EnemyHealth))]
    [RequireComponent(typeof(Enemy))]
    [RequireComponent(typeof(EnemyMovement))]
    public class EnemyController : MonoBehaviour
    {
        [SerializeField] private float _standingTime;
        [SerializeField] private float _movingTime;
        [SerializeField] private Collider _collider;
        
        private EnemyHealth _enemyHealth;
        private EnemyStateHandler _stateHandler;
        private EnemiesCollection _enemiesCollection;
        private Enemy _enemy;
        private Battle _battle;
        private Payment _payment;
        private EnemyMovement _enemyMovement;

        private Coroutine _moveCoroutine;
        private Coroutine _shootCoroutine;


        private void Awake()
        {
            _enemy = GetComponent<Enemy>();
            _enemyHealth = GetComponent<EnemyHealth>();
            _stateHandler = GetComponent<EnemyStateHandler>();
            _enemyMovement = GetComponent<EnemyMovement>();
        }

        private void OnEnable()
        {
            _enemyHealth.Dying += Die;
        }

        private void OnDisable()
        {
            _enemyHealth.Dying -= Die;
            _battle.Starting -= StartControll;
        }

        public void Initialize(EnemiesCollection enemiesCollection, Battle battle, Payment payment)
        {
            _enemiesCollection = enemiesCollection;
            _battle = battle;
            _payment = payment;
            _battle.Starting += StartControll;
        }

        private void StartControll()
        {
            _shootCoroutine = StartCoroutine(Shoot(_standingTime));
        }

        private IEnumerator Shoot(float standingTime)
        {
            _stateHandler.SetState(EnemyState.Shooting);
            yield return new WaitForSeconds(standingTime);
            _moveCoroutine = StartCoroutine(Move(_movingTime));
        }

        private IEnumerator Move(float movingTime)
        {
            _stateHandler.SetState(EnemyState.Moving);
            yield return new WaitForSeconds(movingTime);
            _shootCoroutine = StartCoroutine(Shoot(_standingTime));
        }

        private void Die()
        {
            ResetCoroutines();
            Enemy thisEnemy = GetComponent<Enemy>();
            _enemiesCollection.RemoveEnemy(thisEnemy);
            _stateHandler.SetState(EnemyState.Dying);
            _payment.PayCoinForKillingEnemy();
            _enemiesCollection.CheckLivingEnemies();
            DisableComponents();
        }

        public void ResetCoroutines()
        {
            if(_moveCoroutine != null)
            {
                StopCoroutine(_moveCoroutine);
            }

            if(_shootCoroutine != null)
            {
                StopCoroutine(_shootCoroutine);
            }
        }

        public void DisableComponents()
        {
            _collider.enabled = false;
            _enemy.enabled = false;
            _stateHandler.enabled = false;
            _enemyMovement.DisableNavMeshAgent();
            this.enabled = false;
        }
    }
}
