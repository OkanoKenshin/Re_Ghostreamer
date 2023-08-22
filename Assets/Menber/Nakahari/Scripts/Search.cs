using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//  リストの内容
[System.Serializable]
public class FootPrint
{
    public Vector3 position;
    public Quaternion rotation;
    public float timestamp;
}

public class Search : MonoBehaviour
{
    [SerializeField]
    public float interval = 2.0f;   //  N秒ごとに足跡を追加
    public int maxFootPrints = 10;  //  最大M個の足跡を保持

    [SerializeField]
    public GameObject FootPrintPrefab;  //  足跡のプレハブ

    private List<FootPrint> footPrint = new List<FootPrint>();  //  List

    [SerializeField]
    private Transform streamer; //  transformを取得するオブジェクト

    private float lastRecordTime;   //  前回足跡を記録した時間を保持

    [SerializeField]
    private bool InputOn = false;

    // Start is called before the first frame update
    void Start()
    {
        streamer = GameObject.Find("Streamer").transform; // 追跡するオブジェクトを指定
        lastRecordTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if(InputOn)
        {
            MRecordFootPrint();
        }

        if(Time.time - footPrint[0].timestamp > interval)
        {
            footPrint.RemoveAt(0);
        }
    }

    private void MRecordFootPrint()
    {
        if(footPrint.Count >= maxFootPrints)
        {
            footPrint.RemoveAt(0);  //  最大数を超えたら古い足跡を削除
        }

        FootPrint newfootPrint = new FootPrint()
        {
            position = streamer.position,
            rotation = streamer.rotation,
            timestamp = Time.time
        };

        footPrint.Add(newfootPrint);

        CreateFootPrint(newfootPrint);  
    }

    private void CreateFootPrint(FootPrint footPrint)
    {
        GameObject _footPrint = Instantiate(FootPrintPrefab,footPrint.position, footPrint.rotation);
        Destroy(_footPrint, interval); // 一定時間後に足跡を削除
    }
}

