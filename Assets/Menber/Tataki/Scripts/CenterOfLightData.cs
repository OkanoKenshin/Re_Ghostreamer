using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CenterOfLightData : MonoBehaviour
{
    [SerializeField] public float heatGauge;
    [SerializeField] public float maxHeatGauge;
    [SerializeField] public bool overHeat;
    [SerializeField] public float valueOfLaserLightRange;
    public bool lightInputOn;

    void Start()
    {

    }
}
