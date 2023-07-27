using UnityEngine;

[RequireComponent(typeof(MeshCombiner))]
public class StartMeshCombiner : MonoBehaviour
{
    private MeshCombiner _meshCombiner;

    private void Awake()
    {
        _meshCombiner = GetComponent<MeshCombiner>();

        _meshCombiner.DeactivateCombinedChildren = false;
        _meshCombiner.DeactivateCombinedChildrenMeshRenderers = true;
        _meshCombiner.CombineMeshes(false);
    }
}
