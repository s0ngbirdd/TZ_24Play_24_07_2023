using UnityEngine;

public class Track : MonoBehaviour
{
    private TrackSpawner _trackSpawner;
    private bool _isTrackSpawned;

    private void OnDisable()
    {
        _isTrackSpawned = false;
    }
    
    private void Start()
    {
        _trackSpawner = FindObjectOfType<TrackSpawner>();
    }

    private void OnTriggerExit(Collider other)
    {
        if (!_isTrackSpawned)
        {
            _isTrackSpawned = true;
            _trackSpawner.SpawnTrack(true);
        }
    }
}
