using UnityEngine;

namespace CollectCubeText
{
    public class CollectCubeText : MonoBehaviour
    {
        [SerializeField] private float _moveSpeed = 5;
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
            transform.Translate(Vector3.up * (_moveSpeed * Time.deltaTime));
        }

        private void DeactivateSelf()
        {
            gameObject.SetActive(false);
        }
    }
}
