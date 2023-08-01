using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.Users;
using static SingleUserAndDisplayPair;
using static UnityEngine.UIElements.UxmlAttributeDescription;

public class UserAndDisplayPair : MonoBehaviour
{

    public static UserAndDisplayPair Instance { get; private set; }
    //シングルトン定義

    public List<UserDisplayPair> UserDisplayPairs = new List<UserDisplayPair>();
    //Listの宣言とNewで初期化

    void Awake()
    {
        if (Instance == null)
        //シングルトンが既にあるかどうかをチェック
        {
            Instance = GetComponent<UserAndDisplayPair>();
            DontDestroyOnLoad(gameObject);
            //無い場合は新設＆削除されないように設定
        }
        else
        {
            Destroy(gameObject);
            //既にあるシングルトンObjectを消去
        }
    }

    public void PairUserWithDisplay()
    //InputUser(コントローラと仮想のプレイヤー概念のセット)とディスプレイをpairにして保持しておきたいタイミングでメソッド呼び出し。
    {
        var user = InputUser.all;
  
    for (int countNum = 0; countNum < user.Count; countNum++)
        {
            if (countNum < Display.displays.Length)
            {
                var pair = new UserDisplayPair(user[countNum], Display.displays[countNum]);
                //pairにListを格納。
                UserDisplayPairs.Add(pair);
                //UserDisplayPairsというリストに"pair"をAddする。

            }
        }
    }
}


