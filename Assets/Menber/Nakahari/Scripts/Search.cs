using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//  ���X�g�̓��e
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
    public float interval = 2.0f;   //  N�b���Ƃɑ��Ղ�ǉ�
    public int maxFootPrints = 10;  //  �ő�M�̑��Ղ�ێ�

    [SerializeField]
    public GameObject FootPrintPrefab;  //  ���Ղ̃v���n�u

    private List<FootPrint> footPrint = new List<FootPrint>();  //  List

    [SerializeField]
    private Transform streamer; //  transform���擾����I�u�W�F�N�g

    private float lastRecordTime;   //  �O�񑫐Ղ��L�^�������Ԃ�ێ�

    [SerializeField]
    private bool InputOn = false;

    // Start is called before the first frame update
    void Start()
    {
        streamer = GameObject.Find("Streamer").transform; // �ǐՂ���I�u�W�F�N�g���w��
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
            footPrint.RemoveAt(0);  //  �ő吔�𒴂�����Â����Ղ��폜
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
        Destroy(_footPrint, interval); // ��莞�Ԍ�ɑ��Ղ��폜
    }
}

