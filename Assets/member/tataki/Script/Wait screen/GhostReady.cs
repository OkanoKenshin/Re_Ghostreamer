using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GhostReady : MonoBehaviour
{
    private void ReadyButton()
    {
        SceneManager.LoadScene("GameScene");
    }
}
