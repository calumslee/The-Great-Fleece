using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class SkipCutscene : MonoBehaviour
{
    PlayableDirector _introCutscene;
    AK.Wwise.Event _currentVO;

    private void Start()
    {
        _introCutscene = this.gameObject.GetComponent<PlayableDirector>();
        _currentVO = this.gameObject.GetComponent<VOTrigger>()._voiceOverAudio;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _introCutscene.time = _introCutscene.duration - 1.0f;
            AudioManager.Instance.SkipVoiceover(_currentVO);
        }
    }

}
