using CameraShake;
using UnityEngine;

namespace Wall
{
    public class CubeWall : MonoBehaviour
    {
        private void OnCollisionEnter(Collision collision)
        {
            CinemachineShake.Instance.ShakeCamera(7.0f, 0.3f);
        
            collision.transform.parent = null;
        }
    }
}
