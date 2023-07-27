using UnityEngine;

public class CollectCubeTextSpawner : MonoBehaviour
{
    //[SerializeField] private GameObject _collectCubeTextPrefab;
    //[SerializeField] private Transform _parentObjectTransform;

    private void OnEnable()
    {
        CubeStacker.OnStackCube += SpawnCollectCubetext;
    }

    private void OnDisable()
    {
        CubeStacker.OnStackCube -= SpawnCollectCubetext;
    }

    private void SpawnCollectCubetext()
    {
        GameObject collectCubetext = ObjectPool.ObjectPool.Instance.GetCollectCubeTextPooledObject();
        collectCubetext.transform.position = transform.position;
        collectCubetext.transform.rotation = Quaternion.identity;
        collectCubetext.SetActive(true);
        
        //GameObject obj = Instantiate(_collectCubeTextPrefab, transform.position, Quaternion.identity);
        //obj.transform.SetParent(_parentObjectTransform, true);
    }
}
