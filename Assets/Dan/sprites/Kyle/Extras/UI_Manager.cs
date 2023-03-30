using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Rendering;

public class UI_Manager : MonoBehaviour     //put this on empty object
{
    public KeyCode pauseMenu; //controls
    public KeyCode Map;
    public bool pause; //pause bool
    public bool map; //map bool
    public GameObject bigmap; //map 
    public GameObject pauseScreen; //pause screen
    
    // Start is called before the first frame update
    void Start()
    {
        pause = false; 
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(pauseMenu) && pause == false) //press 'pause' key detect
        {
            Debug.Log("Pause");
            pauseScreen.GetComponent<Canvas>().enabled = true;           //enabled
            pause = true;
        }
        else if (Input.GetKeyDown(pauseMenu) && pause == true) //press again to close
        {
            Debug.Log("Unpause");
            pauseScreen.GetComponent<Canvas>().enabled = false;         //disabled
            pause = false;

        }
        

        if (Input.GetKeyDown(Map) && map == false) //press 'map' key detect
        {
            bigmap.GetComponent<Canvas>().enabled = true; //enabled
            map = true;
        }
        else if (Input.GetKeyDown(Map) && map == true) //press again to close
        {
            bigmap.GetComponent<Canvas>().enabled = false; //disabled
            map = false;
        }
        if(pause == true)
        {
            Time.timeScale = 0; //pause
        }
        if(pause == false)
        {
            Time.timeScale = 1; //unPause
        }
    }
}
