using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmbientEmitter : MonoBehaviour
{
    [SerializeField]
    private AK.Wwise.Event _ambientEvent;

    private void Start()
    {
        _ambientEvent.Post(this.gameObject);
    }
}
