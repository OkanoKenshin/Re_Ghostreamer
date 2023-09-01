using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    [SerializeField]
    CenterDataOfHAGhost _centerDataOfHAGhost;

    [SerializeField]
    CenterDataOfFPGhost _centerDataOfFPGhost;

    [SerializeField]
    CenterDataOfFGGhost _centerDataOfFGGhost;

    [SerializeField]
    GameObject FGGhost;
    [SerializeField]
    GameObject FPGhost;
    [SerializeField]
    GameObject HAGhost;


    // Update is called once per frame
    void Update()
    {
        if(_centerDataOfFPGhost.fpGhHp <= 0)
        {
            Destroy(FPGhost);
        }
        if(_centerDataOfFGGhost.fgGhHp <= 0)
        {
            Destroy(FGGhost);
        }
        if (_centerDataOfHAGhost.haGhHp <= 0)
        {
            Destroy(HAGhost);
        }
    }
}
