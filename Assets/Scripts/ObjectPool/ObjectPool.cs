using System.Collections.Generic;
using UnityEngine;

namespace ObjectPool
{
    public class ObjectPool : MonoBehaviour
    {
        public static ObjectPool Instance;

        [SerializeField] private GameObject _trackPrefab;
        [SerializeField] private GameObject _pickupCubePrefab;
        [SerializeField] private GameObject _collectCubeTextPrefab;
        
        [Header("Walls")]
        [SerializeField] private GameObject _wall1Prefab;
        [SerializeField] private GameObject _wall2Prefab;
        [SerializeField] private GameObject _wall3Prefab;
        [SerializeField] private GameObject _wall4Prefab;
        [SerializeField] private GameObject _wall5Prefab;
        
        [Space]
        [SerializeField] private int _poolNumber = 5;

        private List<GameObject> _trackPooledObjects;
        private List<GameObject> _pickupCubePooledObjects;
        private List<GameObject> _collectCubeTextPooledObjects;
        
        private List<GameObject> _wall1PooledObjects;
        private List<GameObject> _wall2PooledObjects;
        private List<GameObject> _wall3PooledObjects;
        private List<GameObject> _wall4PooledObjects;
        private List<GameObject> _wall5PooledObjects;
    
        private GameObject tempObject;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            else
            {
                Destroy(gameObject);
                return;
            }
        }

        private void Start()
        {
            _trackPooledObjects = new List<GameObject>();
            _pickupCubePooledObjects = new List<GameObject>();
            _collectCubeTextPooledObjects = new List<GameObject>();
            
            _wall1PooledObjects = new List<GameObject>();
            _wall2PooledObjects = new List<GameObject>();
            _wall3PooledObjects = new List<GameObject>();
            _wall4PooledObjects = new List<GameObject>();
            _wall5PooledObjects = new List<GameObject>();
        
            InstantiateObjectsOnStart(_poolNumber, _trackPrefab, _trackPooledObjects);
            InstantiateObjectsOnStart(_poolNumber, _pickupCubePrefab, _pickupCubePooledObjects);
            InstantiateObjectsOnStart(_poolNumber, _collectCubeTextPrefab, _collectCubeTextPooledObjects);
            
            InstantiateObjectsOnStart(_poolNumber, _wall1Prefab, _wall1PooledObjects);
            InstantiateObjectsOnStart(_poolNumber, _wall2Prefab, _wall2PooledObjects);
            InstantiateObjectsOnStart(_poolNumber, _wall3Prefab, _wall3PooledObjects);
            InstantiateObjectsOnStart(_poolNumber, _wall4Prefab, _wall4PooledObjects);
            InstantiateObjectsOnStart(_poolNumber, _wall5Prefab, _wall5PooledObjects);
        }
    
        public GameObject GetTrackPooledObject()
        {
            for (int i = 0; i < _trackPooledObjects.Count; i++)
            {
                if (!_trackPooledObjects[i].activeInHierarchy)
                {
                    return _trackPooledObjects[i];
                }
            }

            return InstantiateObject(_trackPrefab, _trackPooledObjects);
        }
        
        public GameObject GetPickupCubePooledObject()
        {
            for (int i = 0; i < _pickupCubePooledObjects.Count; i++)
            {
                if (!_pickupCubePooledObjects[i].activeInHierarchy)
                {
                    return _pickupCubePooledObjects[i];
                }
            }

            return InstantiateObject(_pickupCubePrefab, _pickupCubePooledObjects);
        }

        public GameObject GetCollectCubeTextPooledObject()
        {
            for (int i = 0; i < _collectCubeTextPooledObjects.Count; i++)
            {
                if (!_collectCubeTextPooledObjects[i].activeInHierarchy)
                {
                    return _collectCubeTextPooledObjects[i];
                }
            }

            return InstantiateObject(_collectCubeTextPrefab, _collectCubeTextPooledObjects);
        }
        
        public GameObject GetWall1PooledObject()
        {
            for (int i = 0; i < _wall1PooledObjects.Count; i++)
            {
                if (!_wall1PooledObjects[i].activeInHierarchy)
                {
                    return _wall1PooledObjects[i];
                }
            }

            return InstantiateObject(_wall1Prefab, _wall1PooledObjects);
        }
        
        public GameObject GetWall2PooledObject()
        {
            for (int i = 0; i < _wall2PooledObjects.Count; i++)
            {
                if (!_wall2PooledObjects[i].activeInHierarchy)
                {
                    return _wall2PooledObjects[i];
                }
            }

            return InstantiateObject(_wall2Prefab, _wall2PooledObjects);
        }
        
        public GameObject GetWall3PooledObject()
        {
            for (int i = 0; i < _wall3PooledObjects.Count; i++)
            {
                if (!_wall3PooledObjects[i].activeInHierarchy)
                {
                    return _wall3PooledObjects[i];
                }
            }

            return InstantiateObject(_wall3Prefab, _wall3PooledObjects);
        }
        
        public GameObject GetWall4PooledObject()
        {
            for (int i = 0; i < _wall4PooledObjects.Count; i++)
            {
                if (!_wall4PooledObjects[i].activeInHierarchy)
                {
                    return _wall4PooledObjects[i];
                }
            }

            return InstantiateObject(_wall4Prefab, _wall4PooledObjects);
        }
        
        public GameObject GetWall5PooledObject()
        {
            for (int i = 0; i < _wall5PooledObjects.Count; i++)
            {
                if (!_wall5PooledObjects[i].activeInHierarchy)
                {
                    return _wall5PooledObjects[i];
                }
            }

            return InstantiateObject(_wall5Prefab, _wall5PooledObjects);
        }

        private void InstantiateObjectsOnStart(int instantiateNumber, GameObject objectPrefab, List<GameObject> objectPool)
        {
            for (int i = 0; i < instantiateNumber; i++)
            {
                tempObject = Instantiate(objectPrefab, transform);
                tempObject.SetActive(false);
                objectPool.Add(tempObject);
            }
        }
    
        private GameObject InstantiateObject(GameObject objectPrefab, List<GameObject> objectPool)
        {
            tempObject = Instantiate(objectPrefab, transform);
            tempObject.SetActive(false);
            objectPool.Add(tempObject);

            return tempObject;
        }
    }
}
