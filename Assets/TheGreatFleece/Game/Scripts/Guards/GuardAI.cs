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
    private bool _alerted;
    private Vector3 _coinPos;

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
        WayPointMovement();
    }

    private void WayPointMovement()
    {
        if (_alerted == false && _targetReached == false)
        {
            if (_wayPoints.Count > 0 && _wayPoints[_currentTarget] != null)
            {
                _guardNMAgent.SetDestination(_wayPoints[_currentTarget].position);
                _anim.SetBool("Walk", true);

                float distance = Vector3.Distance(transform.position, _wayPoints[_currentTarget].position);
                if (distance < 1.0f)
                {
                    _guardNMAgent.isStopped = true;
                    StartCoroutine(IdleTime());
                }
            }

        }
        else if (_alerted == true && _targetReached == false)
        {
            _guardNMAgent.SetDestination(_coinPos);
            _anim.SetBool("Walk", true);

            float distance = Vector3.Distance(transform.position, _coinPos);
            if (distance < 5.0f)
            {
                _guardNMAgent.isStopped = true;
                StartCoroutine(IdleTime());
            }
        }
    }

    private IEnumerator IdleTime()
    {
        _targetReached = true;
        _anim.SetBool("Walk", false);
        
        if (_alerted == false)
        {
            if (_currentTarget == 0 || _currentTarget == _wayPoints.Count - 1)
            {
                yield return new WaitForSeconds(Random.Range(2f, 5f));
            }
        }
        else if (_alerted == true)
        {
            yield return new WaitForSeconds(Random.Range(5f, 10f));
            _alerted = false;
        }
        
        if (_wayPoints.Count > 0)
        {
            SetNextTarget();
        }
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
        _guardNMAgent.isStopped = false;
    }

    public void GoToCoin(Vector3 coinPos)
    {
        _alerted = true;
        _coinPos = coinPos;
    }
}
