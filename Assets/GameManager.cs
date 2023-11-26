using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public bool resetGame;
    public InputActionProperty resetGameAction;
    public GameObject canvas;
    public TextMeshProUGUI textMeshProUGUI;
    public string winPlayer;
    public GameObject VRPlayer;
    public GameObject XRRig;
    private bool isDirectView = false;
    //public GameObject powerUpSoundEffectPrefab;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    //public void PlayPowerupSound()
    //{
    //    Instantiate(powerUpSoundEffectPrefab);
    //}

    // Update is called once per frame
    void Update()
    {
        if(resetGame)
        {
            textMeshProUGUI.text = winPlayer;
            canvas.SetActive(true);

        }
        if (resetGame && resetGameAction.action.WasPressedThisFrame())
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        } else if (resetGameAction.action.WasPressedThisFrame())
        {
            if(isDirectView)
            {
                XRRig.transform.parent = null;
                isDirectView = false;
            }
            else
            {
                XRRig.transform.parent = GameObject.Find("PlayerPrefab(Clone)").transform;
                isDirectView = true;

            }
            // XRRig.transform.parent = VRPlayer.transform;
        }
    }
}
