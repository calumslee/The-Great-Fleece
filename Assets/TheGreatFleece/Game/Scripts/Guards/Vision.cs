using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vision : MonoBehaviour
{
    [SerializeField]
    private GameObject _gameOverCutScene;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("You've been caught, you lose!");
            _gameOverCutScene.SetActive(true);
        }
    }
}
