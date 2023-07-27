using UnityEngine;

public class CollectCubeText : MonoBehaviour
{
    [SerializeField] private float _objectSpeed = 5;
    [SerializeField] private float _timeBeforeDeactivation = 2;

    private void OnEnable()
    {
        Invoke(nameof(DeactivateSelf), _timeBeforeDeactivation);
    }

    private void Update()
    {
        MoveUp();
    }

    private void MoveUp()
    {
        transform.Translate(Vector3.up * (_objectSpeed * Time.deltaTime));
    }

    private void DeactivateSelf()
    {
        gameObject.SetActive(false);
    }
}
