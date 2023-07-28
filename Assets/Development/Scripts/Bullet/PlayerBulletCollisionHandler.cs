using UnityEngine;

namespace SomethingLikeArchero
{
    public class PlayerBulletCollisionHandler : BulletCollisionHandler
    {
        private void OnTriggerEnter(Collider other)
        {
            int damage = Bullet.Damage;

            if (other.TryGetComponent(out EnemyHealth enemyHealth))
            {
               enemyHealth.AddDamage(damage);
            }

            Bullet.DestroyBullet();
        }
    }
}
