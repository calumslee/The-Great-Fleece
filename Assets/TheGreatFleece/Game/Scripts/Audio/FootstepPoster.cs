using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootstepPoster : MonoBehaviour
{
    [SerializeField]
    private AK.Wwise.Event _footstepSFX;

    public void PostFootstep()
    {
        AudioManager.Instance.AMSFXEvent(_footstepSFX, this.gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "FloorMaterial")
        {
            AK.Wwise.Switch _material = other.GetComponent<FloorMaterial>().Material;
            AkSoundEngine.SetSwitch("Footstep_Material", _material.ToString(), this.gameObject);
        }
    }
}
