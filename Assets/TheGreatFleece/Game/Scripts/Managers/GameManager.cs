using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    [SerializeField]
    private GameObject _openingCutscene;

    [SerializeField]
    private GameObject _gameOverCutscene;

    private void Start()
    {
        _openingCutscene.SetActive(true);
    }

    public bool HasCard { get; set; }
    public bool PlayerCaught { get; set; }

    public void GameOverCutscene()
    {
        GameObject.FindGameObjectWithTag("Player").SetActive(false);
        _gameOverCutscene.SetActive(true);
    }
}

