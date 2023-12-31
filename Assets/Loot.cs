using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loot : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.GetComponent<BombController>() != null)
        {
            other.gameObject.GetComponent<BombController>().explozionSize += 1;
            Destroy(gameObject);
        }

        if (other.gameObject.GetComponent<Bomb2Controller>() != null)
        {
            other.gameObject.GetComponent<Bomb2Controller>().explozionSize += 1;
            Destroy(gameObject);
        }
    }
}
