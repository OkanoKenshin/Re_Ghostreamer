using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPDestroy : MonoBehaviour
{
    [SerializeField]
    CenterDataOfFPGhost _centerDataOfFPGhost;

    [SerializeField]
    GameObject FPGhost;

    [SerializeField]
    Animation _animation;

    private void Start()
    {
        _animation = GetComponent<Animation>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_centerDataOfFPGhost.fpGhHp <= 0)
        {
            _animation.MGhDeathAnima();
            StartCoroutine(FpDeathCt(1));
        }
    }

    IEnumerator FpDeathCt(float duration)
    {
        yield return new WaitForSeconds(duration);
        Destroy(FPGhost);
    }
}
