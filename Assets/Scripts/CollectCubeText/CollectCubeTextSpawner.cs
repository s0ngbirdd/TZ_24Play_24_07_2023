using Player;
using UnityEngine;

namespace CollectCubeText
{
    public class CollectCubeTextSpawner : MonoBehaviour
    {
        private void OnEnable()
        {
            CubeStacker.OnStackCube += SpawnCollectCubeText;
        }

        private void OnDisable()
        {
            CubeStacker.OnStackCube -= SpawnCollectCubeText;
        }

        private void SpawnCollectCubeText()
        {
            GameObject collectCubeText = ObjectPool.ObjectPool.Instance.GetCollectCubeTextPooledObject();
            collectCubeText.transform.position = transform.position;
            collectCubeText.transform.rotation = Quaternion.identity;
            collectCubeText.SetActive(true);
        }
    }
}
