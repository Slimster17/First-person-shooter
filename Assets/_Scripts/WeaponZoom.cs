using System;
using Cinemachine;
using StarterAssets;
using UnityEngine;
using UnityEngine.InputSystem;

namespace _Scripts
{
    public class WeaponZoom : MonoBehaviour
    {
        [SerializeField] private CinemachineVirtualCamera fpsCamera;
        [SerializeField] private FirstPersonController  fpsController;
        [SerializeField] private float zoomedOutFOV = 40f;
        [SerializeField] private float zoomedInFOV = 20f;

        [SerializeField] private float zoomOutSensetivity = 2.13f;
        [SerializeField] private float zoomInSensetivity = 1.13f;

        [SerializeField] private InputAction zoom;
        
       
        
        private bool zoomedInToggle = false;

        private void OnEnable()
        {
            zoom.Enable();
        }

        private void OnDisable()
        {
            zoom.Disable();
        }

       

        void Update()
        {
            if (zoom.triggered)
            {
                if (zoomedInToggle == false)
                {
                    zoomedInToggle = true;
                    fpsCamera.m_Lens.FieldOfView = zoomedInFOV;
                    fpsController.RotationSpeed = zoomInSensetivity;

                }
                else
                {
                    zoomedInToggle = false;
                    fpsCamera.m_Lens.FieldOfView = zoomedOutFOV;
                    fpsController.RotationSpeed = zoomOutSensetivity;
                }
            }
        }
    }
}
