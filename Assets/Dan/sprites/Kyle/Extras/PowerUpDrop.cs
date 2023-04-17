using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpDrop : MonoBehaviour
{
    // *PUT THIS SCRIPT ON THE THING YOU WANT TO DROP A POWER UP

    // make sure to fill this array with all the power ups you wanna add
    public GameObject[] powerUps;

    // currently when the player destorys this object there is about a 15% chance for that object to drop a power up and then the power up the object drops is random
    // You can change the NumberToBeat to any number between 1 and 101
    public int numberToBeat = 84;

    private int dropChance;

    // Start is called before the first frame update
    void Start()
    {
        // this decides whether or not the object will drop a power up or not
        // Lowering the number to beat increases the chance of a power up dropping
        dropChance = Random.Range(1, 101);
        Debug.Log("the number is: " + dropChance);
    }

    public void dropAPowerUp()
    {
        if (dropChance > numberToBeat)
        {
            //power Up dropped!
            int powerUpIndex = Random.Range(0, powerUps.Length);
            Instantiate(powerUps[powerUpIndex], transform.position, transform.rotation);
            Debug.Log("power Up Dropped!");
        }
    }
}
