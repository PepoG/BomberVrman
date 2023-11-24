using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Normal.Realtime;

public class HideLocalPlayerAvatar : MonoBehaviour {
    public bool hideLocalAvatar = true;

    private RealtimeAvatarManager avatarManager = null;

    void Awake() {
        avatarManager = GetComponent<RealtimeAvatarManager>();
    }

    void OnEnable() {
        avatarManager.avatarCreated += AvatarCreated;
    }

    void OnDisable() {
        avatarManager.avatarCreated -= AvatarCreated;
    }

    private void AvatarCreated(RealtimeAvatarManager manager, RealtimeAvatar avatar, bool isLocalAvatar) {
        if (isLocalAvatar && hideLocalAvatar) {
            Debug.Log("Hiding Local Avatar");
            TurnOffAllMeshRenderers(avatar.gameObject);
        }
    }

    private void TurnOffAllMeshRenderers(GameObject obj) {
        MeshRenderer[] renderers = obj.GetComponentsInChildren<MeshRenderer>();
        for (int i = 0; i < renderers.Length; i += 1) {
            MeshRenderer rndr = renderers[i];
            rndr.enabled = false;
        }

        SkinnedMeshRenderer[] skinned_renderers = obj.GetComponentsInChildren<SkinnedMeshRenderer>();
        for (int i = 0; i < skinned_renderers.Length; i += 1) {
            SkinnedMeshRenderer rndr = skinned_renderers[i];
            rndr.enabled = false;
        }
    }

}
