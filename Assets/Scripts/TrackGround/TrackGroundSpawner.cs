using DG.Tweening;
using UnityEngine;

namespace TrackGround
{
    public class TrackGroundSpawner : MonoBehaviour
    {
        [Header("Start Spawn")]
        [SerializeField] private GameObject _trackGroundStartPrefab;
        [SerializeField] private int _numberToSpawnOnStart = 3;
    
        [Header("Animation")]
        [SerializeField] private float _spawnAnimationDuration = 1;
        [SerializeField] private float _startAnimationPositionY = -50;
    
        private Vector3 _nextSpawnPoint;
        private float _trackHeight;
        private Tween _tween;

        private void Start()
        {
            _trackHeight = transform.position.y;
        
            SpawnStartTrack();

            for (int i = 0; i < _numberToSpawnOnStart; i++)
            {
                SpawnTrack(false);
            }
        }

        public void SpawnTrack(bool spawnWithAnimation)
        {
            GameObject track = ObjectPool.ObjectPool.Instance.GetTrackPooledObject();
            track.transform.rotation = Quaternion.identity;
            track.transform.SetParent(transform);
            track.SetActive(true);
        
            if (spawnWithAnimation)
            {
                track.transform.position = new Vector3(_nextSpawnPoint.x, _startAnimationPositionY, _nextSpawnPoint.z);
            
                _tween = track.transform.DOMoveY(_trackHeight, _spawnAnimationDuration).SetEase(Ease.Linear).OnComplete(() => _tween.Kill());
            }
            else
            {
                track.transform.position = _nextSpawnPoint;
            }
        
            _nextSpawnPoint = track.transform.GetChild(1).transform.position;
        }

        private void SpawnStartTrack()
        {
            GameObject startTrack = Instantiate(_trackGroundStartPrefab, _nextSpawnPoint, Quaternion.identity, transform);
            _nextSpawnPoint = startTrack.transform.GetChild(1).transform.position;
        }
    }
}
