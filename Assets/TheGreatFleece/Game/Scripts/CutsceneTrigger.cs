using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutsceneTrigger : MonoBehaviour
{
    [SerializeField]
    private GameObject _cutScene;
    [SerializeField]
    private Vector3 _darrenEndPos;
    [SerializeField]
    private Vector3 _darrenEndRot;


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            _cutScene.SetActive(true);
            other.gameObject.transform.position = _darrenEndPos;
            other.gameObject.transform.eulerAngles = _darrenEndRot;
        }
    }
}
