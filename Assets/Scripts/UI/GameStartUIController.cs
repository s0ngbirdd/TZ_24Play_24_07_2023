using DG.Tweening;
using Joystick;
using UnityEngine;

namespace UI
{
    public class GameStartUIController : MonoBehaviour
    {
        [Header("Objects")]
        [SerializeField] private GameObject _gameStartUI;
        [SerializeField] private GameObject _finger;
    
        [Header("Animation")]
        [SerializeField] private float _animationEndValue = 275;
        [SerializeField] private float _animationDuration = 2;

        private Tween _tween;

        private void OnEnable()
        {
            PlayerTouchMovement.OnEnableMoveSpeed += HideGameStartUI;
        }

        private void OnDisable()
        {
            PlayerTouchMovement.OnEnableMoveSpeed -= HideGameStartUI;
        }

        private void Start()
        {
            _tween = _finger.transform.DOMoveX(_animationEndValue, _animationDuration).SetEase(Ease.Linear).SetLoops(-1, LoopType.Yoyo);
        }

        private void HideGameStartUI()
        {
            _gameStartUI.SetActive(false);
            _tween.Kill();
        }
    }
}
