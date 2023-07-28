using UnityEngine;

namespace SomethingLikeArchero
{
    public class EnemyHealth : Health
    {
        public override void Die()
        {
            HealthPointDisplay.enabled = false;
            base.Die();
        }
    }
}
