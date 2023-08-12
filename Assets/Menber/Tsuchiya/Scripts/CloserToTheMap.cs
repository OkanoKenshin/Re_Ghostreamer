using UnityEngine;

public class CloserToTheMap : MonoBehaviour
{
    public Camera streamerCam;
    private Vector3 currentBodyPosition;
    private Vector3 currentBodyRotate;
    private Vector3 posisionInFrontOfMap;
    private Vector3 rotateInFrontOfMap;

    [SerializeField] private float lerpComplementParameter;
    [SerializeField] private float slerpComplementParameter;

    public void MMoveThePosition()
    {
        Vector3 newPosition = Vector3.Lerp(currentBodyPosition, posisionInFrontOfMap, lerpComplementParameter);
        streamerCam.transform.position = newPosition;
    }

    public void MMoveTheRotation()
    {
        Quaternion newRotate = Quaternion.Euler(rotateInFrontOfMap);
        Quaternion qCurrentBodyRotate = Quaternion.Euler(currentBodyRotate);
        Quaternion newRotation = Quaternion.Slerp(qCurrentBodyRotate, newRotate, slerpComplementParameter);
        streamerCam.transform.rotation = newRotation;
    }

    public void MReturnPosition()
    {
        Vector3 newPosition = Vector3.Lerp(posisionInFrontOfMap, currentBodyPosition, lerpComplementParameter);
        streamerCam.transform.position = newPosition;
    }

    public void MReturnRotation()
    {
        Quaternion newRotate = Quaternion.Euler(currentBodyRotate);
        Quaternion qRotateInFrontOfMap = Quaternion.Euler(rotateInFrontOfMap);
        Quaternion newRotation = Quaternion.Slerp(qRotateInFrontOfMap, newRotate, slerpComplementParameter);
        streamerCam.transform.rotation = newRotation;
    }
}
