using AK.Wwise;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistanceRTPC : MonoBehaviour
{
    private BoxCollider _ambArea;
    private Bounds _bounds;

    private uint _rtpcID;

    [SerializeField]
    private GameObject _targetToTrack;
    [SerializeField]
    private GameObject _targetEmitter;

    private float _distance;

    private void Start()
    {
        _ambArea = GetComponentInParent<BoxCollider>();
        _bounds = _ambArea.bounds;

        _rtpcID = AkSoundEngine.GetIDFromString("PlayerDistance");
    }

    private void Update()
    {
        Vector3 _posToTrack = _targetToTrack.transform.position;

        transform.position = _bounds.ClosestPoint(_posToTrack);

        _distance = Vector3.Distance(_posToTrack, transform.position);
        
        AkSoundEngine.SetRTPCValue(_rtpcID, _distance, _targetEmitter);
    }
}
