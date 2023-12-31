using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class Bomb2Controller : MonoBehaviour
{
    public GameObject bombPrefab;
    public InputActionProperty placeBomb;
    public int explozionSize;
    public int numberOfBombsTotal;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (placeBomb.action.WasPressedThisFrame())
        {
            if (numberOfBombsTotal != 0)
            {
                PlaceBomb();
                numberOfBombsTotal -= 1;
            }
        }
    }

    private void PlaceBomb()
    {
            Debug.Log("Planting bomb");
            var bombInstance = Instantiate(bombPrefab, new Vector3(Mathf.Round(transform.position.x), Mathf.Round(transform.position.y), Mathf.Round(transform.position.z)), Quaternion.identity);
            bombInstance.GetComponent<Explosion>().maxDistance = explozionSize;
            bombInstance.GetComponent<Explosion>().player = gameObject;
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Bomb"))
        {
            other.isTrigger = false;
        }
    }
}
