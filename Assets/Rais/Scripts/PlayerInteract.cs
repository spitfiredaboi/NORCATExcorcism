using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    [SerializeField] private DialogueUi dialogue;
    public bool CanReadSign = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Interact") && CanReadSign)
        {
            Debug.Log("BUTTON!");
            dialogue.ActivateDialogue();
        }

    }
        private void OnTriggerEnter2D(Collider2D other)
        {
        if(other.gameObject.CompareTag("Lucy")||other.gameObject.CompareTag("Gavin"))
        {
            //other.gameObject.GetComponent<Player>()

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
