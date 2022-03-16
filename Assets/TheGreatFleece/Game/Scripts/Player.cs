using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Player : MonoBehaviour
{
    private Vector3 _destination;

    [SerializeField]
    private GameObject _coin;
    private bool _hasThrownCoin;

    private NavMeshAgent _playerNMAgent;
    private Animator _anim;

    [Header("Audio")]
    [SerializeField]
    private AK.Wwise.Event _coinSound;

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
        ClickToThrow();

        
    }

    private void ClickToMove()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray rayOrigin = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(rayOrigin, out hit))
            {
                if (_playerNMAgent.SetDestination(hit.point))
                {
                    _playerNMAgent.isStopped = false;
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
                _playerNMAgent.isStopped = true;
                _anim.SetBool("Walk", false);
            }
        }
    }

    private void ClickToThrow()
    {
        if (Input.GetMouseButtonDown(1) && _hasThrownCoin == false)
        {
            StartCoroutine(ThrowCoin());
        }
    }

    private IEnumerator ThrowCoin()
    {
        Ray rayOrigin = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(rayOrigin, out hit))
        {
            _hasThrownCoin = true;
            _playerNMAgent.isStopped = true;

            _anim.SetTrigger("CoinThrow");
            float animLength = _anim.GetCurrentAnimatorClipInfo(0).Length;

            yield return new WaitForSeconds(animLength);

            Instantiate(_coin, hit.point, Quaternion.identity);
            AudioManager.Instance.AMSFXEvent(_coinSound, _coin);
            DistractGuards(hit.point);

            _playerNMAgent.isStopped = false;
        }
    }

    private void DistractGuards(Vector3 coinPos)
    {
        GameObject[] _guards = GameObject.FindGameObjectsWithTag("Guard1");
        
        foreach (GameObject guard in _guards)
        {
            float distance = Vector3.Distance(guard.transform.position, coinPos);
            if (distance < 30)
            {
                guard.GetComponent<GuardAI>().GoToCoin(coinPos);
            }
        }
    }
}
