using System.Collections;
using Cinemachine;
using UnityEngine;

namespace CameraShake
{
    [RequireComponent(typeof(CinemachineVirtualCamera))]
    public class CinemachineShake : MonoBehaviour
    {
        public static CinemachineShake Instance { get; private set; }

        [SerializeField] private float _resetTime = 3;
    
        private CinemachineVirtualCamera _cinemachineVirtualCamera;
        private float _shakeTimer;
        private float _shakeTimerTotal;
        private float _startingIntensity;
        private bool _isCoroutineEnd = true;

        private void Awake()
        {
            Instance = this;
            _cinemachineVirtualCamera = GetComponent<CinemachineVirtualCamera>();
        }

        private void Update()
        {
            if (_shakeTimer > 0.0f)
            {
                IntensityFade();
            }
        }

        public void ShakeCamera(float intensity, float time)
        {
            if (_isCoroutineEnd)
            {
                _isCoroutineEnd = false;
                StartCoroutine(ResetCameraShake(intensity, time));
            }
        }

        private IEnumerator ResetCameraShake(float intensity, float time)
        {
            CinemachineBasicMultiChannelPerlin cinemachineBasicMultiChannelPerlin = _cinemachineVirtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();

            cinemachineBasicMultiChannelPerlin.m_AmplitudeGain = intensity;

            _startingIntensity = intensity;
            _shakeTimerTotal = time;
            _shakeTimer = time;

            Vibrator.Vibrate();
            
            yield return new WaitForSeconds(_resetTime);

            _isCoroutineEnd = true;
        }

        private void IntensityFade()
        {
            _shakeTimer -= Time.deltaTime;

            CinemachineBasicMultiChannelPerlin cinemachineBasicMultiChannelPerlin = _cinemachineVirtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();

            cinemachineBasicMultiChannelPerlin.m_AmplitudeGain = Mathf.Lerp(_startingIntensity, 0.0f, 1 - _shakeTimer / _shakeTimerTotal);
        }
    }
}
