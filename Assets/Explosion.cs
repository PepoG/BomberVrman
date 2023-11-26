using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using Sirenix.Utilities;
using UnityEngine.SceneManagement;
using DG.Tweening.Core.Easing;
using UnityEngine.XR.Interaction.Toolkit;

public class Explosion : MonoBehaviour
{
    public GameObject player;
    public GameObject explosionPrefab;
    public GameObject explosionSoundEffectPrefab;
    public GameObject explosionSizePOwerupPrefab;
    public GameObject upgradeBombPowerupPrefab;
    public GameObject gameStateManager;
    public float maxDistance = 100;
    public int numberOfBombs;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Explode());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnDestroy()
    {
        
        
    }

    void DestroyBlocks(Vector3 direction)
    {
        RaycastHit hit;
        int layerMask = 1 << LayerMask.NameToLayer("Default"); // Correctly create a layer mask
        Physics.Raycast(transform.position, direction, out hit, maxDistance, layerMask);

        if (hit.collider == null)
        {
            return;
        }

        var hitPosition = hit.collider.gameObject.transform.position;
        var diff = hitPosition - transform.position;
        var diffVector = Vector3.Scale(diff, direction);
        Debug.Log("Magnitude to closest:" + diffVector.magnitude);
        var count = Mathf.Round(diffVector.magnitude + 0.5f);

        Debug.Log("Count:" + count);
        Debug.Log("MaxDistance:" + maxDistance);

        if ((count > maxDistance)) {
            Debug.Log("Mu");
            return;
        };

        Debug.Log("Target has tag: " + hit.collider.tag + " naaame:"+hit.collider.gameObject.name);

        if (hit.collider && hit.collider.CompareTag("Destructible")) {
            Debug.Log("Destroying hit target");
            var probabilityOfDropOfExplosionSizeDrop = 0.1f;
            var probabilityOfUpgradeBombDrop = 0.1f;


            if (Random.Range(0f, 1f) <= probabilityOfDropOfExplosionSizeDrop)
            {
                Instantiate(explosionSizePOwerupPrefab, hit.collider.gameObject.transform.position, Quaternion.identity);
            }else if (Random.Range(0f, 1f) <= probabilityOfUpgradeBombDrop)
            {
                Instantiate(upgradeBombPowerupPrefab, hit.collider.gameObject.transform.position, Quaternion.identity);
            }



            Destroy(hit.collider.gameObject);//.SetActive(false);
        }
    }

    IEnumerator Explode() {
        var sound = Instantiate(explosionSoundEffectPrefab);

        yield return new WaitForSeconds(1.2f);

        List<GameObject> gos = new List<GameObject>();

        var go1 = SpawinExplosion(transform.right, gos);
        var go2 = SpawinExplosion(-transform.right, gos);
        var go3 = SpawinExplosion(transform.forward, gos);
        var go4 = SpawinExplosion(-transform.forward, gos);

        var gsm = GameObject.Find("GameStateManager");
        if (go1)
        {
            GameObject.FindWithTag("XR RIg").transform.parent = null;

            Destroy(go1);
            if(gsm)
            {
                gsm.GetComponent<GameManager>().resetGame = true;
                if (go1.name == "PlayerPrefab(Clone)")
                {
                    gsm.GetComponent<GameManager>().winPlayer = "Peayer 2 Wins";
                }
                else
                {
                    gsm.GetComponent<GameManager>().winPlayer = "Peayer 1 Wins";
                }
            }
        }
        if (go2)
        {
            GameObject.FindWithTag("XR RIg").transform.parent = null;

            Destroy(go2);
            if (gsm)
            {
                gsm.GetComponent<GameManager>().resetGame = true;

                if (gsm.GetComponent<GameManager>().winPlayer == "")
                {
                    if (go2.name == "PlayerPrefab(Clone)")
                    {
                        gsm.GetComponent<GameManager>().winPlayer = "Peayer 2 Wins";
                    }
                    else
                    {
                        gsm.GetComponent<GameManager>().winPlayer = "Peayer 1 Wins";
                    }
                }
            }

        }
        if (go3)
        {
            GameObject.FindWithTag("XR RIg").transform.parent = null;

            Destroy(go3);
            if (gsm)
            {
                gsm.GetComponent<GameManager>().resetGame = true;
                if (gsm.GetComponent<GameManager>().winPlayer == "")
                {
                    if (go3.name == "PlayerPrefab(Clone)")
                    {
                        gsm.GetComponent<GameManager>().winPlayer = "Peayer 2 Wins";
                    }
                    else
                    {
                        gsm.GetComponent<GameManager>().winPlayer = "Peayer 1 Wins";
                    }
                }

            }

        }
        if (go4)
        {
            GameObject.FindWithTag("XR RIg").transform.parent = null;

            Destroy(go4);
            if (gsm)
            {
                gsm.GetComponent<GameManager>().resetGame = true;
                if (gsm.GetComponent<GameManager>().winPlayer == "")
                {
                    if (go4.name == "PlayerPrefab(Clone)")
                    {
                        gsm.GetComponent<GameManager>().winPlayer = "Peayer 2 Wins";
                    }
                    else
                    {
                        gsm.GetComponent<GameManager>().winPlayer = "Peayer 1 Wins";
                    }
                }

            }
        }

        if(gameObject.GetComponent<CapsuleCollider>().isTrigger)
        {
            GameObject.FindWithTag("XR RIg").transform.parent = null;

            Destroy(player);
            if (gsm)
            {
                gsm.GetComponent<GameManager>().resetGame = true;
                if (gsm.GetComponent<GameManager>().winPlayer == "")
                {
                    if (player.name == "PlayerPrefab(Clone)")
                    {
                        gsm.GetComponent<GameManager>().winPlayer = "Peayer 2 Wins";
                    }
                    else
                    {
                        gsm.GetComponent<GameManager>().winPlayer = "Peayer 1 Wins";
                    }
                }
            }
        }


        yield return new WaitForSeconds(0.1f);

        foreach (var g in gos)
        {
            Destroy(g);
        }

        DestroyBlocks(transform.right);
        DestroyBlocks(-transform.right);
        DestroyBlocks(transform.forward);
        DestroyBlocks(-transform.forward);

        if(player && player.GetComponent<BombController>() != null)
        {
            player.GetComponent<BombController>().numberOfBombsTotal += 1;
        }

        if (player && player.GetComponent<Bomb2Controller>() != null)
        {
            player.GetComponent<Bomb2Controller>().numberOfBombsTotal += 1;
        }
        gameObject.SetActive(false);

        yield return new WaitForSeconds(0.05f);
        Debug.Log("Hello");


        yield return new WaitForSeconds(1f);

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        Destroy(gameObject);

        yield return new WaitForSeconds(1f);

        Destroy(sound);


    }

    GameObject SpawinExplosion(Vector3 direction, List<GameObject> gos)
    {
        var position = transform.position;

        RaycastHit hit;
        int layerMask = 1 << LayerMask.NameToLayer("Default"); // Correctly create a layer mask
        Physics.Raycast(transform.position, direction, out hit, maxDistance, layerMask);

        float count = 0;

        if (hit.collider == null)
        {
            count = maxDistance;
        }
        else if ((hit.collider.CompareTag("Destructible")))
        {
            var hitPosition = hit.collider.gameObject.transform.position;
            var diff = hitPosition - position;
            var diffVector = Vector3.Scale(diff, direction);
            // Debug.Log(diffVector.magnitude);
            count = Mathf.Round(diffVector.magnitude);
        }
        else if (hit.collider.CompareTag("Indistructible"))
        {
            var hitPosition = hit.collider.gameObject.transform.position;
            var diff = hitPosition - position;
            var diffVector = Vector3.Scale(diff, direction);
            // Debug.Log(diffVector.magnitude);
            count = Mathf.Round(diffVector.magnitude) - 1;
        }
        else if (hit.collider.CompareTag("Player")) {
            Debug.Log("Bitchs dead!!!");

            var hitPosition = hit.collider.gameObject.transform.position;
            var diff = hitPosition - position;
            var diffVector = Vector3.Scale(diff, direction);
            // Debug.Log(diffVector.magnitude);
            count = Mathf.Round(diffVector.magnitude);

            return hit.collider.gameObject;

        }

        for (int i = 0; i < count; i++)
        {
            position = position + direction;
            gos.Add(Instantiate(explosionPrefab, position, Quaternion.identity));
        }

        return null;
    }
}
