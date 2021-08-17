using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Player : MonoBehaviour
{
    private NavMeshAgent _playerNMAgent;

    private void Start()
    {
        _playerNMAgent = GetComponent<NavMeshAgent>();

        if (_playerNMAgent == null)
        {
            Debug.LogError("NavMesh Agent is NULL!");
        }
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if(Physics.Raycast(ray, out hit))
            {
                _playerNMAgent.SetDestination(hit.point);
            }
        }
    }
}
