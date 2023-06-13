using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace _Scripts
{
    public class Weapon : MonoBehaviour
    {
        [SerializeField] private Camera FPCamera;
        [SerializeField] private float range = 100f;
        
        [SerializeField] private InputAction fire;


        private void OnEnable()
        {
            fire.Enable();
        }
        

        void Start()
        {
        
        }


        void Update()
        {
         ProcessFire();
        }

        private void OnDisable()
        {
            fire.Disable();
        }

        void ProcessFire()
        {
            if (fire.ReadValue<float>() > 0.5f)
            {
                RaycastHit hit;
                Physics.Raycast(FPCamera.transform.position, FPCamera.transform.forward, out hit, range);
                
                Debug.Log($"{name} hit: {hit.transform.name}");
            }
        }
    }
}
