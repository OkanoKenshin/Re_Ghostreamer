using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class menu : MonoBehaviour
{
    //�e�{�^���̏��𑼂̃X�N���v�g���狤�L
     private Button _streamer;
     private Button _ghost1;
     private Button _ghost2;
     private Button _ghost3;

    private void Start()
    {
        //�{�^���̃R���|�[�l���g�̎擾
        _streamer = GameObject.Find("/Canvas/Streamer").GetComponent<Button>();
        _ghost1 = GameObject.Find("/Canvas/Ghost1").GetComponent<Button> ();
        _ghost2 = GameObject.Find("Canvas/Ghost2").GetComponent<Button>();
        _ghost3 = GameObject.Find("Canvas/Ghost3").GetComponent<Button>();
        
        //�ŏ��ɑI����Ԃɂ������{�^���̐ݒ�
        _streamer.Select();
    }
}
