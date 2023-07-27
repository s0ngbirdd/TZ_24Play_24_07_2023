using System;
using UnityEngine;
using DG.Tweening;

public class TrackSpawner : MonoBehaviour
{
    public event Action OnSpawnTrack; 

    [SerializeField] private GameObject _trackGroundStartPrefab;
    //[SerializeField] private GameObject _trackGroundPrefab;
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
            //GameObject obj = Instantiate(_trackGroundPrefab, new Vector3(_nextSpawnPoint.x, _startAnimationPositionY, _nextSpawnPoint.z), Quaternion.identity, transform);
            
            GameObject track = ObjectPool.ObjectPool.Instance.GetTrackPooledObject();
            track.transform.position = new Vector3(_nextSpawnPoint.x, _startAnimationPositionY, _nextSpawnPoint.z);
            track.transform.rotation = Quaternion.identity;
            track.transform.SetParent(transform);
            track.SetActive(true);
            
            _tween = track.transform.DOMoveY(_trackHeight, _spawnAnimationDuration).SetEase(Ease.Linear).OnComplete(() => _tween.Kill());
            _nextSpawnPoint = track.transform.GetChild(1).transform.position;
        }
        else
        {
            GameObject track = ObjectPool.ObjectPool.Instance.GetTrackPooledObject();
            track.transform.position = _nextSpawnPoint;
            track.transform.rotation = Quaternion.identity;
            track.transform.SetParent(transform);
            track.SetActive(true);
            
            //GameObject obj = Instantiate(_trackGroundPrefab, _nextSpawnPoint, Quaternion.identity, transform);
            _nextSpawnPoint = track.transform.GetChild(1).transform.position;
        }
        
        //OnSpawnTrack?.Invoke();
    }

    private void SpawnStartTrack()
    {
        GameObject startTrack = Instantiate(_trackGroundStartPrefab, _nextSpawnPoint, Quaternion.identity, transform);
        _nextSpawnPoint = startTrack.transform.GetChild(1).transform.position;
        
        //OnSpawnTrack?.Invoke();
    }
}
