using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sample : MonoBehaviour
{
    public GameObject _canvas;
    bool _exit;
    public Button _NObutton;
    public Button _YESbutton;
    public Button _start;
    public Button _exitbutton;
    
    public void push()
    {
        _exit = true;
    }

    public void nopush()
    {
        _exit = false;
    }

    void Update()
    {
        if(_exit)
        {
            _canvas.SetActive(true);
            Debug.Log("•\Ž¦‚³‚ê‚½");
            _start.interactable = false;
            _exitbutton.interactable = false;
            _NObutton.Select();
            _exit = false;
        }
    }
}
