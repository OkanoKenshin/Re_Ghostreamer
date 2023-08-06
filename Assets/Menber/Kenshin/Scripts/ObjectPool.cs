using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [System.Serializable]
    public class Pool  // Pool�Ƃ����N���X���`���܂��B�����ɂ́A�e�I�u�W�F�N�g�v�[���̏����i�[���܂��i�^�O�A�v���t�@�u�A�T�C�Y�j
    {
        public string tag;  // ���̃v�[�������ʂ��邽�߂̃^�O
        public GameObject prefab;  // �v�[������I�u�W�F�N�g�̃v���t�@�u
        public int size;  // ���O�ɐ������Ă���Object���B�����ɂ��镪�����J�肵�ďo���������肵�܂����肷��B
    }

    public static ObjectPool Instance;  // ObjectPool�N���X���g�̐ÓI�C���X�^���X�B�V���O���g���Ƃ��ĐU�镑���܂��B

    public List<Pool> pools;  // �Ǘ��������v�[���̃��X�g
    public Dictionary<string, Queue<GameObject>> poolDictionary;  // �e�v�[�����Ǘ����鎫���B�L�[�̓v�[���̃^�O�A�l�̓v�[�����̃Q�[���I�u�W�F�N�g�̃L���[�B

    private void Awake()  // Unity��Awake���\�b�h�B�Q�[���I�u�W�F�N�g���������ꂽ�Ƃ��ɌĂяo����܂��B
    {
        Instance = this;  // �V���O���g���Ƃ��ẴC���X�^���X��ݒ肵�܂��B

        poolDictionary = new Dictionary<string, Queue<GameObject>>();  // poolDictionary�����������܂��B

        foreach (Pool pool in pools)  // �e�v�[���ɑ΂���
        {
            Queue<GameObject> objectPool = new Queue<GameObject>();  // �V����GameObject�̃L���[���쐬���܂��B

            for (int i = 0; i < pool.size; i++)  // �e�v�[���̃T�C�Y�����J��Ԃ��܂��B
            {
                GameObject obj = Instantiate(pool.prefab);  // �v���t�@�u���C���X�^���X�����܂��B
                obj.SetActive(false);  // �I�u�W�F�N�g���A�N�e�B�u�ɂ��܂��i�g�p����܂Łj�B
                objectPool.Enqueue(obj);  // �I�u�W�F�N�g���L���[�ɒǉ����܂��B
            }

            poolDictionary.Add(pool.tag, objectPool);  // poolDictionary�ɐV�����G���g����ǉ����܂��B�L�[�̓v�[���̃^�O�A�l�͐�قǍ쐬�����I�u�W�F�N�g�̃L���[�B
        }
    }


    public GameObject SpawnFromPool(string tag, Vector3 position, Quaternion rotation)  // �w�肵���^�O�̃v�[������Q�[���I�u�W�F�N�g���擾���A�w�肵���ʒu�Ɖ�]�ŃX�|�[�������܂��B
    {
        if (!poolDictionary.ContainsKey(tag))  // �^�O��poolDictionary�ɑ��݂��Ȃ��ꍇ��
        {
            Debug.LogWarning("Pool with tag " + tag + " doesn't exist.");  // �x�������O�ɏo�͂��܂��B
            return null;  // null��Ԃ��܂��B
        }

        GameObject objectToSpawn = poolDictionary[tag].Dequeue();  // poolDictionary����I�u�W�F�N�g�����o���܂��B

        objectToSpawn.SetActive(true);  // �I�u�W�F�N�g���A�N�e�B�u�ɂ��܂��B
        objectToSpawn.transform.position = position;  // �I�u�W�F�N�g�̈ʒu��ݒ肵�܂��B
        objectToSpawn.transform.rotation = rotation;  // �I�u�W�F�N�g�̉�]��ݒ肵�܂��B

        poolDictionary[tag].Enqueue(objectToSpawn);  // �I�u�W�F�N�g���Ăуv�[���ɒǉ����܂��B

        return objectToSpawn;  // �X�|�[�������I�u�W�F�N�g��Ԃ��܂��B
    }
}
