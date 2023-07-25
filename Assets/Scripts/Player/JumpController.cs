using UnityEngine;

[RequireComponent(typeof(Animator))]
public class JumpController : MonoBehaviour
{
    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        CubeStacker.OnStackCube += PlayJumpAnimation;
    }

    private void OnDisable()
    {
        CubeStacker.OnStackCube -= PlayJumpAnimation;
    }

    private void PlayJumpAnimation()
    {
        _animator.SetTrigger("Jump");
    }
}
