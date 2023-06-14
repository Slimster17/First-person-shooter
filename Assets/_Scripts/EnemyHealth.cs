using UnityEngine;

namespace _Scripts
{
    public class EnemyHealth : MonoBehaviour
    {
        [SerializeField] private float hitPoints = 100f;

        public void DecreaseHeath(int damage)
        {
            if (hitPoints < 0)
            {
                Destroy(gameObject);
            }
            else
            {
                hitPoints -= damage;
            }
            
        }
    }
}
