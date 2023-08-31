using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class ButtonClick : MonoBehaviour
{

    void Update()
    {

            if (Input.GetButton("Fire2"))
            {
                SceneManager.LoadScene("Start");
            }
    }
}