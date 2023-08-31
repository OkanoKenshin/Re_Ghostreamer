using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost1hp : MonoBehaviour
{
    [SerializeField]
    GameObject st;
    LightHitDetection _lightHitDetection;
    // Start is called before the first frame update
    void Start()
    {
        _lightHitDetection = st.GetComponent<LightHitDetection>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_lightHitDetection.firstGhHp <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
