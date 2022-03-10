using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorMaterial : MonoBehaviour
{
    [SerializeField]
    private AK.Wwise.Switch _material;

    public AK.Wwise.Switch Material { get; private set; }

    public void Start()
    {
        Material = _material;
    }
}
