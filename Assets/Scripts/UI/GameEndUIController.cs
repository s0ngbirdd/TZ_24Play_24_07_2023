using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameEndUIController : MonoBehaviour
{
    [SerializeField] private GameObject _gameEndUI;
    [SerializeField] private GameObject _touchCanvas;
    [SerializeField] private Button _tryAgainButton;
    [SerializeField] private Button _quitButton;
    [SerializeField] private CanvasGroup _gameEndUICanvasGroup;
    [SerializeField] private float _animationDuration = 2;

    private Tween _tween;

    private void OnEnable()
    {
        GameEnder.OnGameEnd += ShowGameEndUI;
        _tryAgainButton.onClick.AddListener(RestartGame);
        _quitButton.onClick.AddListener(QuitGame);
    }

    private void OnDisable()
    {
        GameEnder.OnGameEnd -= ShowGameEndUI;
        _tryAgainButton.onClick.RemoveListener(RestartGame);
        _quitButton.onClick.RemoveListener(QuitGame);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    private void ShowGameEndUI()
    {
        _touchCanvas.SetActive(false);
        _gameEndUI.SetActive(true);

        _tween = _gameEndUICanvasGroup.DOFade(1, _animationDuration).SetEase(Ease.Linear).OnComplete(() => _tween.Kill());
    }
}
