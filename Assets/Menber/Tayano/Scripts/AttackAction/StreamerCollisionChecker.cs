using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StreamerCollisionChecker : MonoBehaviour
{
    //GhAttackHandlingのインスタンス作成(クラス直下に記述)
    [SerializeField]
    GameObject GhAttackIntervalContorolObject;

    GhAttackActionIntervalContorol _ghAttackIntervalContorol;

    [SerializeField]
    private const int layerWithStreamer = 8;

    [SerializeField]
    private const int layerWithGhost = 10;

    [SerializeField]
    private  const int layerWithManipulativeObject = 20;

    //"AttackHitDetection"の参照作成
    [SerializeField]
    GameObject AttachedAttackHitDetection;
    AttackHitDetection _attackHitDetection;

    /*
    "IdentifyTouchedObjects"の参照作成
    [SerializeField]
    GameObject AttachedIdentifyTouchedObjects;
    IdentifyTouchedObjects _identifyTouchedObjects;
    */
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

        #region AttackHitDetectionのNullチェック
        if (AttachedAttackHitDetection != null)
        {
            _attackHitDetection = AttachedAttackHitDetection.GetComponent<AttackHitDetection>();
            if (_attackHitDetection != null)
            {
                Debug.Log("「AttackHitDetection」は正常に取得されています。");
            }
            else
            {
                Debug.Log("「AttachedAttackHitDetection」は取得されていますが、 「AttackHitDetection」の取得に失敗しています。");
            }
        }
        else
        {
            Debug.Log("「AttachedAttackHitDetection」は取得されていません。");
        }
        #endregion

        #region IdentifyTouchedObjectsのNullチェック
        //if (AttachedIdentifyTouchedObjects != null)
        //{
        //    _identifyTouchedObjects = GetComponent<IdentifyTouchedObjects>();
        //    if (_identifyTouchedObjects != null)
        //    {
        //        Debug.Log("「IdentifyTouchedObjects」は正常に取得されています。");
        //    }
        //    else
        //    {
        //        Debug.Log("「AttachedIdentifyTouchedObjects」はアタッチされていますが、 「IdentifyTouchedObjects」の取得に失敗しています。");
        //    }
        //}
        //else
        //{
        //    Debug.Log("「AttachedIdentifyTouchedObjects」はアタッチされていません。");
        //}
        #endregion
    }

    // Update is called once per frame
    void Update()
    {
        
    }
   private void OnCollisionEnter(Collision hitInfo)
    //hit情報を"hitInfo"に格納
    {
        int layerToHit = hitInfo.gameObject.layer;
        //hitInfoからヒットObjectのレイヤー情報を引き出し、layerToHitに代入。

        Collider myCollider = GetComponent<Collider>();
        int layerOfThis = myCollider.gameObject.layer;
        //このscriptがアタッチされてるGameObjectについてるlayerを取得

        switch (layerOfThis)
        //このscriptがアタッチされてるGameObjectが何かを判定
        {
            case layerWithGhost:
                //Ghostにこのscriptがアタッチされている場合
                if (layerWithStreamer == layerToHit)
                //ヒットした対象がStreamerか判定
                {
                    _attackHitDetection.attackHitTheStreamer = true;
                }
                break;

        }
    }

}
