using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;
public class NetworkPlayer : NetworkBehaviour
{
    public Transform leftHand;
    public Transform playerPrefab;
    private Transform playerPrefabOrignal;
    public List<Transform> destructibles;
    public List<Transform> destructiblesOriginal;
    public LevelGenerator levelGenerator;

    public Renderer[] meshToDisable;
    // Start is called before the first frame update

    public override void OnNetworkSpawn()
    {
        base.OnNetworkSpawn();
        if (IsOwner)
        {
            foreach (Renderer r in meshToDisable)
            {
                r.enabled = false;
            }
        }

        }
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
            for (int i = 0; i < destructibles.Count; i++)
            {
                destructibles[i].position = destructiblesOriginal[i].position;
            }
        }
    }
}
