using System.Collections;
using UnityEngine;

namespace SomethingLikeArchero
{
    public abstract class Shooter : MonoBehaviour
    {
        [SerializeField] protected Bullet Bullet;
        [SerializeField] protected Transform ShotPoint; 
        [SerializeField] protected float DelayBetweenShoots;
        [SerializeField] protected int BulletDamage;

        protected Coroutine ShootCoroutine;

        public virtual void StartShoot()
        {
            if (ShootCoroutine == null)
            {
                ShootCoroutine = StartCoroutine(Shoot(DelayBetweenShoots));
            }
        }

        public void StopShoot()
        {
            if (ShootCoroutine != null)
            {
                StopCoroutine(ShootCoroutine);
                ShootCoroutine = null;
            }
        }

        protected IEnumerator Shoot(float delay)
        {
            var waitForSecond = new WaitForSeconds(delay);

            while (true)
            {
                yield return waitForSecond;
                Shot();
            }
        }

        protected void Shot()
        {
            Bullet newBullet = Instantiate(Bullet, ShotPoint.position, transform.rotation);
            newBullet.SetDamage(BulletDamage);
        }
    }
}
