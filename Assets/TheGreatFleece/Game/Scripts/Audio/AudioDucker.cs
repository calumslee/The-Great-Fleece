using AK.Wwise;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioDucker : MonoBehaviour
{
    [SerializeField]
    private RTPC _targetBus;

    [Header("Max Decrease = 100")]
    [SerializeField]
    private float _volumeDecrease;

    private void OnEnable()
    {
        AudioManager.Instance.DuckBus(_targetBus, _volumeDecrease);
    }

    private void OnDisable()
    {
        AudioManager.Instance.ResetBus(_targetBus, _volumeDecrease);
    }
}
