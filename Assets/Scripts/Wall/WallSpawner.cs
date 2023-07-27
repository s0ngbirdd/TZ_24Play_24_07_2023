using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class WallSpawner : MonoBehaviour
{
    [SerializeField] private List<GameObject> _walls;
    
    private GameObject wall;
    private bool _isFirstSpawn = true;

    /*private void Start()
    {
        SpawnRandomWall();
    }*/

    private void OnEnable()
    {
        //Debug.Log("WALL");

        if (_isFirstSpawn)
        {
            _isFirstSpawn = false;
        }
        else
        {
            SpawnRandomWall();
        }
    }

    private void SpawnRandomWall()
    {
        int index = Random.Range(0, _walls.Count);

        if (index == 0)
        {
            wall = ObjectPool.ObjectPool.Instance.GetWall1PooledObject();
        }
        else if (index == 1)
        {
            wall = ObjectPool.ObjectPool.Instance.GetWall2PooledObject();
        }
        else if (index == 2)
        {
            wall = ObjectPool.ObjectPool.Instance.GetWall3PooledObject();
        }
        else if (index == 3)
        {
            wall = ObjectPool.ObjectPool.Instance.GetWall4PooledObject();
        }
        else if (index == 4)
        {
            wall = ObjectPool.ObjectPool.Instance.GetWall5PooledObject();
        }
        
        wall.transform.position = transform.position;
        wall.transform.rotation = Quaternion.identity;
        wall.transform.SetParent(transform);
        wall.SetActive(true);
        
        
        /*GameObject obj = Instantiate(_walls[index], transform.position, Quaternion.identity);
        obj.transform.SetParent(transform);*/
    }
}
