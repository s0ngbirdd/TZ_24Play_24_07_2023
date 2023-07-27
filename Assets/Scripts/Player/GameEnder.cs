using System;
using CameraShake;
using UnityEngine;

namespace Player
{
    public class GameEnder : MonoBehaviour
    {
        public static event Action OnGameEnd;

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.layer.Equals(LayerMask.NameToLayer("Wall")))
            {
                CinemachineShake.Instance.ShakeCamera(7.0f, 0.3f);
                OnGameEnd?.Invoke();
            }
        }
    }
}
