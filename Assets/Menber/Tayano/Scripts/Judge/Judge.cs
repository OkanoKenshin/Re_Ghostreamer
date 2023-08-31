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
        #region "CenterDataOfStreamer"のNullチェック
        if (AttachedCenterDataOfStreamer != null)
        {
            _centerDataOfStreamer = GetComponent<CenterDataOfStreamer>();
            if (_centerDataOfStreamer != null)
            {
                Debug.Log("「CenterDataOfStreamer」は正常に取得されています。");
            }
            else
            {
                Debug.Log("「AttachedCenterDataOfStreamer」はアタッチされていますが、「CenterDataOfStreamer」の取得に失敗しています。");
            }
        }
        else
        {
            Debug.Log("「AttachedCenterDataOfStreamer」はアタッチされていません。");
        }
        #endregion

        #region "CenterDataOfHAGhost"のNullチェック
        if (AttachedCenterDataOfHAGhost != null)
        {
            _centerDataOfHAGhost = GetComponent<CenterDataOfHAGhost>();
            if (_centerDataOfHAGhost != null)
            {
                Debug.Log("「CenterDataOfHAGhost」は正常に取得されています。");
            }
            else
            {
                Debug.Log("「AttachedCenterDataOfHAGhost」はアタッチされていますが、「CenterDataOfHAGhost」の取得に失敗しています。");
            }
        }
        else
        {
            Debug.Log("「AttachedCenterDataOfHAGhost」はアタッチされていません。");
        }
        #endregion

        #region "CenterDataOfFPGhost"のNullチェック
        if (AttachedCenterDataOfFPGhost != null)
        {
            _centerDataOfFPGhost = GetComponent<CenterDataOfFPGhost>();
            if (_centerDataOfFPGhost != null)
            {
                Debug.Log("「CenterDataOfFPGhost」は正常に取得されています。");
            }
            else
            {
                Debug.Log("「AttachedCenterDataOfFPGhost」はアタッチされていますが、「CenterDataOfFPGhost」の取得に失敗しています。");
            }
        }
        else
        {
            Debug.Log("「AttachedCenterDataOfFPGhost」はアタッチされていません。");
        }
        #endregion

        #region "CenterDataOfFGGhost"のNullチェック
        if (AttachedCenterDataOfFGGhost != null)
        {
            _centerDataOfFGGhost = GetComponent<CenterDataOfFGGhost>();
            if (_centerDataOfFGGhost != null)
            {
                Debug.Log("「CenterDataOfFGGhost」は正常に取得されています。");
            }
            else
            {
                Debug.Log("「AttachedCenterDataOfFGGhost」はアタッチされていますが、「CenterDataOfFGGhost」の取得に失敗しています。");
            }
        }
        else
        {
            Debug.Log("「AttachedCenterDataOfFGGhost」はアタッチされていません。");
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
