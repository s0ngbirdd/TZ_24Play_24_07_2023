using UnityEngine;
using Random = UnityEngine.Random;

namespace CubePickup
{
    public class CubePickupSpawner : MonoBehaviour
    {
        [SerializeField] private float _spawnPositionXOffset = 1.5f;
    
        private void OnEnable()
        {
            SpawnCubeAtRandomPosition();
        }

        private void SpawnCubeAtRandomPosition()
        {
            int index = Random.Range(0, 3);

            if (index == 0)
            {
                SpawnCube(-_spawnPositionXOffset);
            }
            else if (index == 1)
            {
                SpawnCube(0);
            }
            else if (index == 2)
            {
                SpawnCube(_spawnPositionXOffset);
            }
        }

        private void SpawnCube(float spawnPositionXOffset)
        {
            GameObject pickupCube = ObjectPool.ObjectPool.Instance.GetPickupCubePooledObject();
            pickupCube.transform.position = new Vector3(transform.position.x + spawnPositionXOffset, transform.position.y, transform.position.z);
            pickupCube.transform.rotation = Quaternion.identity;
            pickupCube.transform.SetParent(transform);
            pickupCube.layer = LayerMask.NameToLayer("Pickup");
            pickupCube.GetComponent<Collider>().isTrigger = true;
            Destroy(pickupCube.GetComponent<Rigidbody>());
            pickupCube.SetActive(true);
        }
    }
}
