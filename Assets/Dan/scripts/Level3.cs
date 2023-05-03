using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level3 : MonoBehaviour
{
    public GameObject player;
    public GameObject player2;
    public static float score = 0;
    public GameObject[] collectible;

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
            SceneManager.LoadScene("Level3");
        }

        if(score >= 10)
        {
            StartCoroutine(NextLevel());
        }
    }

   public IEnumerator NextLevel()
    {
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene("Level4");
    }    
}
