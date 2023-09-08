using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RaySettings : MonoBehaviour
{
    //���̃X�N���v�g��FlashLight�̐e�I�u�W�F�N�g��LightSlot�ɃA�^�b�`����B

    #region �ϐ��p��
    public Vector3 rayStartPoint;
    // ���C�g������transform.position���擾
    public Vector3 rayDirection;
    // ���C�g������transform.forword���擾
    public Vector3 localRayStartPoint;
    // ����Script���A�^�b�`����Ă�Object�̃��[�J�����W���i�[����ϐ��B
    public Ray rayOfLight;
    // GhostCollisionChecker�Ŏg�p����Ray

    #endregion

    void Awake()
    {
        rayOfLight = new Ray(rayStartPoint, rayDirection);
    }

    private void FixedUpdate()
    {
        localRayStartPoint = transform.localPosition;
        rayDirection = transform.forward;
        //�S�Ă̌��ƂȂ�n�_�ƕ�����������

        rayStartPoint = transform.parent.TransformPoint(localRayStartPoint);
        rayOfLight.origin = rayStartPoint;
        rayOfLight.direction = rayDirection;
    }
}