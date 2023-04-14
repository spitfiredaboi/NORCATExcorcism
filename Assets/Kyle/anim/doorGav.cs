using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorGav : MonoBehaviour
{

    public Sprite doorOpen1;
    public Sprite doorClosed1;
    public bool isUnlocked1 = true;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = doorClosed1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Gavin"))
        {
           StartCoroutine(DoorOpen1());
        }
    }
    public IEnumerator DoorOpen1()
    {
        if (isUnlocked1)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = doorOpen1;
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
            transform.Translate(Vector2.left * 0.5f);
            yield return new WaitForSeconds(1);
            gameObject.GetComponent<SpriteRenderer>().sprite = doorClosed1;
            gameObject.GetComponent<BoxCollider2D>().enabled = true;
            transform.Translate(Vector2.right * 0.5f);
        }
    }
}
