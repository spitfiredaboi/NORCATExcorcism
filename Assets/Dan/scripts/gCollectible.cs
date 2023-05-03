using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gCollectible : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Gavin"))
        {
            Level3.score++;
            Destroy(gameObject);
        }
    }
}
