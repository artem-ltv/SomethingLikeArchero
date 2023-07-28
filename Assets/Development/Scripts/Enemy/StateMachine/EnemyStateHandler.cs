using System.Collections.Generic;
using UnityEngine;

namespace SomethingLikeArchero
{
    [RequireComponent(typeof(EnemyMovement))]
    [RequireComponent(typeof(EnemyShooter))]
    [RequireComponent(typeof(EnemyAnimatorController))]
    public class EnemyStateHandler : MonoBehaviour
    {
        private Dictionary<EnemyState, IEnemyState> _statesMap;
        private IEnemyState _currentState;

        private EnemyMovement _enemyMovement;
        private EnemyShooter _enemyShooter;
        private EnemyAnimatorController _enemyAnimatorController;

        private void Awake()
        {
            _enemyMovement = GetComponent<EnemyMovement>();
            _enemyShooter = GetComponent<EnemyShooter>();
            _enemyAnimatorController = GetComponent<EnemyAnimatorController>();

            InitializeState();
            SetStateByDefault();
        }

        private void Update()
        {
            if(_currentState != null)
            {
                _currentState.Update();
            }
        }

        public void SetState(EnemyState enemyState)
        {
            IEnemyState state = GetState(enemyState);
            ChangeState(state);
        }



        private void InitializeState()
        {
            _statesMap = new Dictionary<EnemyState, IEnemyState>()
            {
                [EnemyState.Idle] = new EnemyIdleState(),
                [EnemyState.Shooting] = new EnemyShootState(_enemyShooter, _enemyMovement, _enemyAnimatorController),
                [EnemyState.Moving] = new EnemyMoveState(_enemyMovement, _enemyAnimatorController),
                [EnemyState.Dying] = new EnemyDieState(_enemyShooter, _enemyMovement, _enemyAnimatorController)
            };
        }

        private void ChangeState(IEnemyState newState)
        {
            if(_currentState != null)
            {
                _currentState.Exit();
            }
            _currentState = newState;
            _currentState.Enter();
        }

        private void SetStateByDefault()
        {
            IEnemyState stateByDefault = GetState(EnemyState.Idle);
            ChangeState(stateByDefault);
        }

        private IEnemyState GetState(EnemyState enemyState)
        {
            return _statesMap[enemyState];
        }
    }
}
