using AK.Wwise;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AudioManager : MonoBehaviour
{
    private void Awake()
    {
        if (_instance)
        {
            DestroyImmediate(this);
            return;
        }
        else
        {
            _instance = this;
            DontDestroyOnLoad(this);
        }
    }

    private static AudioManager _instance;

    public static AudioManager Instance
    {
        get
        {
            if (_instance == null)
            {
                Debug.LogError("AudioManager is NULL!");
            }

            return _instance;
        }
    }

    [SerializeField]
    private AK.Wwise.Event _musicEvent;

    [SerializeField]
    private RTPC[] _audioBusRtpcs;

    private void Start()
    {
        StartMusic();
    }

    //Audio Bus Systems

    public void DuckBus(RTPC _rtpc, float _targetValue)
    {
        float volume = Mathf.Clamp((_rtpc.GetGlobalValue() - _targetValue), 0, 100);
        _rtpc.SetGlobalValue(volume);
    }

    public void ResetBus(RTPC _rtpc, float _targetValue)
    {
        float volume = Mathf.Clamp((_rtpc.GetGlobalValue() + _targetValue), 0, 100);
        _rtpc.SetGlobalValue(volume);
    }

    //Music Systems
    private void StartMusic()
    {
        _musicEvent.Post(this.gameObject);
    }

    public void AMMusicSwitch(Switch _nextSwitch)
    {
        AkSoundEngine.SetSwitch("Music_SwitchGroup", _nextSwitch.ToString(), this.gameObject);
    }


    //Voiceover Systems
    public void AMVoiceoverEvent(AK.Wwise.Event _voiceOver)
    {
        _voiceOver.Post(this.gameObject);
    }

    public void SkipVoiceover(AK.Wwise.Event _currentVO)
    {
        _currentVO.Stop(this.gameObject, 1);
    }


    //SFX Systems
    public void AMAmbientEvent(AK.Wwise.Event _amb, GameObject _parent)
    {
        _amb.Post(_parent.gameObject);
    }

    public void AMSFXEvent(AK.Wwise.Event _sfx, GameObject _parent)
    {
        _sfx.Post(_parent.gameObject);
    }
}
