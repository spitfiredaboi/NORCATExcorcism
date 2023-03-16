using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnmanager : MonoBehaviour
{
    public GameObject[] enemyPrefabs;
    public Transform[] spawnpoints;
    public int enemyindex;
    // Start is called before the first frame update
    void Start()
    {
        //4.) InvokeRepeating to keep spawning
    }

    // Update is called once per frame
    void Update()
    {
      
    }
    public void Spawn()
    {
        int enemyindex = Random.Range(0, enemyPrefabs.Length);
        //1.) Pick a random enemy
        Instantiate(enemyPrefabs[enemyindex], new Vector2(0, 0), enemyPrefabs[enemyindex].transform.rotation);
        //2.) Pick a random spawn point
         enemyindex =
        //3.) Spawn that enemy at that spawn point
    }
}


