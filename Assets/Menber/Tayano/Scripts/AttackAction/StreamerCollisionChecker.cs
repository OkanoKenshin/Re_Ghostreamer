using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StreamerCollisionChecker : MonoBehaviour
{
    //GhAttackHandlingのインスタンス作成(クラス直下に記述)
    [SerializeField]
    GameObject GhAttackIntervalContorolObject;

    GhAttackActionIntervalContorol _ghAttackIntervalContorol;
    // Start is called before the first frame update
    void Awake()
    {
        #region GhAttackIntervalContorolのインスタンス取得とNullチェック(Awakeメソッドに記述)
        if (GhAttackIntervalContorolObject != null)
        {
            _ghAttackIntervalContorol = GetComponent<GhAttackActionIntervalContorol>();
            if (_ghAttackIntervalContorol != null)
            {
                Debug.Log(" _ghAttackIntervalContorolは正常に取得されています。");
            }
            else
            {
                Debug.Log("GhAttackIntervalContorolObjectは取得されていますが、 _ghAttackIntervalContorolの取得に失敗しています。");
            }
        }
        else
        {
            Debug.Log("GhAttackIntervalContorolObjectは取得されていません。");
        }
        #endregion
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision hitInfo)
    //hit情報を"hitInfo"に格納
    {
        int hitObjectlayer = hitInfo.gameObject.layer;
        //hitInfoからヒットObjectのレイヤー情報を引き出し、hitObjectLayerに代入。
        //if (hitObjectlayer == streamerLayerNum)
        //{
        //    attackHitTheStreamer = true;
        //}
    }

}
