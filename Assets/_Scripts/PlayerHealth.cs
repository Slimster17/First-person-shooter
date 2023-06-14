using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{

    [SerializeField] private float health = 100f;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DecreaseHealth(float damage)
    {
        if (health < 0)
        {
            Debug.Log("Died");
            GetComponent<DeathHandler>().HandleDeath();
        }
        else
        {
            health -= damage; 
        }
       
    }
}
