using UnityEngine;

namespace SomethingLikeArchero
{
    public class EnemyAnimatorController : MonoBehaviour
    {
        [SerializeField] private Animator _animator;

        private string _moveParameter = "Move";
        private string _attackParameter = "Attack";
        private string _dieParameter = "Die";

        public void EnableMovement()
        {
            _animator.SetTrigger(_moveParameter);
        }

        public void EnableAttack(bool isEnable)
        {
            _animator.SetBool(_attackParameter, isEnable);
        }

        public void EnableDeath()
        {
            _animator.SetTrigger(_dieParameter);
        }
    }
}
