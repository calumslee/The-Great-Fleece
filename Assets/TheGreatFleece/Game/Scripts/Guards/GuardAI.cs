using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GuardAI : MonoBehaviour
{
    [SerializeField]
    private List<Transform> _wayPoints;
    private int _currentTarget;
    private bool _targetReached;
    private bool _reverse;

    private NavMeshAgent _guardNMAgent;
    private Animator _anim;

    private void Start()
    {
        GetReferences();
        NullCheck();
    }

    private void GetReferences()
    {
        _guardNMAgent = GetComponent<NavMeshAgent>();
        _anim = GetComponent<Animator>();
    }

    private void NullCheck()
    {
        if (_guardNMAgent == null)
        {
            Debug.LogError("NavMeshAgent is NULL!" + gameObject.name);
        }

        if (_anim == null)
        {
            Debug.LogError("Animator is NULL!" + gameObject.name);
        }
    }

    private void Update()
    {
        if (_wayPoints.Count > 0)
        {
            WayPointMovement();
        }
    }

    private void WayPointMovement()
    {
        if (_wayPoints[_currentTarget] != null)
        {
            _guardNMAgent.SetDestination(_wayPoints[_currentTarget].position);
        }

        float distance = Vector3.Distance(transform.position, _wayPoints[_currentTarget].position);
        if (distance < 1.0f && _targetReached == false)
        {
            StartCoroutine(IdleTime());
        }
    }

    private IEnumerator IdleTime()
    {
        _targetReached = true;
        _anim.SetBool("Walk", false);

        if (_currentTarget == 0 || _currentTarget == _wayPoints.Count - 1)
        {
            yield return new WaitForSeconds(Random.Range(2f, 5f));
        }

        SetNextTarget();
    }

    private void SetNextTarget()
    {
        if (_reverse == false)
        {
            _currentTarget++;
            
            if (_currentTarget == _wayPoints.Count - 1)
            {
                _reverse = true;
            }
        }
        else if (_reverse == true)
        {
            _currentTarget--;

            if (_currentTarget == 0)
            {
                _reverse = false;
            }
        }

        _targetReached = false;
        _anim.SetBool("Walk", true);
    }
}
