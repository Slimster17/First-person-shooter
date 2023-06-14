using UnityEngine;

namespace _Scripts
{
    public class EnemyAttack : MonoBehaviour
    {

      
      [SerializeField] private float damage = 40f;

      private PlayerHealth target;
      
        void Start()
        {

           target = FindObjectOfType<PlayerHealth>();
        }

        public void AttackHitEvent()
        {
            if (target == null)
            {
                return;
            }

            if (target != null)
            {
                target.DecreaseHealth(damage);
               
            }
           
        }  
    }
}
