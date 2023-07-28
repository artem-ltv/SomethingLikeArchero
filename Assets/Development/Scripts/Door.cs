using UnityEngine;
using DG.Tweening;

namespace SomethingLikeArchero
{
    public class Door : MonoBehaviour
    {
        [SerializeField] private Battle _battle;

        private float _timeOpen = 1f;
        private float _finishY = -0.45f;

        private void OnEnable()
        {
            _battle.Ending += Open;
        }

        private void OnDisable()
        {
            _battle.Ending -= Open;
        }

        public void Open()
        {
            transform.DOMoveY(_finishY, _timeOpen);
        }
    }
}
