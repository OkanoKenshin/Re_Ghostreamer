using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HADestroy : MonoBehaviour
{
    [SerializeField]
    CenterDataOfHAGhost _centerDataOfHAGhost;

    [SerializeField]
    GameObject HAGhost;

    [SerializeField]
    Animation _animation;

    private void Start()
    {
        _animation = GetComponent<Animation>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_centerDataOfHAGhost.haGhHp <= 0)
        {
            _animation.MGhDeathAnima();
            StartCoroutine(HaDeathCt(1));
        }
    }

    IEnumerator HaDeathCt(float duration)
    {
        yield return new WaitForSeconds(duration);
        Destroy(HAGhost);
    }
}
