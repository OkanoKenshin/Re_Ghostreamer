using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SamplePanel : MonoBehaviour
{
    [SerializeField] GameObject text;

    void Update()
    {
        //[D]キーを押す
        if (Input.GetKeyDown(KeyCode.D))
        {
            //ゲームオブジェクト非表示→表示
            text.SetActive(true);
        }
    }
}
