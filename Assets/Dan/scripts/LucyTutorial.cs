using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.SceneManagement;

public class LucyTutorial : MonoBehaviour
{

    public GameObject GavinHeart0;
    public GameObject GavinHeart1;
    public GameObject GavinHeart2;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        GavinHeart0 = GameObject.Find("GavinHeart0");
        GavinHeart1 = GameObject.Find("GavinHeart1");
        GavinHeart2 = GameObject.Find("GavinHeart2");
        GavinHeart0.SetActive(false);
        GavinHeart1.SetActive(false);
        GavinHeart2.SetActive(false);
        player = GameObject.Find("Lucy");
    }

    // Update is called once per frame
    void Update()
    {
        if(!player.activeInHierarchy)
        {
            SceneManager.LoadScene("LucyTutorial");
        }
    }
}
