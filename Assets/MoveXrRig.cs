using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveXrRig : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var o = GameObject.FindGameObjectWithTag("XR RIg");
        o.transform.parent = transform;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
