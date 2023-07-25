using UnityEngine;

public class Wall : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        CinemachineShake.Instance.ShakeCamera(7.0f, 0.3f);
        
        collision.transform.parent = null;
    }
}
