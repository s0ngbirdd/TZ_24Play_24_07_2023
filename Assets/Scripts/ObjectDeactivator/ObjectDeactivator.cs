using UnityEngine;

public class ObjectDeactivator : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponentInChildren<Wall>())
        {
            Wall wall = other.GetComponentInChildren<Wall>();
            wall.gameObject.SetActive(false);
        }
        
        if (other.GetComponentInChildren<CubePickup>())
        {
            CubePickup сubePickup = other.GetComponentInChildren<CubePickup>();
            сubePickup.gameObject.SetActive(false);
        }
        
        other.gameObject.SetActive(false);
    }
}
