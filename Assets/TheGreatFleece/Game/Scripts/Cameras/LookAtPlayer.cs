using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtPlayer : MonoBehaviour
{
    [SerializeField]
    private Transform _player;
    [SerializeField]
    private Transform _startingPos;

    private void Start()
    {
        transform.position = _startingPos.position;
        transform.rotation = _startingPos.rotation;
    }

    private void Update()
    {
        transform.LookAt(_player);
    }
}
