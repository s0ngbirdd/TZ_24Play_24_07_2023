using UnityEngine;
using Random = UnityEngine.Random;

public class CubePickupSpawner : MonoBehaviour
{
    //[SerializeField] private GameObject _cubePickupPrefab;
    [SerializeField] private float _spawnPositionXOffset = 1.5f;
    //[SerializeField] private TrackSpawner _trackSpawner;

    /*private void Start()
    {
        //SpawnCubeAtRandomPosition();
        FindObjectOfType<TrackSpawner>().OnSpawnTrack += SpawnCubeAtRandomPosition;
    }*/

    private void OnEnable()
    {
        //Debug.Log("SPAWN");
        SpawnCubeAtRandomPosition();
    }

    /*private void OnDisable()
    {
        Debug.Log("---");
    }*/

    /*private void OnEnable()
    {
        _trackSpawner.OnSpawnTrack += SpawnCubeAtRandomPosition;
    }

    private void OnDisable()
    {
        _trackSpawner.OnSpawnTrack -= SpawnCubeAtRandomPosition;
    }*/

    private void SpawnCubeAtRandomPosition()
    {
        int index = Random.Range(0, 3);

        if (index == 0)
        {
            SpawnCube(-_spawnPositionXOffset);
            
            /*GameObject pickupCube = ObjectPool.ObjectPool.Instance.GetPickupCubePooledObject();
            pickupCube.transform.SetParent(transform);
            pickupCube.transform.localPosition = Vector3.zero; //new Vector3(transform.position.x - _spawnPositionXOffset, transform.position.y, transform.position.z);
            pickupCube.transform.rotation = Quaternion.identity;
            
            pickupCube.SetActive(true);
            pickupCube.layer = LayerMask.NameToLayer("Pickup");*/
            
            //GameObject obj = Instantiate(_cubePickupPrefab, new Vector3(transform.position.x - _spawnPositionXOffset, transform.position.y, transform.position.z), Quaternion.identity);
        }
        else if (index == 1)
        {
            SpawnCube(0);
            
            /*GameObject pickupCube = ObjectPool.ObjectPool.Instance.GetPickupCubePooledObject();
            pickupCube.transform.SetParent(transform);
            pickupCube.transform.localPosition = Vector3.zero; //new Vector3(transform.position.x, transform.position.y, transform.position.z);
            pickupCube.transform.rotation = Quaternion.identity;
            
            pickupCube.SetActive(true);
            pickupCube.layer = LayerMask.NameToLayer("Pickup");*/

            //GameObject obj = Instantiate(_cubePickupPrefab, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
        }
        else if (index == 2)
        {
            SpawnCube(_spawnPositionXOffset);
            
            /*GameObject pickupCube = ObjectPool.ObjectPool.Instance.GetPickupCubePooledObject();
            pickupCube.transform.SetParent(transform);
            pickupCube.transform.localPosition = Vector3.zero; //new Vector3(transform.position.x + _spawnPositionXOffset, transform.position.y, transform.position.z);
            pickupCube.transform.rotation = Quaternion.identity;
            
            pickupCube.SetActive(true);
            pickupCube.layer = LayerMask.NameToLayer("Pickup");*/
            
            //GameObject obj = Instantiate(_cubePickupPrefab, new Vector3(transform.position.x + _spawnPositionXOffset, transform.position.y, transform.position.z), Quaternion.identity);
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
