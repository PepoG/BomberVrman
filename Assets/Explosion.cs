using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public GameObject explosionPrefab;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Explode());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Explode() {
        yield return new WaitForSeconds(1);
        Instantiate(explosionPrefab, transform);
        yield return new WaitForSeconds(0.2f);
        Destroy(gameObject);
    }
}
