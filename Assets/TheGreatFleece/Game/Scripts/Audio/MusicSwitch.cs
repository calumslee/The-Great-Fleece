using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicSwitch : MonoBehaviour
{
    [SerializeField]
    private AK.Wwise.Switch _switch;

    [SerializeField]
    private bool _onStart, _onDisable;
    

    private void Start()
    {
        if (_onStart)
        {
            AudioManager.Instance.AMMusicSwitch(_switch);
        }
    }

    private void OnDisable()
    {
        if (_onDisable)
        {
            AudioManager.Instance.AMMusicSwitch(_switch);
        }
    }
}
