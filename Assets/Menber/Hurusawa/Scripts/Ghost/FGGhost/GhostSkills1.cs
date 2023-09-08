using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostSkills1 : MonoBehaviour
{

    private Animator anim;  //Animatorをanimという変数で定義する

    void Start()
    {
        //変数animに、Animatorコンポーネントを設定する
        anim = gameObject.GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            //Bool型のパラメーターであるblRotをTrueにする
            anim.SetBool("Bool1", true);
        }
    }
}