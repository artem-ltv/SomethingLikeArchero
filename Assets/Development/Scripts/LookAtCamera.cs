using UnityEngine;

namespace SomethingLikeArchero
{
    public class LookAtCamera : MonoBehaviour
    {
        private Camera _camera;

        private void Start()
        {
            _camera = Camera.main;
        }

        private void LateUpdate()
        {
            if (_camera != null)
            {
                transform.LookAt(_camera.transform);
            }
        }
    }
}
