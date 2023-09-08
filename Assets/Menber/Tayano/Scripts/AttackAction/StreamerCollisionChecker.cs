using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StreamerCollisionChecker : MonoBehaviour
{
    //GhAttackHandling�̃C���X�^���X�쐬(�N���X�����ɋL�q)
    [SerializeField]
    GameObject GhAttackIntervalContorolObject;

    GhAttackActionIntervalContorol _ghAttackIntervalContorol;

    [SerializeField]
    private const int layerWithStreamer = 8;

    [SerializeField]
    private const int layerWithGhost = 10;

    [SerializeField]
    private  const int layerWithManipulativeObject = 20;

    //"AttackHitDetection"�̎Q�ƍ쐬
    [SerializeField]
    GameObject AttachedAttackHitDetection;
    AttackHitDetection _attackHitDetection;

    /*
    "IdentifyTouchedObjects"�̎Q�ƍ쐬
    [SerializeField]
    GameObject AttachedIdentifyTouchedObjects;
    IdentifyTouchedObjects _identifyTouchedObjects;
    */
    // Start is called before the first frame update
    void Awake()
    {

        #region GhAttackIntervalContorol�̃C���X�^���X�擾��Null�`�F�b�N(Awake���\�b�h�ɋL�q)
        if (GhAttackIntervalContorolObject != null)
        {
            _ghAttackIntervalContorol = GetComponent<GhAttackActionIntervalContorol>();
            if (_ghAttackIntervalContorol != null)
            {
                Debug.Log(" _ghAttackIntervalContorol�͐���Ɏ擾����Ă��܂��B");
            }
            else
            {
                Debug.Log("GhAttackIntervalContorolObject�͎擾����Ă��܂����A _ghAttackIntervalContorol�̎擾�Ɏ��s���Ă��܂��B");
            }
        }
        else
        {
            Debug.Log("GhAttackIntervalContorolObject�͎擾����Ă��܂���B");
        }
        #endregion

        #region AttackHitDetection��Null�`�F�b�N
        if (AttachedAttackHitDetection != null)
        {
            _attackHitDetection = AttachedAttackHitDetection.GetComponent<AttackHitDetection>();
            if (_attackHitDetection != null)
            {
                Debug.Log("�uAttackHitDetection�v�͐���Ɏ擾����Ă��܂��B");
            }
            else
            {
                Debug.Log("�uAttachedAttackHitDetection�v�͎擾����Ă��܂����A �uAttackHitDetection�v�̎擾�Ɏ��s���Ă��܂��B");
            }
        }
        else
        {
            Debug.Log("�uAttachedAttackHitDetection�v�͎擾����Ă��܂���B");
        }
        #endregion

        #region IdentifyTouchedObjects��Null�`�F�b�N
        //if (AttachedIdentifyTouchedObjects != null)
        //{
        //    _identifyTouchedObjects = GetComponent<IdentifyTouchedObjects>();
        //    if (_identifyTouchedObjects != null)
        //    {
        //        Debug.Log("�uIdentifyTouchedObjects�v�͐���Ɏ擾����Ă��܂��B");
        //    }
        //    else
        //    {
        //        Debug.Log("�uAttachedIdentifyTouchedObjects�v�̓A�^�b�`����Ă��܂����A �uIdentifyTouchedObjects�v�̎擾�Ɏ��s���Ă��܂��B");
        //    }
        //}
        //else
        //{
        //    Debug.Log("�uAttachedIdentifyTouchedObjects�v�̓A�^�b�`����Ă��܂���B");
        //}
        #endregion
    }

    // Update is called once per frame
    void Update()
    {
        
    }
   private void OnCollisionEnter(Collision hitInfo)
    //hit����"hitInfo"�Ɋi�[
    {
        int layerToHit = hitInfo.gameObject.layer;
        //hitInfo����q�b�gObject�̃��C���[���������o���AlayerToHit�ɑ���B

        Collider myCollider = GetComponent<Collider>();
        int layerOfThis = myCollider.gameObject.layer;
        //����script���A�^�b�`����Ă�GameObject�ɂ��Ă�layer���擾

        switch (layerOfThis)
        //����script���A�^�b�`����Ă�GameObject�������𔻒�
        {
            case layerWithGhost:
                //Ghost�ɂ���script���A�^�b�`����Ă���ꍇ
                if (layerWithStreamer == layerToHit)
                //�q�b�g�����Ώۂ�Streamer������
                {
                    _attackHitDetection.attackHitTheStreamer = true;
                }
                break;

        }
    }

}
