using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StreamerCollisionChecker : MonoBehaviour
{
    //GhAttackHandling�̃C���X�^���X�쐬(�N���X�����ɋL�q)
    [SerializeField]
    GameObject GhAttackIntervalContorolObject;

    GhAttackActionIntervalContorol _ghAttackIntervalContorol;
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
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision hitInfo)
    //hit����"hitInfo"�Ɋi�[
    {
        int hitObjectlayer = hitInfo.gameObject.layer;
        //hitInfo����q�b�gObject�̃��C���[���������o���AhitObjectLayer�ɑ���B
        //if (hitObjectlayer == streamerLayerNum)
        //{
        //    attackHitTheStreamer = true;
        //}
    }

}
