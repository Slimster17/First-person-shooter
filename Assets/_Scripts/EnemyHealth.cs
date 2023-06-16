using UnityEngine;

namespace _Scripts
{
    public class EnemyHealth : MonoBehaviour
    {
        [SerializeField] private float hitPoints = 100f;

        private bool isDead = false;

        public bool IsDead()
        {
            return isDead;
        }
        

        public void DecreaseHeath(int damage)
        {
            
            BroadcastMessage("OnDamageTaken");
            if (hitPoints < 0)
            {
                Die();

            }
            else
            {
                hitPoints -= damage;
            
            }
            
        }

        private void Die()
        {
            if (isDead)
            {
                return;
                
            }
            isDead = true;
            GetComponent<Animator>().SetTrigger("die");
        }
    }
}
