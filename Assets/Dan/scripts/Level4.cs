using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level4 : MonoBehaviour
{

    public GameObject player;
    public GameObject player2;
    public GameObject gate;
    public static float score = 0;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Lucy");
        player2 = GameObject.Find("Gavin");
    }

    // Update is called once per frame
    void Update()
    {
        if (!player.activeInHierarchy && !player2.activeInHierarchy)
        {
            score = 0;
            SceneManager.LoadScene("Level4");
        }

        if (score >= 25)
        {
            StartCoroutine(NextLevel());
        }

        if (player.transform.position.x >= 15 && player2.transform.position.x >= 15)
        {
            gate.SetActive(true);
        }
    }

    public IEnumerator NextLevel()
    {
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene("BossFight");
    }
}
