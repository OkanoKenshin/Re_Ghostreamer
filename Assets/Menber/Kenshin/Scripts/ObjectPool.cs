using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [System.Serializable]
    public class Pool  // Poolというクラスを定義します。ここには、各オブジェクトプールの情報を格納します（タグ、プレファブ、サイズ）
    {
        public string tag;  // このプールを識別するためのタグ
        public GameObject prefab;  // プールするオブジェクトのプレファブ
        public int size;  // 事前に生成しておくObject数。ここにある分をやり繰りして出現させたりしまったりする。
    }

    public static ObjectPool Instance;  // ObjectPoolクラス自身の静的インスタンス。シングルトンとして振る舞います。

    public List<Pool> pools;  // 管理したいプールのリスト
    public Dictionary<string, Queue<GameObject>> poolDictionary;  // 各プールを管理する辞書。キーはプールのタグ、値はプール内のゲームオブジェクトのキュー。

    private void Awake()  // UnityのAwakeメソッド。ゲームオブジェクトが生成されたときに呼び出されます。
    {
        Instance = this;  // シングルトンとしてのインスタンスを設定します。

        poolDictionary = new Dictionary<string, Queue<GameObject>>();  // poolDictionaryを初期化します。

        foreach (Pool pool in pools)  // 各プールに対して
        {
            Queue<GameObject> objectPool = new Queue<GameObject>();  // 新しいGameObjectのキューを作成します。

            for (int i = 0; i < pool.size; i++)  // 各プールのサイズだけ繰り返します。
            {
                GameObject obj = Instantiate(pool.prefab);  // プレファブをインスタンス化します。
                obj.SetActive(false);  // オブジェクトを非アクティブにします（使用するまで）。
                objectPool.Enqueue(obj);  // オブジェクトをキューに追加します。
            }

            poolDictionary.Add(pool.tag, objectPool);  // poolDictionaryに新しいエントリを追加します。キーはプールのタグ、値は先ほど作成したオブジェクトのキュー。
        }
    }


    public GameObject SpawnFromPool(string tag, Vector3 position, Quaternion rotation)  // 指定したタグのプールからゲームオブジェクトを取得し、指定した位置と回転でスポーンさせます。
    {
        if (!poolDictionary.ContainsKey(tag))  // タグがpoolDictionaryに存在しない場合は
        {
            Debug.LogWarning("Pool with tag " + tag + " doesn't exist.");  // 警告をログに出力します。
            return null;  // nullを返します。
        }

        GameObject objectToSpawn = poolDictionary[tag].Dequeue();  // poolDictionaryからオブジェクトを取り出します。

        objectToSpawn.SetActive(true);  // オブジェクトをアクティブにします。
        objectToSpawn.transform.position = position;  // オブジェクトの位置を設定します。
        objectToSpawn.transform.rotation = rotation;  // オブジェクトの回転を設定します。

        poolDictionary[tag].Enqueue(objectToSpawn);  // オブジェクトを再びプールに追加します。

        return objectToSpawn;  // スポーンしたオブジェクトを返します。
    }
}
