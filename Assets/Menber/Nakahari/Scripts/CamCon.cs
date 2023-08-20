using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class CamCon : MonoBehaviour
{
    [SerializeField]
    private GameObject camPos;

    public Transform playerTransform;
    public Transform characterModel;
    public float sensitivityX = 2.0f;
    public float sensitivityY = 2.0f;
    public float minimumY = -90.0f;
    public float maximumY = 90.0f;

    private float rotationY = 0.0f;

    private Re_Ghostreamer _ghostReamer;

    public bool isAnimation = false;


    private void Start()
    {
        _ghostReamer = new Re_Ghostreamer();
        _ghostReamer.Enable();
    }
    private void Update()
    {
        if(!isAnimation)
        {
            CameraControll();
        }

        Debug.Log(isAnimation);
        
    }

    public void SetIsAnimation(bool value)
    {
        isAnimation = value;
    }

    private void CameraControll()
    {
        var look = _ghostReamer.Ghost1.Look.ReadValue<Vector2>();
        float rotationX = transform.localEulerAngles.y + look.x * sensitivityX;
        rotationY += look.y * sensitivityY;
        rotationY = Mathf.Clamp(rotationY, minimumY, maximumY);

        transform.localEulerAngles = new Vector3(-rotationY, rotationX, 0);
        playerTransform.eulerAngles = new Vector3(0, rotationX, 0);

        this.transform.position = camPos.transform.position;

        characterModel.localEulerAngles = new Vector3(0, playerTransform.eulerAngles.y, 0);
    }
}
