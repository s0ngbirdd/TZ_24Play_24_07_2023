using System;
using Unity.VisualScripting;
using UnityEngine;

public class CubeStacker : MonoBehaviour
{
    public static event Action OnStackCube;
    
    [SerializeField] private Transform _parentObjectTransform;
    [SerializeField] private Transform _upperCubeTransform;
    [SerializeField] private Transform _nextStackPoint;
    
    private int _cubeCount = 1;

    private void OnTriggerEnter(Collider other)
    {
        OnStackCube?.Invoke();

        SetCubeBehaviour(other);
        SetNextStackPoint();
    }

    private void SetCubeBehaviour(Collider other)
    {
        GameObject cube = other.gameObject;
        //cube.name = "Pickup" + _cubeCount++;
        cube.layer = LayerMask.NameToLayer("Default");
        cube.transform.SetParent(_parentObjectTransform);
        cube.transform.position = _nextStackPoint.position;
        cube.GetComponent<Collider>().isTrigger = false;
        
        Rigidbody cubeRigidbody = other.AddComponent<Rigidbody>();
        //cubeRigidbody.angularDrag = 0;
        cubeRigidbody.collisionDetectionMode = CollisionDetectionMode.Continuous;
        cubeRigidbody.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotation;
    }

    private void SetNextStackPoint()
    {
        _nextStackPoint = _upperCubeTransform.transform;
        _upperCubeTransform.position = _upperCubeTransform.GetChild(1).transform.position;
    }
}
