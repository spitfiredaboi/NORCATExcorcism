using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class interactable1 : MonoBehaviour
{
    public Sprite buttonunpressed;
    public Sprite switchflipped;
    private SpriteRenderer SpriteRenderer;
    public bool ispressed = false;
    public bool canFlipSwitch = false;
    public KeyCode interactKey = KeyCode.X;

    // Start is called before the first frame update
    void Start()
    {
        SpriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(interactKey) && canFlipSwitch )
        {
            Debug.Log("button was pressed");
            SpriteRenderer.sprite = switchfliped;
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
      if(collision.gameObject.CompareTag("Player"))
        {
            canFlipSwitch = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            canFlipSwitch = false;
        }
    }
}
