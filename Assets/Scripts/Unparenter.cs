using UnityEngine;

public class Unparenter : MonoBehaviour
{
    private void OnDisable()
    {
        transform.parent = null;
    }
}
