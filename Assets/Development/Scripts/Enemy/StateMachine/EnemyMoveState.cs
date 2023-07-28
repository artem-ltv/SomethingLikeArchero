namespace SomethingLikeArchero
{
    public class EnemyMoveState : IEnemyState
    {
        private EnemyMovement _enemyMovement;
        private EnemyAnimatorController _enemyAnimatorController;

        public EnemyMoveState(EnemyMovement enemyMovement, EnemyAnimatorController enemyAnimatorController)
        {
            _enemyMovement = enemyMovement;
            _enemyAnimatorController = enemyAnimatorController;
        }

        public void Enter()
        {
            _enemyAnimatorController.EnableMovement();
        }

        public void Exit()
        {
            _enemyMovement.Stop();
        }

        public void Update()
        {
            _enemyMovement.Move();
        }
    }
}
