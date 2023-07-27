using UnityEngine;

namespace MeshCombiner
{
    [RequireComponent(typeof(global::MeshCombiner.MeshCombiner))]
    public class StartMeshCombiner : MonoBehaviour
    {
        private global::MeshCombiner.MeshCombiner _meshCombiner;

        private void Awake()
        {
            _meshCombiner = GetComponent<global::MeshCombiner.MeshCombiner>();
            _meshCombiner.DeactivateCombinedChildren = false;
            _meshCombiner.DeactivateCombinedChildrenMeshRenderers = true;
            _meshCombiner.CombineMeshes(false);
        }
    }
}
