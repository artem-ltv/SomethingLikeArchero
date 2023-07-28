using UnityEngine;
using UnityEngine.Events;

namespace SomethingLikeArchero
{
    public class Finish : MonoBehaviour
    {
        public UnityAction Finishing;

        private void OnTriggerEnter(Collider other)
        {
            if(other.TryGetComponent(out Player player))
            {
                Finishing?.Invoke();
            }
        }
    }
}
