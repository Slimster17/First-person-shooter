using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace _Scripts
{
    public class WeaponSwitcher : MonoBehaviour
    {
        [SerializeField] private int currentWeapon = 0;

        [SerializeField] private InputAction weaponChoise;
        [SerializeField] private InputAction weaponScroll;
        public float mouseScrollY;

        private void OnEnable()
        {
            weaponScroll.Enable();
            weaponChoise.Enable();
            weaponChoise.performed += ProcessKeyInput;
            weaponScroll.performed += x => mouseScrollY = x.ReadValue<float>();
        }

        private void OnDisable()
        {
            weaponScroll.Disable();
            weaponChoise.Disable();
            weaponChoise.performed -= ProcessKeyInput;
        }

        // Start is called before the first frame update
        void Start()
        {
            SetWeaponActive();
        }

        private void SetWeaponActive()
        {
            int weaponIndex = 0;

            foreach (Transform weapon in transform)
            {
                if (weaponIndex == currentWeapon)
                {
                    weapon.gameObject.SetActive(true);
                }
                else
                {
                    weapon.gameObject.SetActive(false);
                }

                weaponIndex++;
            }
        }

        // Update is called once per frame
        void Update()
        {
            int previousWeapon = currentWeapon;
            // ProcessKeyInput();
            ProcessScrollWheel();

            if (previousWeapon != currentWeapon)
            {
                SetWeaponActive(); 
            }
        }

        private void ProcessKeyInput(InputAction.CallbackContext context)
        {
            string controlName = context.control.name;
            if (controlName == "1")
            {
                currentWeapon = 0;
            }
            else if (controlName == "2")
            {
                currentWeapon = 1;
            }
            else if (controlName == "3")
            {
                currentWeapon = 2;
            }

            SetWeaponActive();
        }

        private void ProcessScrollWheel()
        {
            if (mouseScrollY > 0)
            {
                Debug.Log("Scroll up");
                mouseScrollY = 0;
                currentWeapon++;
                if (currentWeapon >= transform.childCount)
                {
                    currentWeapon = 0;
                }
            }
            else if (mouseScrollY < 0)
            {
                Debug.Log("Scroll dwon");
                mouseScrollY = 0;
                currentWeapon--;
                if (currentWeapon < 0)
                {
                    currentWeapon = transform.childCount - 1;
                }
            } 
        }
    }
}
