using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.Users;
using static SingleUserAndDisplayPair;
using static UnityEngine.UIElements.UxmlAttributeDescription;

public class UserAndDisplayPair : MonoBehaviour
{

    public static UserAndDisplayPair Instance { get; private set; }
    //�V���O���g����`

    public List<UserDisplayPair> UserDisplayPairs = new List<UserDisplayPair>();
    //List�̐錾��New�ŏ�����

    void Awake()
    {
        if (Instance == null)
        //�V���O���g�������ɂ��邩�ǂ������`�F�b�N
        {
            Instance = GetComponent<UserAndDisplayPair>();
            DontDestroyOnLoad(gameObject);
            //�����ꍇ�͐V�݁��폜����Ȃ��悤�ɐݒ�
        }
        else
        {
            Destroy(gameObject);
            //���ɂ���V���O���g��Object������
        }
    }

    public void PairUserWithDisplay()
    //InputUser(�R���g���[���Ɖ��z�̃v���C���[�T�O�̃Z�b�g)�ƃf�B�X�v���C��pair�ɂ��ĕێ����Ă��������^�C�~���O�Ń��\�b�h�Ăяo���B
    {
        var user = InputUser.all;
  
    for (int countNum = 0; countNum < user.Count; countNum++)
        {
            if (countNum < Display.displays.Length)
            {
                var pair = new UserDisplayPair(user[countNum], Display.displays[countNum]);
                //pair��List���i�[�B
                UserDisplayPairs.Add(pair);
                //UserDisplayPairs�Ƃ������X�g��"pair"��Add����B

            }
        }
    }
}


