using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RaySettings : MonoBehaviour
{
    //このスクリプトはFlashLightの親オブジェクトのLightSlotにアタッチする。

    #region 変数用意
    public Vector3 rayStartPoint;
    // ライト光源のtransform.positionを取得
    public Vector3 rayDirection;
    // ライト光源のtransform.forwordを取得
    public Vector3 localRayStartPoint;
    // このScriptがアタッチされてるObjectのローカル座標を格納する変数。
    public Ray rayOfLight;
    // GhostCollisionCheckerで使用するRay

    #endregion

    void Awake()
    {
        rayOfLight = new Ray(rayStartPoint, rayDirection);
    }

    private void FixedUpdate()
    {
        localRayStartPoint = transform.localPosition;
        rayDirection = transform.forward;
        //全ての元となる始点と方向を初期化

        rayStartPoint = transform.parent.TransformPoint(localRayStartPoint);
        rayOfLight.origin = rayStartPoint;
        rayOfLight.direction = rayDirection;
    }
}