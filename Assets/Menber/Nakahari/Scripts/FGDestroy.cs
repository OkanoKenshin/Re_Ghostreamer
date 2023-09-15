using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FGDestroy : MonoBehaviour
{
    [SerializeField]
    CenterDataOfFGGhost _centerDataOfFGGhost;

    [SerializeField]
    GameObject FGGhost;

    [SerializeField]
    Animation _animation;

    private void Start()
    {
        _animation = GetComponent<Animation>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_centerDataOfFGGhost.fgGhHp <= 0)
        {
            _animation.MGhDeathAnima();
            StartCoroutine(FgDeathCt(1));
        }
    }

    IEnumerator FgDeathCt(float duration)
    {
        yield return new WaitForSeconds(duration);
        Destroy(FGGhost);
    }
}
