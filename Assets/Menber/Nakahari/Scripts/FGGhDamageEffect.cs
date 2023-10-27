using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FGGhDamageEffect : MonoBehaviour
{
    [SerializeField]
    CenterDataOfFGGhost cdof;

    float fgBaseHp;

    [SerializeField]
    GameObject obj;
    [SerializeField]
    GameObject obj2;
    [SerializeField]
    GameObject obj3;

    float fgHp;

    Color color;

    [SerializeField]
    float time;


    // Start is called before the first frame update
    void Start()
    {
        if(cdof == null)
        {
            cdof= GetComponent<CenterDataOfFGGhost>();
        }
        fgBaseHp = cdof.fgGhHp;       
    }

    // Update is called once per frame
    void Update()
    {
        if (cdof.fgGhHp < fgBaseHp)
        {
            //fgHp = (cdof.fgGhHp / fgBaseHp - 1) * -1;
            //color.a = fgHp;
            StartCoroutine(Effect());
            fgBaseHp = cdof.fgGhHp;
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
