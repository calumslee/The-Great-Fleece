using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VOTrigger : MonoBehaviour
{
    [SerializeField]
    private AK.Wwise.Event _voiceOverAudio;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            _voiceOverAudio.Post(Camera.main.gameObject);
        }
    }
}
