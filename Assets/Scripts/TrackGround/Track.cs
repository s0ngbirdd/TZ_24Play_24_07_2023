using UnityEngine;

public class Track : MonoBehaviour
{
    [SerializeField] private float _timeBeforeDestroy = 2.0f;
    
    private TrackSpawner _trackSpawner;
    private bool _isTrackSpawned;

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
            
            // !!!DEACTIVATE!!!
            Destroy(gameObject, _timeBeforeDestroy);
        }
    }
}
