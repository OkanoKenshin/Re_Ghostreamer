using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FGGhDamageCameraEffect : MonoBehaviour
{
    GlitchFx gf;

    [SerializeField]
    float Value;

    [SerializeField]
    float time;

    //[SerializeField]
    //LightHitDetection lhd;

    float fgBaseHp;

    [SerializeField]
    CenterDataOfFGGhost cdof;

    // Start is called before the first frame update
    void Start()
    {
        if(gf == null)
        {
            gf = GetComponent<GlitchFx>();
        }

        //if(lhd == null)
        //{
        //    lhd = GetComponent<LightHitDetection>();
        //}

        if (cdof == null)
        {
            cdof = GetComponent<CenterDataOfFGGhost>();
        }
        fgBaseHp = cdof.fgGhHp;
        gf.intensity = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(cdof.fgGhHp < fgBaseHp)
        {
            gf.intensity = Value;
            StartCoroutine(Effect());
            fgBaseHp = cdof.fgGhHp;
        }
    }

    IEnumerator Effect()
    {
        yield return new WaitForSeconds(time);
        gf.intensity = 0;
    }
}
