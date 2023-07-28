using UnityEngine;

namespace SomethingLikeArchero
{
    public class Bullet : MonoBehaviour
    {
        public int Damage => _damage;

        [SerializeField] private float _speed;

        private int _damage;

        private void Update()
        {
            transform.Translate(Vector3.forward * _speed * Time.deltaTime);
        }

        public void SetDamage(int damage)
        {
            _damage = damage;
        }

        public void DestroyBullet()
        {
            Destroy(gameObject);
        }
    }
}
