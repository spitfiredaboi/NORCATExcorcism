using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Dialogue/DialogueObject")]

public class DialogueObject : ScriptableObject
{
    [SerializeField] [TextArea] private string[] dialogue;
    [SerializeField] private Response[] responses;

    public string[] Dialogue => dialogue;
    
    //Changed this line so no responses exist...ever
    public bool HasResponses = false;
   // public bool HasResponses => Responses != null && Responses.Length > 0;
    public Response[] Responses => responses;
}
