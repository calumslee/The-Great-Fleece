using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecurityCamera : MonoBehaviour
{
    [SerializeField]
    private GameObject _gameOverCutscene;
    [SerializeField]
    private Vector3 _cutSceneRotation;

    private bool _playerCaught;

    private List<SecurityCamera> _cameraScripts = new List<SecurityCamera>();
    private List<Animator> _animList = new List<Animator>();
    private List<MeshRenderer> _coneMeshes = new List<MeshRenderer>();

    private void Start()
    {
        ParentReferences();
        SelfReferences();
    }

    private void ParentReferences()
    {
        GameObject[] _cameras = GameObject.FindGameObjectsWithTag("Camera1");

        foreach (GameObject camera in _cameras)
        {
            Animator _anim = camera.GetComponent<Animator>();

            if (_anim != null)
            {
                _animList.Add(_anim);
            }
        }
    }

    private void SelfReferences()
    {
        GameObject[] _cones = GameObject.FindGameObjectsWithTag("CameraCone");

        foreach (GameObject cone in _cones)
        {
            SecurityCamera _script = cone.GetComponent<SecurityCamera>();
            MeshRenderer _mesh = cone.GetComponent<MeshRenderer>();

            if (_script != null)
            {
                _cameraScripts.Add(_script);
            }

            if (_mesh != null)
            {
                _coneMeshes.Add(_mesh);
            }
        }
    }

    private void Update()
    {
        if (GameManager.Instance.PlayerCaught == true)
        {
            StartCoroutine(GameOverRoutine());
            RotateToCutScene();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            GameManager.Instance.PlayerCaught = true;
        }
    }

    private IEnumerator GameOverRoutine()
    {
        _playerCaught = false;
       
        DisableAnimator();
        ChangeColor();
        
        yield return new WaitForSeconds(0.5f);
        
        _gameOverCutscene.SetActive(true);
    }

    private void DisableAnimator()
    {
        foreach (Animator anim in _animList)
        {
            anim.enabled = false;
        }
    }

    private void ChangeColor()
    {
        foreach (MeshRenderer meshRend in _coneMeshes)
        {
            Color red = new Color(1, 0, 0, 0.04f);
            meshRend.material.SetColor("_TintColor", red);
        }
    }

    private void RotateToCutScene()
    {
        Transform parent = this.gameObject.transform.parent;
        parent.eulerAngles = _cutSceneRotation;
    }
}
