using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRRigReferences : MonoBehaviour
{
    public static VRRigReferences Singleton;
    public Transform leftHand;

    private void Awake()
    {
        
        Singleton = this;
    }
}
