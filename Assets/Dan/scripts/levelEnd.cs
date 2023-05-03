using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class levelEnd : MonoBehaviour
{
    public string scene;

    // Start is called before the first frame update
    void Start()
    {
        scene = SceneManager.GetActiveScene().name;
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Lucy") && scene == "LucyTutorial")
        {
            SceneManager.LoadScene("GavinTutorial");
        }
        if (collision.gameObject.CompareTag("Gavin") && scene == "GavinTutorial")
        {
            SceneManager.LoadScene("BossFight");
        }
    }
}
