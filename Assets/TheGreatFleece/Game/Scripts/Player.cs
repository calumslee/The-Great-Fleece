using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Player : MonoBehaviour
{
    private Vector3 _destination;

    private NavMeshAgent _playerNMAgent;
    private Animator _anim;

    private void Start()
    {
        GetReferences();
    }

    private void GetReferences()
    {
        _playerNMAgent = GetComponent<NavMeshAgent>();

        _anim = GetComponentInChildren<Animator>();

        NullCheck();
    }

    private void NullCheck()
    {
        if (_playerNMAgent == null)
        {
            Debug.LogError("NavMesh Agent is NULL!");
        }

        if (_anim == null)
        {
            Debug.LogError("Player Animator is NULL!");
        }
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                _destination = hit.point;
                _playerNMAgent.SetDestination(_destination);
                _anim.SetBool("Walk", true);
            }
        }

        float _distance = Vector3.Distance(transform.position, _destination);
        if (_distance < 1)
        {
            _anim.SetBool("Walk", false);
        }
    }
}
