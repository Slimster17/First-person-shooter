using System;
using UnityEngine;

namespace _Scripts
{
    public class FlashlightSystem : MonoBehaviour
    {

        [SerializeField] private float lightDecay = .1f;

        [SerializeField] private float angleDecay = 1f;
        [SerializeField] private float minimumAngle = 40f;

        private Light myLight;

        private void Start()
        {
            myLight = GetComponent<Light>();
            
        }

        private void Update()
        {
            DecreaseLightAngle();
            DecreaseLightIntensity();
        }

       

        private void DecreaseLightAngle()
        {
            if (myLight.spotAngle <= minimumAngle)
            {
                return;
            }
            else
            {
                myLight.spotAngle -= angleDecay * Time.deltaTime;
            }
           
        }
        
        private void DecreaseLightIntensity()
        {
            myLight.intensity -= lightDecay * Time.deltaTime;
        }

        public void RestoreLightAngle(float restoreAnge)
        {
            myLight.spotAngle = restoreAnge;
        }

        public void AddLightIntensity(float intesityAmount)
        {
            myLight.intensity += intesityAmount;
        }
    }
}
