using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;
public class NetworkPlayer : NetworkBehaviour
{
    public Transform leftHand;
    public Transform playerPrefab;
    private Transform playerPrefabOrignal;
    // Start is called before the first frame update
    void Start()
    {
        playerPrefabOrignal = GameObject.Find("PlayerPrefab(Clone)").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if(IsOwner)
        {
            leftHand.position = VRRigReferences.Singleton.leftHand.position;
            leftHand.rotation = VRRigReferences.Singleton.leftHand.rotation;
            playerPrefab.position = playerPrefabOrignal.position;
            playerPrefab.rotation = playerPrefabOrignal.rotation;
        }
    }
}
