using UnityEngine;

namespace _Scripts
{
    public class AmmoPickUp : MonoBehaviour
    {

        [SerializeField] private int ammoAmount = 5;
        [SerializeField] private AmmoType ammoType;
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag == "Player")
            {
                FindObjectOfType<Ammo>().IncreaseCurrentAmmo(ammoType,ammoAmount);
                Destroy(gameObject);
            }
           
        }
        
     

        // Start is called before the first frame update
        void Start()
        {
        
        }

        // Update is called once per frame
        void Update()
        {
        
        }
    }
}
