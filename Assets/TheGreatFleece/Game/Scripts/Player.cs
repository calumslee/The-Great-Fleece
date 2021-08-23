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
        _destination = transform.position;
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
        ClickToMove();
        CheckPosition();
    }

    private void ClickToMove()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (_playerNMAgent.SetDestination(hit.point))
                {
                    _destination = hit.point;
                    _anim.SetBool("Walk", true);
                }
            }
        }
    }

    private void CheckPosition()
    {
        if (_destination != null)
        {
            float _distance = Vector3.Distance(transform.position, _destination);
            if (_distance < 2.0f)
            {
                _anim.SetBool("Walk", false);
            }
        }
    }
}
