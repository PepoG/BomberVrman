using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public GameObject explosionPrefab;
    public float maxDistance = 100;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Explode());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void DestroyBlocks(Vector3 direction)
    {
        RaycastHit hit;
        int layerMask = 1 << LayerMask.NameToLayer("Default"); // Correctly create a layer mask
        Physics.Raycast(transform.position, direction, out hit, maxDistance, layerMask);


        if (hit.collider && hit.collider.CompareTag("Destructible")) {
            hit.collider.gameObject.SetActive(false);
        }
    }

    IEnumerator Explode() {
        yield return new WaitForSeconds(1);
        Instantiate(explosionPrefab, transform);
        DestroyBlocks(transform.right);
        DestroyBlocks(-transform.right);
        DestroyBlocks(-transform.forward);
        DestroyBlocks(transform.forward);
        yield return new WaitForSeconds(0.2f);
        Destroy(gameObject);
    }
}
