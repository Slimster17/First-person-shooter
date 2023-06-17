using System;
using System.Collections;
using System.Security.Cryptography;
using TMPro;
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
        [SerializeField] private float timeBetweenShot = 0.5f;
        [SerializeField] private AmmoType ammoType;

        [SerializeField] private TextMeshProUGUI ammotext;

        private bool canShoot = true;
        


        private void OnEnable()
        {
            fire.Enable();
            canShoot = true;
        }
        

        void Start()
        {
          
        }


        void Update()
        {
            DisplayAmmo();
            if (fire.triggered && fire.ReadValue<float>() > 0f && canShoot == true)
            {
                StartCoroutine("ProcessFire");
            }
         
        }

        private void DisplayAmmo()
        {
            int currentAmmo = ammoSlot.GetCurrentAmmo(ammoType);
            ammotext.text = currentAmmo.ToString();
        }

        private void OnDisable()
        {
            fire.Disable();
        }
        
        IEnumerator ProcessFire()
        {
            canShoot = false;
         
                if (ammoSlot.GetCurrentAmmo(ammoType) > 0)
                {
                    PlayMuzzleFlash();
                    ProcessRayCast();
                    ammoSlot.ReduceCurrentAmmo(ammoType);
                }
                
                yield return new WaitForSeconds(timeBetweenShot);
            canShoot = true;
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
