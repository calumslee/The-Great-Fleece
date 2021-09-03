using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabKeyCardCutscene : MonoBehaviour
{
    [SerializeField]
    private GameObject _keyCardCutscene;
    [SerializeField]
    private Vector3 _darrenEndPos;
    [SerializeField]
    private Vector3 _darrenEndRot;


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            _keyCardCutscene.SetActive(true);
            other.gameObject.transform.position = _darrenEndPos;
            other.gameObject.transform.eulerAngles = _darrenEndRot;

            GameManager.Instance.HasCard = true;
        }
    }
}
