using UnityEngine;

namespace _Scripts
{
    public class BatteryPickup : MonoBehaviour
    {
        [SerializeField] float lightAngle = 60f;
        [SerializeField] private float lightIntensity = 5f;

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag == "Player")
            {
            
                other.GetComponentInChildren<FlashlightSystem>().RestoreLightAngle(lightAngle);
                other.GetComponentInChildren<FlashlightSystem>().AddLightIntensity(lightIntensity);
                Destroy(this.gameObject);
            }
        }
    }
}
