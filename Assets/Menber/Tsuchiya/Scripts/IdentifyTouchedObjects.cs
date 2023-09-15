using UnityEngine;

/*public class IdentifyTouchedObjects : MonoBehaviour
{
    public string touchedObject;
    public bool lookingAtMap;
    private bool inputOn;

    [SerializeField] private GameObject AttachedCollectTheIRCamera;
    private CollectTheIRCamera _collectTheIRCamera;

    [SerializeField] private GameObject AttachedCloserToTheMap;
    private CloserToTheMap _closerToTheMap;

    private void Awake()
    {
        if (AttachedCollectTheIRCamera != null)
        {
            _collectTheIRCamera = AttachedCollectTheIRCamera.GetComponent<CollectTheIRCamera>();
            if (_collectTheIRCamera != null)
            {
                Debug.Log("「CollectTheIRCamera」は正常に取得されています。");
            }
            else
            {
                Debug.Log("「AttachedCollectTheIRCamera」はアタッチされていますが、 「CollectTheIRCamera」の取得に失敗しています。");
            }
        }
        else
        {
            Debug.Log("「AttachedCollectTheIRCamera」はアタッチされていません。");
        }

        if (AttachedCloserToTheMap != null)
        {
            _closerToTheMap = AttachedCloserToTheMap.GetComponent<CloserToTheMap>();
            if (_closerToTheMap != null)
            {
                Debug.Log("「CloserToTheMap」は正常に取得されています。");
            }
            else
            {
                Debug.Log("「AttachedCloserToTheMap」はアタッチされていますが、 「CloserToTheMap」の取得に失敗しています。");
            }
        }
        else
        {
            Debug.Log("「AttachedCloserToTheMap」はアタッチされていません。");
        }
    }

    private void FixedUpdate()
    {
        if (touchedObject != "" && !inputOn)
        {
            switch (touchedObject)
            {
                case "IRCamera":
                    Debug.Log("Xボタンでカメラを回収する");
                    // 「Xボタンでカメラを回収する」と表示するUIをUI担当者が実装
                    break;
                case "FloorMap":
                    Debug.Log("Xボタンでフロアマップを見る");
                    // 「Xボタンでフロアマップを見る」と表示するUIをUI担当者が実装
                    break;
            }
        }

        if (lookingAtMap)
        {
            _closerToTheMap.MReturnPosition();
            _closerToTheMap.MReturnRotation();
        }

        if (touchedObject != "" && inputOn && !lookingAtMap)
        {
            switch (touchedObject)
            {
                case "IRCamera":
                    _collectTheIRCamera.MCollectTheIRCamera();
                    _collectTheIRCamera.MAbortCoroutine();
                    break;
                case "FloorMap":
                    lookingAtMap = true;
                    _closerToTheMap.MMoveThePosition();
                    _closerToTheMap.MMoveTheRotation();
                    // 後からマップを開いている時に移動をロックする機能を追加
                    // UI担当者がここにMapのキャンバスを表示する処理を追加
                    break;
            }
        }
    }
}*/
