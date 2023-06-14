using UnityEngine;

namespace _Scripts
{
    public class EnemyAttack : MonoBehaviour
    {
      [SerializeField]  private Transform target;
      
      [SerializeField] private float damage = 40f;

      private PlayerHealth playerHealth;
      
        void Start()
        {

           playerHealth = FindObjectOfType<PlayerHealth>();
        }

        public void AttackHitEvent()
        {
            if (target == null)
            {
                return;
            }
            Debug.Log("Bang bang");

            if (playerHealth != null)
            {
                playerHealth.DecreaseHealth(damage);
            }
           
        }  
    }
}
