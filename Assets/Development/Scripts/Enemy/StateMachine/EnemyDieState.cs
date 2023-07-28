namespace SomethingLikeArchero
{
    public class EnemyDieState : IEnemyState
    {
        private EnemyShooter _enemyShooter;
        private EnemyMovement _enemyMovement;
        private EnemyAnimatorController _enemyAnimatorController;

        public EnemyDieState(EnemyShooter enemyShooter, EnemyMovement enemyMovement, EnemyAnimatorController enemyAnimatorController)
        {
            _enemyShooter = enemyShooter;
            _enemyMovement = enemyMovement;
            _enemyAnimatorController = enemyAnimatorController;
        }

        public void Enter()
        {
            _enemyMovement.Stop();
            _enemyShooter.StopShoot();
            _enemyAnimatorController.EnableDeath();
        }

        public void Exit()
        {
            //
        }

        public void Update()
        {
            //
        }
    }
}
