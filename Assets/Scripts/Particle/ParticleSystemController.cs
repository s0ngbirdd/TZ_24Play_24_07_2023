using Joystick;
using UnityEngine;
using UnityEngine.Serialization;

public class ParticleSystemController : MonoBehaviour
{
    [SerializeField] private ParticleSystem _stackParticle;
    [SerializeField] private ParticleSystem _warpParticle;

    private void OnEnable()
    {
        CubeStacker.OnStackCube += PlayStackParticle;
        PlayerTouchMovement.OnEnableMoveSpeed += PlayWarpParticle;
    }

    private void OnDisable()
    {
        CubeStacker.OnStackCube -= PlayStackParticle;
        PlayerTouchMovement.OnEnableMoveSpeed -= PlayWarpParticle;
    }

    private void PlayStackParticle()
    {
        _stackParticle.Play();
    }
    
    private void PlayWarpParticle()
    {
        _warpParticle.Play();
    }
}
