using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPhysical : MonoBehaviour
{
    public float speed = 2;
    public float detectorRange;

    public Transform[] playerDetectors;
    public RaycastHit2D[] playerHits = new RaycastHit2D[8];
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        playerHits[0] = Physics2D.Raycast(playerDetectors[0].position, Vector2.right, detectorRange);
        playerHits[1] = Physics2D.Raycast(playerDetectors[1].position, Vector2.left, detectorRange);
        playerHits[2] = Physics2D.Raycast(playerDetectors[2].position, Vector2.up, detectorRange);
        playerHits[3] = Physics2D.Raycast(playerDetectors[3].position, Vector2.down, detectorRange);

        playerHits[4] = Physics2D.Raycast(playerDetectors[4].position, (Vector2.up + Vector2.right), detectorRange);
        playerHits[5] = Physics2D.Raycast(playerDetectors[5].position, (Vector2.up + Vector2.left), detectorRange);
        playerHits[6] = Physics2D.Raycast(playerDetectors[6].position, (Vector2.down + Vector2.right), detectorRange);
        playerHits[7] = Physics2D.Raycast(playerDetectors[7].position, (Vector2.down + Vector2.left), detectorRange);


        foreach (RaycastHit2D ray in playerHits)
        {
            if (ray.collider != null)
            {
                if (ray.collider.gameObject.CompareTag("Player"))
                {
                    Debug.Log("Gottem");

                    if (ray.Equals(playerHits[0]))
                    {
                        Debug.Log("Go Right");
                        transform.Translate(Vector2.right * Time.deltaTime * speed);
                    }
                    else if (ray.Equals(playerHits[1]))
                    {
                        Debug.Log("Go Left");
                        transform.Translate(Vector2.left * Time.deltaTime * speed);
                    }
                    else if (ray.Equals(playerHits[2]))
                    {
                        Debug.Log("Go Up");
                        transform.Translate(Vector2.up * Time.deltaTime * speed);
                    }
                    else if (ray.Equals(playerHits[3]))
                    {
                        Debug.Log("Go Down");
                        transform.Translate(Vector2.down * Time.deltaTime * speed);
                    }
                    else if (ray.Equals(playerHits[4]))
                    {
                        Debug.Log("Go northeast");
                        transform.Translate((Vector2.up + Vector2.right).normalized * Time.deltaTime * speed);
                    }
                    else if (ray.Equals(playerHits[5]))
                    {
                        Debug.Log("Go northwest");
                        transform.Translate((Vector2.up + Vector2.left).normalized * Time.deltaTime * speed);
                    }
                    else if (ray.Equals(playerHits[6]))
                    {
                        Debug.Log("Go southeast");
                        transform.Translate((Vector2.down + Vector2.right).normalized * Time.deltaTime * speed);
                    }
                    else if (ray.Equals(playerHits[7]))
                    {
                        Debug.Log("Go southwest");
                        transform.Translate((Vector2.down + Vector2.left).normalized * Time.deltaTime * speed);
                    }
                }

                /*
                RaycastHit2D playerRay = Physics2D.Raycast(playerDetector.position, Vector2.right, detectorRange);
                RaycastHit2D playerRay = Physics2D.Raycast(playerDetector.position, Vector2.down, detectorRange);
                RaycastHit2D playerRay = Physics2D.Raycast(playerDetector.position, Vector2.left, detectorRange);
                RaycastHit2D playerRay = Physics2D.Raycast(playerDetector.position, Vector2.up, detectorRange);

                Debug.Log("You've been struck by a smooth " + playerRay.collider.gameObject.name);


                if (playerRay.collider.gameObject.CompareTag("Player"))
                {
                    Debug.Log("i am touching: " + playerRay.collider.gameObject.name);
                    transform.Translate(Vector2.right * Time.deltaTime * speed);
                }

                */

            }
        }
    }
}