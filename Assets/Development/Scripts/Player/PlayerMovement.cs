using UnityEngine;

namespace SomethingLikeArchero
{
    [RequireComponent(typeof(Rigidbody))]
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private float _moveSpeed;
        [SerializeField] private float _rotateSpeed;

        private Rigidbody _rigidbody;

        private void Start()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }

        public void Move(Vector3 direction)
        {
            _rigidbody.velocity = direction * _moveSpeed;
        }

        public void Rotate(Vector3 direction)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(direction), _rotateSpeed * Time.deltaTime); 
        }

        public void LookAtEnemy(Enemy enemy)
        {
            Vector3 direction = (enemy.transform.position - transform.position).normalized;
            Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0f, direction.z));
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, _rotateSpeed * Time.deltaTime);
        }
    }
}
