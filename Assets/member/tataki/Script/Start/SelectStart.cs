using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectStart : MonoBehaviour
{
    public Button _start;
    public Button _exit;

   // private Transform _exitStart;

    private void Start()
    {
       // _start = GameObject.Find("/Canvas/startbutton").GetComponent<Button>();
        //_exit = GameObject.Find("/Canvas/exitbutton").GetComponent <Button>();
       // _exitStart = transform.GetChild(1);
        //Debug.Log("exitbutton");
        _start.Select();
    }
}
