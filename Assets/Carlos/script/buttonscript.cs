using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttonscript : MonoBehaviour
{
    public Sprite buttonunpressed;
    public Sprite buttonpressed;
    private SpriteRenderer spriteRenderer;
    public bool ispressed = false;
    public bool canPressButton = false;
    public KeyCode interactKey = KeyCode.X;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(interactKey) && canPressButton )
        {
            Debug.Log("button was pressed");
            spriteRenderer.sprite = buttonpressed;
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
      if(collision.gameObject.CompareTag("Player"))
        {
            canPressButton = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            canPressButton = false;
        }
    }
}
