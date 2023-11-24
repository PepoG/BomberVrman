using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class BombController : MonoBehaviour
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
        if(placeBomb.action.triggered)
        {
            PlaceBomb();
        }
    }

    private void PlaceBomb()
    {
        Instantiate(bombPrefab,transform.position, Quaternion.identity);
    }
}
