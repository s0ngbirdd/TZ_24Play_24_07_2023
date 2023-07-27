using System;
using UnityEngine;

public class CubeWall : MonoBehaviour
{
    private Track _track;

    /*private void OnEnable()
    {
        _track = GetComponentInParent<Track>();

        if (_track != null)
        {
            _track.OnTrackDisable += Unparent;
        }
    }

    private void OnDisable()
    {
        if (_track != null)
        {
            _track.OnTrackDisable -= Unparent;
        }
    }*/

    private void OnCollisionEnter(Collision collision)
    {
        CinemachineShake.Instance.ShakeCamera(7.0f, 0.3f);
        
        collision.transform.parent = null;
    }

    /*private void Unparent()
    {
        transform.parent = null;
    }*/
}
