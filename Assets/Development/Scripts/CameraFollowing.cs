using UnityEngine;

namespace SomethingLikeArchero
{
    public class CameraFollowing : MonoBehaviour
    {
        [SerializeField] private Transform _player;
        [SerializeField] private float _moveSpeed;
        [SerializeField] private float _offsetZ;

        private Vector3 _targetPosition;
        private float _minPositionZ = 3.45f;
        private float _maxPositionZ = 7f;

        private void Update()
        {
            _targetPosition = new Vector3(transform.position.x, transform.position.y, _player.transform.position.z + _offsetZ);
            transform.position = Vector3.Lerp(transform.position, _targetPosition, _moveSpeed * Time.deltaTime);
        }

        private void LateUpdate()
        {
            if(transform.position.z < _minPositionZ)
            {
                SetPositionZ(_minPositionZ);
            }

            if(transform.position.z > _maxPositionZ)
            {
                SetPositionZ(_maxPositionZ);
            }
        }

        private void SetPositionZ(float positionZ)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, positionZ);
        }
    }
}
