using UnityEngine;

public class RagdollSpawner : MonoBehaviour
{
    [SerializeField] private Transform _ragdollPrefab;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Transform ragdollTransform = Instantiate(_ragdollPrefab, transform.position, transform.rotation);
            MatchAllChildTransforms(transform, ragdollTransform);
            Destroy(gameObject);
        }
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
