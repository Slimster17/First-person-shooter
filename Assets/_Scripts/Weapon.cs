using System;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.InputSystem;

namespace _Scripts
{
    public class Weapon : MonoBehaviour
    {
        [SerializeField] private Camera FPCamera;
        [SerializeField] private float range = 100f;
        
        [SerializeField] private InputAction fire;

        [SerializeField] private int damage = 10;

        [SerializeField] private ParticleSystem muzzleFlash;
        [SerializeField] private GameObject hitEffect;
        
        [SerializeField] private Ammo ammoSlot;
        
        


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
            if (fire.triggered && fire.ReadValue<float>() > 0f)
            {
                if (ammoSlot.AmmoAmmount > 0)
                {
                    PlayMuzzleFlash();
                    ProcessRayCast();
                    ammoSlot.ReduceCurrentAmmo();
                }
                
            }
        }

        private void PlayMuzzleFlash()
        {
            muzzleFlash.Play();
        }

        private void ProcessRayCast()
        {
            RaycastHit hit;

            if (Physics.Raycast(FPCamera.transform.position, FPCamera.transform.forward, out hit, range))
            {
                Debug.Log($"{name} hit: {hit.transform.name}");
                CreateHitImpact(hit);
                EnemyHealth target = hit.transform.GetComponent<EnemyHealth>();
                if (target != null)
                {
                    target.DecreaseHeath(damage);
                }
            }
            else
            {
                return;
            }
        }

        private void CreateHitImpact(RaycastHit hit)
        {
            GameObject impact = Instantiate(hitEffect, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(impact,1);
        }
    }
}
