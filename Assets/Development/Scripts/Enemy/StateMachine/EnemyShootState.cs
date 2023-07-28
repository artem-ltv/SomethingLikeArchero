namespace SomethingLikeArchero
{
    public class EnemyShootState : IEnemyState
    {
        private EnemyShooter _enemyShooter;
        private EnemyMovement _enemyMovement;
        private EnemyAnimatorController _enemyAnimatorController;

        public EnemyShootState(EnemyShooter enemyShooter, EnemyMovement enemyMovement, EnemyAnimatorController enemyAnimatorController)
        {
            _enemyShooter = enemyShooter;
            _enemyMovement = enemyMovement;
            _enemyAnimatorController = enemyAnimatorController;
        }

        public void Enter()
        {
            _enemyAnimatorController.EnableAttack(true);
            _enemyShooter.StartShoot();
        }

        public void Exit()
        {
            _enemyAnimatorController.EnableAttack(false);
            _enemyShooter.StopShoot();
        }

        public void Update()
        {
            _enemyMovement.LookAtPlayer();
        }
    }
}
