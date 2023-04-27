using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Gameover : MonoBehaviour
{
    public TextMeshProUGUI titletext;
   /* private buttonscript button;*/
    // Start is called before the first frame update
    public void titleScreen()  {
        titletext.gameObject.SetActive(true);
    }
    void Start()
    {
      /*  button = GetComponent<buttonscript>();*/
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
