using System;
using DG.Tweening;
using Joystick;
using UnityEngine;

public class GameStartUIController : MonoBehaviour
{
    [SerializeField] private GameObject _gameStartUI;
    [SerializeField] private GameObject _finger;
    [SerializeField] private float _animationEndValue = -1;
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
