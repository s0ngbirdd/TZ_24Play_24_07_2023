using UnityEngine;

public class CubePickupSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _cubePickupPrefab;
    [SerializeField] private float _spawnPositionXOffset = 1.5f;

    private void Start()
    {
        SpawnCubeAtRandomPosition();
    }

    private void SpawnCubeAtRandomPosition()
    {
        int index = Random.Range(0, 3);

        if (index == 0)
        {
            GameObject obj = Instantiate(_cubePickupPrefab, new Vector3(transform.position.x - _spawnPositionXOffset, transform.position.y, transform.position.z), Quaternion.identity);
            obj.transform.SetParent(transform);
        }
        else if (index == 1)
        {
            GameObject obj = Instantiate(_cubePickupPrefab, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
            obj.transform.SetParent(transform);
        }
        else if (index == 2)
        {
            GameObject obj = Instantiate(_cubePickupPrefab, new Vector3(transform.position.x + _spawnPositionXOffset, transform.position.y, transform.position.z), Quaternion.identity);
            obj.transform.SetParent(transform);
        }
    }
}
