using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Bomb2Controller : MonoBehaviour
{
    public GameObject bombPrefab;
    public InputActionProperty placeBomb;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (placeBomb.action.WasPressedThisFrame())
        {
            PlaceBomb();
        }
    }

    private void PlaceBomb()
    {
        Debug.Log("Planting bomb");
        Instantiate(bombPrefab, new Vector3(Mathf.Round(transform.position.x), Mathf.Round(transform.position.y), Mathf.Round(transform.position.z)), Quaternion.identity);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Bomb"))
        {
            other.isTrigger = false;
        }
    }
}
