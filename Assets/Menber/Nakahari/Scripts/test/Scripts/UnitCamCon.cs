using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.InputSystem;

public class UnitCamCon : MonoBehaviour
{

    [SerializeField]
    private CommonParam.UnitType _unitType = CommonParam.UnitType.Streamer;

    [SerializeField]
    private GameObject camPos;

    [SerializeField]
    InputManager _inputManager;

    public Transform playerTransform;
    public Transform characterModel;
    public float sensitivityX = 2.0f;
    public float sensitivityY = 2.0f;
    public float minimumY = -90.0f;
    public float maximumY = 90.0f;

    private float rotationY = 0.0f;

    private InputManager.InputParam _inputParam;

    //private Re_Ghostreamer _ghostReamer;

    void Start()
    {
        if (_inputManager == null)
        {
            _inputManager = GetComponent<InputManager>();
        }
        _inputParam = _inputManager.UnitInputParams[_unitType];
        //_ghostReamer = new Re_Ghostreamer();
        //_ghostReamer.Enable();
    }
    void Update()
    {
        CameraControll();
    }

    
    private void CameraControll()
    {
        float rotationX = transform.localEulerAngles.y + _inputParam.CamX * sensitivityX;
        rotationY += _inputParam.CamY * sensitivityY;
        rotationY = Mathf.Clamp(rotationY, minimumY, maximumY);

        transform.localEulerAngles = new Vector3(-rotationY, rotationX, 0);
        playerTransform.eulerAngles = new Vector3(0, rotationX, 0);

        this.transform.position = camPos.transform.position;

        characterModel.localEulerAngles = new Vector3(0, playerTransform.eulerAngles.y, 0);
    }
}

