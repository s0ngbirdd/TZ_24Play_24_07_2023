using System;
using UnityEngine;

namespace Player
{
    public class CubeStacker : MonoBehaviour
    {
        public static event Action OnStackCube;
    
        [SerializeField] private Transform _parentObjectTransform;
        [SerializeField] private Transform _upperCubeTransform;
        [SerializeField] private Transform _nextStackPointTransform;

        private void OnTriggerEnter(Collider other)
        {
            OnStackCube?.Invoke();

            SetCubeBehaviour(other);
            SetNextStackPoint();
        }

        private void SetCubeBehaviour(Collider other)
        {
            GameObject cube = other.gameObject;
            cube.layer = LayerMask.NameToLayer("Default");
            cube.transform.SetParent(_parentObjectTransform);
            cube.transform.position = _nextStackPointTransform.position;
            cube.GetComponent<Collider>().isTrigger = false;

            Rigidbody cubeRigidbody = other.gameObject.AddComponent<Rigidbody>();
            cubeRigidbody.collisionDetectionMode = CollisionDetectionMode.Continuous;
            cubeRigidbody.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotation;
        }

        private void SetNextStackPoint()
        {
            _nextStackPointTransform = _upperCubeTransform.transform;
            _upperCubeTransform.position = _upperCubeTransform.GetChild(1).transform.position;
        }
    }
}
