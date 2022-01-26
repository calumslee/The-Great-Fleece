using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VOTrigger : MonoBehaviour
{
    [SerializeField]
    internal AK.Wwise.Event _voiceOverAudio;

    [SerializeField]
    private bool _onStart, _isTriggered;

    private void Start()
    {
        if (_onStart)
        {
            AudioManager.Instance.AMVoiceoverEvent(_voiceOverAudio);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && _isTriggered)
        {
            AudioManager.Instance.AMVoiceoverEvent(_voiceOverAudio);
        }
    }
}
