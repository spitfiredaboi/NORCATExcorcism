using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class gamemanager : MonoBehaviour
{
    public List<GameObject> targets;
    public bool isGameActive;
    public GameObject titleScreen;
    public TextMeshProUGUI socreText;
    private int score;
    // Start is called before the first frame update
    void Start()
    {
    
    }
    public void StartGame()
    {
        isGameActive = true;
        score = 0;
       /* /StartCoroutine(Spawntarget());
        UpdateScore(0);*/
        
    }
   /* StartGame()
    {
        titleScreen.Gameobject.setActive(false);*/
    }
    // Update is called once per frame
   /* void Update()
    {
        
    }
}*/
