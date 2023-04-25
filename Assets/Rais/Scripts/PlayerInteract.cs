using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    [SerializeField] private DialogueUi dialogue;
    private bool CanReadSign = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P) && CanReadSign)
        {
            dialogue.ActivateDialogue();
        }

    }
        private void OnTriggerEnter2D(Collider2D other)
        {
        if(other.gameObject.CompareTag("Lucy")||other.gameObject.CompareTag("Gavin"))
        {
            CanReadSign = true;

        }
        }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Lucy") || other.gameObject.CompareTag("Gavin"))
        {
            CanReadSign = false;

        }

    }

}
