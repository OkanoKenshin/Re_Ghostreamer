using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost3hp : MonoBehaviour
{
    [SerializeField]
    GameObject st;
    LightHitDetection _lightHitDetection;
    public float GH3hp;
    // Start is called before the first frame update
    void Start()
    {
        _lightHitDetection = st.GetComponent<LightHitDetection>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_lightHitDetection.thirdGhHp <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
