using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class crate1 : MonoBehaviour
{
    public Sprite uncrated;
    public Sprite crated;
    private SpriteRenderer SpriteRenderer;
    public bool ispressed = false;
    public bool pressured = false;
    public KeyCode interactKey = KeyCode.X;

    // Start is called before the first frame update
    void Start()
    {
        SpriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if (Input.GetKeyDown(interactKey) && pressured)
        {
            Debug.Log("button was pressed");
            SpriteRenderer.sprite = crated;
        }
        */

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("crate"))
        {
            pressured = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("crate"))
        {
            pressured = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("crate"))
        {
            pressured = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("crate"))
        {
            pressured = false;
        }

    }

}
