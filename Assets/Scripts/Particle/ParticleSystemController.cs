using UnityEngine;

public class ParticleSystemController : MonoBehaviour
{
    [SerializeField] private ParticleSystem _stackParticles;

    private void OnEnable()
    {
        CubeStacker.OnStackCube += PlayStackParticle;
    }

    private void OnDisable()
    {
        CubeStacker.OnStackCube -= PlayStackParticle;
    }

    private void PlayStackParticle()
    {
        _stackParticles.Play();
    }
}
