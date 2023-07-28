using UnityEngine;
using UnityEngine.Events;
using TMPro;

namespace SomethingLikeArchero
{
    public abstract class Health : MonoBehaviour
    {
        public UnityAction Dying;

        [SerializeField] protected TMP_Text HealthPointDisplay;
        [SerializeField] protected int HealthPoint;

        public void AddDamage(int damage)
        {
            HealthPoint -= damage;
            if (HealthPoint <= 0)
            {
                HealthPoint = 0;
                Die();
            }
            UpdateHealthPointDisplay();
        }

        public virtual void Die()
        {
            Dying?.Invoke();
        }

        protected void UpdateHealthPointDisplay()
        {
            HealthPointDisplay.text = HealthPoint.ToString();
        }
    }
}
