using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VOTrigger : MonoBehaviour
{
    [SerializeField]
    internal AK.Wwise.Event _voiceOverAudio;

    [SerializeField]
    private bool _onStart, _isTriggered;

    private bool _hasPlayed = false;

    private void OnEnable() 
    { 
        if (_onStart)
        {
            AudioManager.Instance.AMVoiceoverEvent(_voiceOverAudio);
        }
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Player" && _isTriggered && !_hasPlayed)
        {
            AudioManager.Instance.AMVoiceoverEvent(_voiceOverAudio);
            _hasPlayed = true;
        }
    }
}
