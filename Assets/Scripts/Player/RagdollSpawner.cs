using UnityEngine;

namespace Player
{
    public class RagdollSpawner : MonoBehaviour
    {
        [SerializeField] private Transform _ragdollPrefab;
    
        private void OnEnable()
        {
            GameEnder.OnGameEnd += SpawnRagdoll;
        }

        private void OnDisable()
        {
            GameEnder.OnGameEnd -= SpawnRagdoll;
        }

        private void SpawnRagdoll()
        {
            Transform ragdollTransform = Instantiate(_ragdollPrefab, transform.position, transform.rotation);
            MatchAllChildTransforms(transform, ragdollTransform);
            Destroy(gameObject);
        }

        private void MatchAllChildTransforms(Transform root, Transform clone)
        {
            foreach (Transform child in root)
            {
                Transform cloneChild = clone.Find(child.name);

                if (cloneChild != null)
                {
                    cloneChild.position = child.position;
                    cloneChild.rotation = child.rotation;
                
                    MatchAllChildTransforms(child, cloneChild);
                }
            }
        }
    }
}
