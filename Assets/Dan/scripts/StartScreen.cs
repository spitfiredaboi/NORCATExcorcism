using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class StartScreen : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void OnInteract(InputAction.CallbackContext context)
    {
        SceneManager.LoadScene("LucyTutorial");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
