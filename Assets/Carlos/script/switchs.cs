using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class switchs : MonoBehaviour
{
    public Sprite switchunflipped;
    public Sprite switchflipped;
    private SpriteRenderer spriteRenderer;
    public bool canFlipSwitch = false;
    public KeyCode interactKey = KeyCode.X;

    public bool isSwitched = false;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(interactKey) && canFlipSwitch )
        {
            Debug.Log("switch was activated");

            if(isSwitched == true)
            {
                isSwitched = false;
                spriteRenderer.sprite = switchunflipped;
            }
            else
            {
                isSwitched = true;
                spriteRenderer.sprite = switchflipped;

            }

           
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
