using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SamplePanel : MonoBehaviour
{
    [SerializeField] GameObject text;

    void Update()
    {
        //[D]�L�[������
        if (Input.GetKeyDown(KeyCode.D))
        {
            //�Q�[���I�u�W�F�N�g��\�����\��
            text.SetActive(true);
        }
    }
}
