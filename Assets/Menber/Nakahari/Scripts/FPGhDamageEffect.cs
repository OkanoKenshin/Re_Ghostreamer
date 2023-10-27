using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPGhDamageEffect : MonoBehaviour
{
    [SerializeField]
    CenterDataOfFPGhost cdop;

    float fpBaseHp;

    [SerializeField]
    GameObject obj;

    [SerializeField]
    float time;

    // Start is called before the first frame update
    void Start()
    {
        if(cdop == null)
        {
            cdop= GetComponent<CenterDataOfFPGhost>();
        }
        fpBaseHp = cdop.fpGhHp;
    }

    // Update is called once per frame
    void Update()
    {
        if (cdop.fpGhHp < fpBaseHp)
        {
            StartCoroutine(Effect());
            fpBaseHp = cdop.fpGhHp;
        }
        else
        {
            obj.SetActive(false);
        }
    }

    IEnumerator Effect()
    {
        obj.SetActive(true);
        yield return new WaitForSeconds(time);
    }
}
