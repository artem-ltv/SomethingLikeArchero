using UnityEngine;
using UnityEngine.AI;

namespace SomethingLikeArchero
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class EnemyMovement : MonoBehaviour
    {
        [SerializeField] private float _moveSpeed;
        [SerializeField] private float _rotateSpeed;

        private Player _player;
        private NavMeshAgent _navMeshAgent;

        private void Start()
        {
            _navMeshAgent = GetComponent<NavMeshAgent>();
            _navMeshAgent.speed = _moveSpeed;
        }

        public void SetPlayer(Player player)
        {
            _player = player;
        }

        public void Move()
        {
            _navMeshAgent.SetDestination(_player.transform.position);
        }

        public void Stop()
        {
            _navMeshAgent.ResetPath();
        }

        public void LookAtPlayer()
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(_player.transform.position - transform.position), _rotateSpeed * Time.deltaTime);
        }

        public void DisableNavMeshAgent()
        {
            _navMeshAgent.enabled = false;
        }
    }
}
