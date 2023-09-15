using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Judge : MonoBehaviour //ストリーマー、ゴーストのどちらかが勝利した場合、勝利シーンに遷移する
{
    //[SerializeField]
    //GameObject AttachedCenterDataOfStreamer;
    [SerializeField]
    CenterDataOfStreamer _centerDataOfStreamer;

    //[SerializeField]
    //GameObject AttachedCenterDataOfHAGhost;
    [SerializeField]
    CenterDataOfHAGhost _centerDataOfHAGhost;

    //[SerializeField]
    //GameObject AttachedCenterDataOfFPGhost;
    [SerializeField]
    CenterDataOfFPGhost _centerDataOfFPGhost;

    //[SerializeField]
    //GameObject AttachedCenterDataOfFGGhost;
    [SerializeField]
    CenterDataOfFGGhost _centerDataOfFGGhost;
    // Start is called before the first frame update
    void Awake()
    {
        
        if(_centerDataOfStreamer == null)
        {
           
            _centerDataOfStreamer = GetComponent<CenterDataOfStreamer>();//CenterDataOfStreamerのnullチェック
        }
        if (_centerDataOfHAGhost == null)
        {
           
            _centerDataOfHAGhost = GetComponent<CenterDataOfHAGhost>();//CenterDataOfHAGhostのnullチェック
        }
        if (_centerDataOfFPGhost == null)
        {
           
            _centerDataOfFPGhost = GetComponent<CenterDataOfFPGhost>();//CenterDataOfFPGhostのnullチェック
        }
        if (_centerDataOfFGGhost == null)
        {
           
            _centerDataOfFGGhost = GetComponent<CenterDataOfFGGhost>();//CenterDataOfFGGhostのnullチェック
        }


    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        StVictory();
        GhVictory();
    }

    void StVictory()//ゴースト３体のHPがすべて0になったらストリーマーの勝利シーンへと遷移する
    {
        if (_centerDataOfFGGhost.fgGhHp <= 0 && _centerDataOfFPGhost.fpGhHp <= 0 && _centerDataOfHAGhost.haGhHp <= 0)
        {
            SceneManager.LoadScene("StVictoryScene");
        }
        
    }

    void GhVictory()//ストリーマーのHPが0になったらゴーストの勝利シーンへと遷移する
    {
        if (_centerDataOfStreamer.stHp <= 0)
        {
            SceneManager.LoadScene("GhVictoryScene");
        }
        
    }
}
