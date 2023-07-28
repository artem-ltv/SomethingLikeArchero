using UnityEngine;

namespace SomethingLikeArchero
{
    [RequireComponent(typeof(Bullet))]
    public abstract class BulletCollisionHandler : MonoBehaviour
    {
        protected Bullet Bullet;

        private void Start()
        {
            Bullet = GetComponent<Bullet>();
        }
    }
}
