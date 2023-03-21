using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class door : MonoBehaviour
{

    public Sprite doorOpen;
    public Sprite doorClosed;
    public bool isUnlocked = true;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = doorClosed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Lucy"))
        {
           StartCoroutine(DoorOpen());
        }
    }
    public IEnumerator DoorOpen()
    {
        if (isUnlocked)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = doorOpen;
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
            transform.Translate(Vector2.left * 0.5f);
            yield return new WaitForSeconds(1);
            gameObject.GetComponent<SpriteRenderer>().sprite = doorClosed;
            gameObject.GetComponent<BoxCollider2D>().enabled = true;
            transform.Translate(Vector2.right * 0.5f);
        }
    }
}
