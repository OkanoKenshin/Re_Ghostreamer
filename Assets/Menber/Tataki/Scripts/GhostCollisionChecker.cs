using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostCollisionChecker : MonoBehaviour
{
    [SerializeField] GameObject AttachedRaySettings;
    RaySettings _raySettings;
    [SerializeField] GameObject AttachedCenterOfLightData;
    CenterOfLightData _centerOfLightData;
    [SerializeField] GameObject AttachedLightHitDetection;
    LightHitDetection _lightHitDetection;
    [SerializeField] public float lightRayRadius;
    [SerializeField] private int layerWithGhost;
    private int hitLayer;
    [SerializeField] private int layerWithNonLightPenetratingObjects;
    [SerializeField]
    GameObject RaySettingsObject;
   private float valueOfLaserLightRange;

    int layerMask = 1 << 8;

    void Awake()
    {
        layerMask = ~layerMask;
        valueOfLaserLightRange = 10;
        #region CenterOfLightData��Null�`�F�b�N
        if (AttachedCenterOfLightData != null)
        {
            _centerOfLightData = GetComponent<CenterOfLightData>();
            if (_centerOfLightData != null)
            {
                Debug.Log("�uCenterOfLightData�v�͐���Ɏ擾����Ă��܂��B");
            }
            else
            {
                Debug.Log("�uAttachedCenterOfLightData�v�̓A�^�b�`����Ă��܂����A�uCenterOfLightData�v�̎擾�Ɏ��s���Ă��܂��B");
            }
        }
        else
        {
            Debug.Log("�uAttachedCenterOfLightData�v�̓A�^�b�`����Ă��܂���B");
        }
        #endregion

        #region "RaySettings"��Null�`�F�b�N
        if (RaySettingsObject != null)
        {
            _raySettings = AttachedRaySettings.GetComponent<RaySettings>();
            if (_raySettings != null)
            {
                Debug.Log("�uRaySettings�v�͐���Ɏ擾����Ă��܂��B");
            }
            else
            {
                Debug.Log("�uRaySettingsObject�v�̓A�^�b�`����Ă��܂����A�uRaySettings�v�̎擾�Ɏ��s���Ă��܂��B");
            }
        }
        else
        {
            Debug.Log("�uRaySettingsObject�v�̓A�^�b�`����Ă��܂���B");
        }
        #endregion

        #region "LightHitDetection"��Null�`�F�b�N
        if (AttachedLightHitDetection != null)
        {
            _lightHitDetection = AttachedLightHitDetection.GetComponent<LightHitDetection>();
            if (_lightHitDetection != null)
            {
                Debug.Log("�uLightHitDetection�v�͐���Ɏ擾����Ă��܂��B");
            }
            else
            {
                Debug.Log("�uAttachedLightHitDetection�v�̓A�^�b�`����Ă��܂����A�uLightHitDetection�v�̎擾�Ɏ��s���Ă��܂��B");
            }
        }
        else
        {
            Debug.Log("�uAttachedLightHitDetection�v�̓A�^�b�`����Ă��܂���B");
        }
        #endregion
    }
    private void FixedUpdate()
    {
        MGhostCollisionChecker();
    }

    public void MGhostCollisionChecker()
    {

        RaycastHit[] InformationObtainedByRay = Physics.SphereCastAll(_raySettings.rayOfLight, lightRayRadius, valueOfLaserLightRange, layerMask);
        Vector3 rays = new Vector3(0, 0, valueOfLaserLightRange);
        // ����̔�����΂���LightRayDistance�̋������ɂ��邷�ׂĂ�Object�����o����Raycast
        //DrawSphereCast(_raySettings.rayOfLight, lightRayRadius, distance: _centerOfLightData.valueOfLaserLightRange);
        Debug.DrawRay(_raySettings.rayStartPoint, rays,Color.red);
        //Ray�̉������e�n�_�ɋ���`�ʁBChatGPT�ō쐬����Debug�@�\�B

        Debug.Log($"InformationObtainedByRay length: {InformationObtainedByRay.Length}");
        //InformationObtainedByRay�Ƃ����z��̗v�f����\������Debug.Log�B

        foreach (RaycastHit checkObject in InformationObtainedByRay)
        //InformationObtainedByRay�Ƃ����z��ɂ���RaycastHit�̏���checkObject�Ƃ����ϐ��Ɉڂ��B
        {
            hitLayer = checkObject.transform.gameObject.layer;
            // �ȉ��̏����Ō��o���Ă���2��Layer�ȊO�͏����ɍl������K�v�������̂ŏ����ɉ����Ȃ��B

            Debug.Log(hitLayer);
            if (hitLayer == layerWithNonLightPenetratingObjects)
            // layerWithNonLightPenetratingObjects �� ���C�g�̓����蔻�肪�ђʂ��Ȃ�Object�̑��݂���Layer
            // ��ђ�Object���q�b�g�����瑦break����
            {
                break;
            }
            else if (hitLayer == layerWithGhost)
            // layerWithGhost �� Ghost�̃��[���h���f�������݂���Layer
            // ���ꂪ�q�b�g����ꍇ�AGhost�̂ǂꂩ�Ɋm���ɓ������Ă���B
            {
                _lightHitDetection.MLightHitDetection();
                _lightHitDetection.ghostTagHit = checkObject.transform.gameObject.tag;
                Debug.Log(checkObject.transform.gameObject.tag);
                // Tag�̒��g���R���\�[���ɕ\��
            }
        }
    }


    #region Ray�̉����ƒ��e�n�_�ɋ���\������Debug�@�\
    private void DrawSphereCast(Ray ray, float radius, float distance)
    {
        RaycastHit hit;
        if (Physics.SphereCast(ray, radius, out hit, distance))
        {
            // SphereCast�������ɓ��������ꍇ�A�ԐF��Ray��`��
            Debug.DrawRay(ray.origin, ray.direction * hit.distance, Color.red);
            // ���������|�C���g�ɋ���`��
            Gizmos.DrawWireSphere(ray.origin + ray.direction * hit.distance, radius);
        }
        else
        {
            // SphereCast�����ɂ�������Ȃ������ꍇ�A�ΐF��Ray��`��
            Debug.DrawRay(ray.origin, ray.direction * distance, Color.green);
            // Ray�̏I�_�ɋ���`��
            Gizmos.DrawWireSphere(ray.origin + ray.direction * distance, radius);
        }
    }
    #endregion
}