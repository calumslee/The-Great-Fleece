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

    private void Start()
    {
        StartMusic();
    }

    private void StartMusic()
    {
        _musicEvent.Post(this.gameObject);
    }

    public void AMMusicSwitch(AK.Wwise.Switch _nextSwitch)
    {
        AkSoundEngine.SetSwitch("Music_SwitchGroup", _nextSwitch.ToString(), this.gameObject);
    }

    public void AMVoiceoverEvent(AK.Wwise.Event _voiceOver)
    {
        _voiceOver.Post(this.gameObject);
    }

    public void SkipVoiceover(AK.Wwise.Event _currentVO)
    {
        _currentVO.Stop(this.gameObject, 1);
    }

    public void AMSFXEvent(AK.Wwise.Event _sfx, GameObject _parent)
    {
        _sfx.Post(_parent.gameObject);
    }
}
