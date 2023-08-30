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
        #region CenterOfLightDataのNullチェック
        if (AttachedCenterOfLightData != null)
        {
            _centerOfLightData = GetComponent<CenterOfLightData>();
            if (_centerOfLightData != null)
            {
                Debug.Log("「CenterOfLightData」は正常に取得されています。");
            }
            else
            {
                Debug.Log("「AttachedCenterOfLightData」はアタッチされていますが、「CenterOfLightData」の取得に失敗しています。");
            }
        }
        else
        {
            Debug.Log("「AttachedCenterOfLightData」はアタッチされていません。");
        }
        #endregion

        #region "RaySettings"のNullチェック
        if (RaySettingsObject != null)
        {
            _raySettings = AttachedRaySettings.GetComponent<RaySettings>();
            if (_raySettings != null)
            {
                Debug.Log("「RaySettings」は正常に取得されています。");
            }
            else
            {
                Debug.Log("「RaySettingsObject」はアタッチされていますが、「RaySettings」の取得に失敗しています。");
            }
        }
        else
        {
            Debug.Log("「RaySettingsObject」はアタッチされていません。");
        }
        #endregion

        #region "LightHitDetection"のNullチェック
        if (AttachedLightHitDetection != null)
        {
            _lightHitDetection = AttachedLightHitDetection.GetComponent<LightHitDetection>();
            if (_lightHitDetection != null)
            {
                Debug.Log("「LightHitDetection」は正常に取得されています。");
            }
            else
            {
                Debug.Log("「AttachedLightHitDetection」はアタッチされていますが、「LightHitDetection」の取得に失敗しています。");
            }
        }
        else
        {
            Debug.Log("「AttachedLightHitDetection」はアタッチされていません。");
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
        // 球状の判定を飛ばしてLightRayDistanceの距離内にあるすべてのObjectを検出するRaycast
        //DrawSphereCast(_raySettings.rayOfLight, lightRayRadius, distance: _centerOfLightData.valueOfLaserLightRange);
        Debug.DrawRay(_raySettings.rayStartPoint, rays,Color.red);
        //Rayの可視化着弾地点に球を描写。ChatGPTで作成したDebug機能。

        Debug.Log($"InformationObtainedByRay length: {InformationObtainedByRay.Length}");
        //InformationObtainedByRayという配列の要素数を表示するDebug.Log。

        foreach (RaycastHit checkObject in InformationObtainedByRay)
        //InformationObtainedByRayという配列にあるRaycastHitの情報をcheckObjectという変数に移す。
        {
            hitLayer = checkObject.transform.gameObject.layer;
            // 以下の処理で検出している2つのLayer以外は処理に考慮する必要が無いので条件に加えない。

            Debug.Log(hitLayer);
            if (hitLayer == layerWithNonLightPenetratingObjects)
            // layerWithNonLightPenetratingObjects ＝ ライトの当たり判定が貫通しないObjectの存在するLayer
            // 非貫通Objectがヒットしたら即breakする
            {
                break;
            }
            else if (hitLayer == layerWithGhost)
            // layerWithGhost ＝ Ghostのワールドモデルが存在するLayer
            // これがヒットいる場合、Ghostのどれかに確実に当たっている。
            {
                _lightHitDetection.MLightHitDetection();
                _lightHitDetection.ghostTagHit = checkObject.transform.gameObject.tag;
                Debug.Log(checkObject.transform.gameObject.tag);
                // Tagの中身をコンソールに表示
            }
        }
    }


    #region Rayの可視化と着弾地点に球を表示するDebug機能
    private void DrawSphereCast(Ray ray, float radius, float distance)
    {
        RaycastHit hit;
        if (Physics.SphereCast(ray, radius, out hit, distance))
        {
            // SphereCastが何かに当たった場合、赤色でRayを描画
            Debug.DrawRay(ray.origin, ray.direction * hit.distance, Color.red);
            // 当たったポイントに球を描画
            Gizmos.DrawWireSphere(ray.origin + ray.direction * hit.distance, radius);
        }
        else
        {
            // SphereCastが何にも当たらなかった場合、緑色でRayを描画
            Debug.DrawRay(ray.origin, ray.direction * distance, Color.green);
            // Rayの終点に球を描画
            Gizmos.DrawWireSphere(ray.origin + ray.direction * distance, radius);
        }
    }
    #endregion
}