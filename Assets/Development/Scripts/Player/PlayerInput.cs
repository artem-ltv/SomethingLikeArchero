using UnityEngine;

namespace SomethingLikeArchero
{
    [RequireComponent(typeof(PlayerMovement))]
    [RequireComponent(typeof(PlayerShooter))]
    public class PlayerInput : MonoBehaviour
    {
        [SerializeField] private Joystick _joystick;
        [SerializeField] private Battle _battle;

        private PlayerMovement _movement;
        private PlayerShooter _shooter;
        private bool _canControll = false;

        private void OnEnable()
        {
            _battle.Starting += GiveControl;
        }

        private void OnDisable()
        {
            _battle.Starting -= GiveControl;
        }

        private void Start()
        {
            _movement = GetComponent<PlayerMovement>();
            _shooter = GetComponent<PlayerShooter>();
        }

        private void FixedUpdate()
        {
            if (_canControll)
            {
                Vector3 direction = (Vector3.forward * _joystick.Vertical + Vector3.right * _joystick.Horizontal);
                _movement.Move(direction);

                if (_joystick.Horizontal != 0 || _joystick.Vertical != 0)
                {
                    _movement.Rotate(direction);
                    _shooter.StopShoot();
                }
                else
                {
                    _shooter.StartShoot();
                }
            }
        }

        private void GiveControl()
        {
            _canControll = true;
        }
    }
}
