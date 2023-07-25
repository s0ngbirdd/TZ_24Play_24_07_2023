using UnityEngine;
using DG.Tweening;

public class TrackSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _trackGroundStartPrefab;
    [SerializeField] private GameObject _trackGroundPrefab;
    [SerializeField] private int _numberToSpawn = 3;
    [SerializeField] private float _spawnAnimationDuration = 1;
    [SerializeField] private float _startAnimationPositionY = -50;
    
    private Vector3 _nextSpawnPoint;
    private float _trackHeight;
    private Tween _tween;

    private void Start()
    {
        _trackHeight = transform.position.y;
        
        SpawnStartTrack();

        for (int i = 0; i < _numberToSpawn; i++)
        {
            SpawnTrack(false);
        }
    }

    public void SpawnTrack(bool spawnWithAnimation)
    {
        if (spawnWithAnimation)
        {
            GameObject obj = Instantiate(_trackGroundPrefab, new Vector3(_nextSpawnPoint.x, _startAnimationPositionY, _nextSpawnPoint.z), Quaternion.identity, transform);
            _tween = obj.transform.DOMoveY(_trackHeight, _spawnAnimationDuration).SetEase(Ease.Linear).OnComplete(() => _tween.Kill());
            _nextSpawnPoint = obj.transform.GetChild(1).transform.position;
        }
        else
        {
            GameObject obj = Instantiate(_trackGroundPrefab, _nextSpawnPoint, Quaternion.identity, transform);
            _nextSpawnPoint = obj.transform.GetChild(1).transform.position;
        }
    }

    private void SpawnStartTrack()
    {
        GameObject obj = Instantiate(_trackGroundStartPrefab, _nextSpawnPoint, Quaternion.identity, transform);
        _nextSpawnPoint = obj.transform.GetChild(1).transform.position;
    }
}
