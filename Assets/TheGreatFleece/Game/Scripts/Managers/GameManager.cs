using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;

    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
            {
                Debug.LogError("GameManager is NULL!");
            }

            return _instance;
        }
    }

    private void Awake()
    {
        _instance = this;
    }

    public bool HasCard { get; set; }
    public bool PlayerCaught { get; set; }

    [SerializeField]
    private PlayableDirector _introCutscene;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _introCutscene.time = _introCutscene.duration - 1.0f;
        }
    }
}

