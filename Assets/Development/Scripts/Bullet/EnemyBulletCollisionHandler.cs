using UnityEngine;

namespace SomethingLikeArchero
{
    public class EnemyBulletCollisionHandler : BulletCollisionHandler
    {
        private void OnTriggerEnter(Collider other)
        {
            int damage = Bullet.Damage;

            if (other.TryGetComponent(out PlayerHealth playerHealth))
            {
                playerHealth.AddDamage(damage);
            }

            Bullet.DestroyBullet();
        }
    }
}
