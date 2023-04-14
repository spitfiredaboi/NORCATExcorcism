using System.Collections;
using System.Collections.Generic;
using UnityEngine;

<<<<<<< Updated upstream
/************************************************************************************************
 * first you wanna load that bad boy up with with enemy sprites
 * make sure they have  the raycast script
 * 
 * 
 * 
 * 
 * 
 * ***********************************************************************************************/
=======
>>>>>>> Stashed changes
public class spawnmanager : MonoBehaviour
{
    public GameObject[] enemyPrefabs;
    public Transform[] spawnpoints;
    public int enemyindex;
    public float spawnTime = 5f;
    public float spawnDelay = 3f;
    // Start is called before the first frame update
    void Start()
    {
        //4.) InvokeRepeating to keep spawning
        InvokeRepeating("SpawnEnemy", spawnDelay, spawnTime);
    }
    // Update is called once per frame
    void Update()
    {
      
    }
    public void SpawnEnemy()
    {
        int enemyindex = Random.Range(0, enemyPrefabs.Length);
        //1.) Pick a random enemy
        
        //2.) Pick a random spawn point
<<<<<<< Updated upstream
        int spawnpoint = Random.Range(0, spawnpoints.Length);
=======

        int spawnpoint = Random.Range(0, spawnpoints.Length);

>>>>>>> Stashed changes
        //3.) Spawn that enemy at that spawn point

        Instantiate(enemyPrefabs[enemyindex], spawnpoints[spawnpoint].position, spawnpoints[spawnpoint].rotation);
    }
}


