using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Streamer"))
        {
            // "streamer" レイヤーのオブジェクトにぶつかった場合の処理
            Debug.Log("Hit an object with the 'streamer' layer!");
        }
    }
}
