using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionTracker : MonoBehaviour
{
    private BoxCollider _ambArea;
    private Bounds _bounds;

    [SerializeField]
    private GameObject _targetToTrack;

    [SerializeField]
    private float _transitionSpeed = 200f;

    private void Start()
    {
        _ambArea = GetComponentInParent<BoxCollider>();
        _bounds = _ambArea.bounds;
    }

    private void Update()
    {
        Vector3 _posToTrack = _targetToTrack.transform.position;
        Vector3 _targetPos = _bounds.ClosestPoint(_posToTrack);
        float _step = _transitionSpeed * Time.deltaTime;

        transform.position = Vector3.MoveTowards(transform.position, _targetPos, _step);
    }
}
