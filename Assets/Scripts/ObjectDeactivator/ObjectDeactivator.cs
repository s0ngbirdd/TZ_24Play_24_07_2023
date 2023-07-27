using UnityEngine;

namespace ObjectDeactivator
{
    public class ObjectDeactivator : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.GetComponentInChildren<Wall.Wall>())
            {
                Wall.Wall wall = other.GetComponentInChildren<Wall.Wall>();
                wall.gameObject.SetActive(false);
            }
        
            if (other.GetComponentInChildren<CubePickup.CubePickup>())
            {
                CubePickup.CubePickup сubePickup = other.GetComponentInChildren<CubePickup.CubePickup>();
                сubePickup.gameObject.SetActive(false);
            }
        
            other.gameObject.SetActive(false);
        }
    }
}
