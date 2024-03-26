using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroy_bola : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(KBUM());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator KBUM()
    {
        yield return new WaitForSeconds(0.3f);
        Destroy(gameObject);
    }
}
