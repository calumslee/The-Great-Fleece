using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTrigger : MonoBehaviour
{
    [SerializeField]
    private GameObject _cameraAngle;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Camera.main.transform.position = _cameraAngle.transform.position;
            Camera.main.transform.rotation = _cameraAngle.transform.rotation;
        }
    }
}
