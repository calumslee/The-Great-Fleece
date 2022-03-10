using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootstepPoster : MonoBehaviour
{
    [SerializeField]
    private AK.Wwise.Event _footstepSFX;

    private Animator _anim;

    private void Start()
    {
        GetReferences();
    }

    private void GetReferences()
    {
        _anim = GetComponent<Animator>();

        NullCheck();
    }

    private void NullCheck()
    {
        if (_anim == null)
        {
            Debug.LogError("Animator is NULL!");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "FloorMaterial")
        {
            AK.Wwise.Switch _material = other.GetComponent<FloorMaterial>().Material;
            AkSoundEngine.SetSwitch("Footstep_Material", _material.ToString(), this.gameObject);
        }
    }

    public void PostFootstep()
    {
        AudioManager.Instance.AMSFXEvent(_footstepSFX, this.gameObject);
        Debug.Log("Footstep");
    }
}
