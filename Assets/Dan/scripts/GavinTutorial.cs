using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GavinTutorial : MonoBehaviour
{
    public GameObject LucyHeart0;
    public GameObject LucyHeart1;
    public GameObject LucyHeart2;
    public GameObject LucyHeart3;
    public GameObject LucyHeart4;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        LucyHeart0 = GameObject.Find("LucyHeart0");
        LucyHeart1 = GameObject.Find("LucyHeart1");
        LucyHeart2 = GameObject.Find("LucyHeart2");
        LucyHeart3 = GameObject.Find("LucyHeart3");
        LucyHeart4 = GameObject.Find("LucyHeart4");
        LucyHeart0.SetActive(false);
        LucyHeart1.SetActive(false);
        LucyHeart2.SetActive(false);
        LucyHeart3.SetActive(false);
        LucyHeart4.SetActive(false);
        player = GameObject.Find("Gavin");
    }

    // Update is called once per frame
    void Update()
    {
        if (!player.activeInHierarchy)
        {
            SceneManager.LoadScene("GavinTutorial");
        }
    }
}
