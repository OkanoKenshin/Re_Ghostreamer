using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CenterOfLightData : MonoBehaviour
{
    [SerializeField] public float heatGauge;
    [SerializeField] public float maxHeatGauge;
    [SerializeField] public bool overHeat;
    public bool lightInputOn = false;

    [SerializeField]
    private CommonParam.UnitType _unitType = CommonParam.UnitType.Streamer;

    [SerializeField]
    InputManager _inputManager;

    private InputManager.InputParam _inputParam;

    void Start()
    {
        if (_inputManager == null)
        {
            _inputManager = GetComponent<InputManager>();
        }
        _inputParam = _inputManager.UnitInputParams[_unitType];
    }

    private void Update()
    {
        if (_inputParam.Attack)
        {
            lightInputOn = true;
        }
        else
        {
            lightInputOn = false;
        }
    }
}
