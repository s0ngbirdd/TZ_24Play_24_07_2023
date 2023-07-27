using UnityEngine;

namespace TrackGround
{
    public class TrackGround : MonoBehaviour
    {
        private TrackGroundSpawner _trackGroundSpawner;
        private bool _isTrackSpawned;

        private void OnDisable()
        {
            _isTrackSpawned = false;
        }
    
        private void Start()
        {
            _trackGroundSpawner = FindObjectOfType<TrackGroundSpawner>();
        }

        private void OnTriggerExit(Collider other)
        {
            if (!_isTrackSpawned)
            {
                _isTrackSpawned = true;
                _trackGroundSpawner.SpawnTrack(true);
            }
        }
    }
}
