using UnityEngine;
using Random = UnityEngine.Random;

namespace Wall
{
    public class WallSpawner : MonoBehaviour
    {
        private GameObject _wall;
        private bool _isFirstSpawn = true;

        private void OnEnable()
        {
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
            int index = Random.Range(0, 5);

            if (index == 0)
            {
                _wall = ObjectPool.ObjectPool.Instance.GetWall1PooledObject();
            }
            else if (index == 1)
            {
                _wall = ObjectPool.ObjectPool.Instance.GetWall2PooledObject();
            }
            else if (index == 2)
            {
                _wall = ObjectPool.ObjectPool.Instance.GetWall3PooledObject();
            }
            else if (index == 3)
            {
                _wall = ObjectPool.ObjectPool.Instance.GetWall4PooledObject();
            }
            else if (index == 4)
            {
                _wall = ObjectPool.ObjectPool.Instance.GetWall5PooledObject();
            }
        
            _wall.transform.position = transform.position;
            _wall.transform.rotation = Quaternion.identity;
            _wall.transform.SetParent(transform);
            _wall.SetActive(true);
        }
    }
}
