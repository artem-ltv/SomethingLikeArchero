using UnityEngine;

namespace SomethingLikeArchero
{
    public class EnemyCollisionHandler : MonoBehaviour
    {
        [SerializeField] private int _damage;

        private void OnCollisionEnter(Collision collision)
        {
            if(collision.gameObject.TryGetComponent(out PlayerHealth playerHealth))
            {
                playerHealth.AddDamage(_damage);
            }
        }
    }
}
