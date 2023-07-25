using System.Collections.Generic;
using UnityEngine;

public class WallSpawner : MonoBehaviour
{
    [SerializeField] private List<GameObject> _walls;

    private void Start()
    {
        SpawnRandomWall();
    }

    private void SpawnRandomWall()
    {
        int index = Random.Range(0, _walls.Count);
        GameObject obj = Instantiate(_walls[index], transform.position, Quaternion.identity);
        obj.transform.SetParent(transform);
    }
}
