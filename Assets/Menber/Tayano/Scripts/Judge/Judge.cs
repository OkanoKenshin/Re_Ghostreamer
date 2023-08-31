using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Judge : MonoBehaviour
{
    [SerializeField]
    GameObject AttachedCenterDataOfStreamer;
    CenterDataOfStreamer _centerDataOfStreamer;

    [SerializeField]
    GameObject AttachedCenterDataOfHAGhost;
    CenterDataOfHAGhost _centerDataOfHAGhost;

    [SerializeField]
    GameObject AttachedCenterDataOfFPGhost;
    CenterDataOfFPGhost _centerDataOfFPGhost;

    [SerializeField]
    GameObject AttachedCenterDataOfFGGhost;
    CenterDataOfFGGhost _centerDataOfFGGhost;
    // Start is called before the first frame update
    void Awake()
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

        #region "CenterDataOfHAGhost"��Null�`�F�b�N
        if (AttachedCenterDataOfHAGhost != null)
        {
            _centerDataOfHAGhost = GetComponent<CenterDataOfHAGhost>();
            if (_centerDataOfHAGhost != null)
            {
                Debug.Log("�uCenterDataOfHAGhost�v�͐���Ɏ擾����Ă��܂��B");
            }
            else
            {
                Debug.Log("�uAttachedCenterDataOfHAGhost�v�̓A�^�b�`����Ă��܂����A�uCenterDataOfHAGhost�v�̎擾�Ɏ��s���Ă��܂��B");
            }
        }
        else
        {
            Debug.Log("�uAttachedCenterDataOfHAGhost�v�̓A�^�b�`����Ă��܂���B");
        }
        #endregion

        #region "CenterDataOfFPGhost"��Null�`�F�b�N
        if (AttachedCenterDataOfFPGhost != null)
        {
            _centerDataOfFPGhost = GetComponent<CenterDataOfFPGhost>();
            if (_centerDataOfFPGhost != null)
            {
                Debug.Log("�uCenterDataOfFPGhost�v�͐���Ɏ擾����Ă��܂��B");
            }
            else
            {
                Debug.Log("�uAttachedCenterDataOfFPGhost�v�̓A�^�b�`����Ă��܂����A�uCenterDataOfFPGhost�v�̎擾�Ɏ��s���Ă��܂��B");
            }
        }
        else
        {
            Debug.Log("�uAttachedCenterDataOfFPGhost�v�̓A�^�b�`����Ă��܂���B");
        }
        #endregion

        #region "CenterDataOfFGGhost"��Null�`�F�b�N
        if (AttachedCenterDataOfFGGhost != null)
        {
            _centerDataOfFGGhost = GetComponent<CenterDataOfFGGhost>();
            if (_centerDataOfFGGhost != null)
            {
                Debug.Log("�uCenterDataOfFGGhost�v�͐���Ɏ擾����Ă��܂��B");
            }
            else
            {
                Debug.Log("�uAttachedCenterDataOfFGGhost�v�̓A�^�b�`����Ă��܂����A�uCenterDataOfFGGhost�v�̎擾�Ɏ��s���Ă��܂��B");
            }
        }
        else
        {
            Debug.Log("�uAttachedCenterDataOfFGGhost�v�̓A�^�b�`����Ă��܂���B");
        }
        #endregion

    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        StVictory();
        GhVictory();
    }

    void StVictory()
    {
        if (_centerDataOfFGGhost.fgGhHp <= 0 && _centerDataOfFPGhost.fpGhHp <= 0 && _centerDataOfHAGhost.haGhHp <= 0)
        {
            SceneManager.LoadScene("StVictoryScene");
        }
        
    }

    void GhVictory()
    {
        if (_centerDataOfStreamer.stHp <= 0)
        {
            SceneManager.LoadScene("GhVictoryScene");
        }
        
    }
}
