using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Streamer"))
        {
            // "streamer" ���C���[�̃I�u�W�F�N�g�ɂԂ������ꍇ�̏���
            Debug.Log("Hit an object with the 'streamer' layer!");
        }
    }
}
