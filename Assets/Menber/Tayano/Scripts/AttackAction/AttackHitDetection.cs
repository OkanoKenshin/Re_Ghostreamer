using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackHitDetection :MonoBehaviour
{
    public bool attackHitTheStreamer;

    [SerializeField]
    public float ghAttackPower;

    public bool heavyAttakActive;

    public GameObject AttachedCenterDataOfStreamer;
    CenterDataOfStreamer _centerDataOfStreamer;

    private void Awake()
    {
        #region "CenterDataOfStreamer"��Null�`�F�b�N
        if (AttachedCenterDataOfStreamer != null)
        {
            _centerDataOfStreamer = GetComponent<CenterDataOfStreamer>();
            if (_centerDataOfStreamer != null)
            {
                Debug.Log("�uCenterDataOfStreamer�v�͐���Ɏ擾����Ă��܂��B");
            }
            else
            {
                Debug.Log("�uAttachedCenterDataOfStreamer�v�̓A�^�b�`����Ă��܂����A�uCenterDataOfStreamer�v�̎擾�Ɏ��s���Ă��܂��B");
            }
        }
        else
        {
            Debug.Log("�uAttachedCenterDataOfStreamer�v�̓A�^�b�`����Ă��܂���B");
        }
        #endregion

    }

    public void MAttackHitDetection()
    {
        if (attackHitTheStreamer == true)
        {
            if (heavyAttakActive)
            {
                float hADamage = (ghAttackPower);
                _centerDataOfStreamer.stHp -= hADamage;
                Debug.Log("Streamer��HP��stHp�ł�");
            }
            else
            {
                _centerDataOfStreamer.stHp -= ghAttackPower;
            }
            attackHitTheStreamer = false;

        }
    }
}
