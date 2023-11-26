using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using Unity.Netcode;

public class NetworkPlayerPrebab : NetworkBehaviour
{
    public Transform playerPrefab;
    public Transform playerPrefabOrignal;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (IsOwner)
        {
            playerPrefab.position = playerPrefabOrignal.position;
            playerPrefab.rotation = playerPrefabOrignal.rotation;
        }
    }
}
