using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class redEnemy : MonoBehaviour
{

    public float speed = 3;
    public float health;

    public bool down;
    public bool left;
    public bool up;
    public bool right;
    public bool dead;

    public Animator animator;
    public float detectorRange;

    public Transform[] playerDetectors;
    public RaycastHit2D[] playerHits = new RaycastHit2D[8];


    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        if (health <= 0 && !dead)
        {
            StartCoroutine(Death());
        }

        animator.SetBool("down", down);
        animator.SetBool("left", left);
        animator.SetBool("up", up);
        animator.SetBool("right", right);
        animator.SetBool("dead", dead);

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
                if (ray.collider.gameObject.CompareTag("Lucy"))
                {
                    Debug.Log("Gottem");

                    if (ray.Equals(playerHits[0]))
                    {
                        Debug.Log("Go Right");
                        transform.Translate(Vector2.right * Time.deltaTime * speed);
                        right = true;
                        left = false;
                        up = false;
                        down = false;
                    }
                    else if (ray.Equals(playerHits[1]))
                    {
                        Debug.Log("Go Left");
                        transform.Translate(Vector2.left * Time.deltaTime * speed);
                        right = false;
                        left = true;
                        up = false;
                        down = false;
                    }
                    else if (ray.Equals(playerHits[2]))
                    {
                        Debug.Log("Go Up");
                        transform.Translate(Vector2.up * Time.deltaTime * speed);
                        right = false;
                        left = false;
                        up = true;
                        down = false;
                    }
                    else if (ray.Equals(playerHits[3]))
                    {
                        Debug.Log("Go Down");
                        transform.Translate(Vector2.down * Time.deltaTime * speed);
                        right = false;
                        left = false;
                        up = false;
                        down = true;
                    }
                    else if (ray.Equals(playerHits[4]))
                    {
                        Debug.Log("Go northeast");
                        transform.Translate((Vector2.up + Vector2.right).normalized * Time.deltaTime * speed);
                        right = true;
                        left = false;
                        up = false;
                        down = false;
                    }
                    else if (ray.Equals(playerHits[5]))
                    {
                        Debug.Log("Go northwest");
                        transform.Translate((Vector2.up + Vector2.left).normalized * Time.deltaTime * speed);
                        right = false;
                        left = true;
                        up = false;
                        down = false;
                    }
                    else if (ray.Equals(playerHits[6]))
                    {
                        Debug.Log("Go southeast");
                        transform.Translate((Vector2.down + Vector2.right).normalized * Time.deltaTime * speed);
                        right = true;
                        left = false;
                        up = false;
                        down = false;
                    }
                    else if (ray.Equals(playerHits[7]))
                    {
                        Debug.Log("Go southwest");
                        transform.Translate((Vector2.down + Vector2.left).normalized * Time.deltaTime * speed);
                        right = false;
                        left = true;
                        up = false;
                        down = false;
                    }
                }
            }
        }
    }

    IEnumerator Death()
    {
        dead = true;
        yield return new WaitForSeconds(3f);
        Destroy(gameObject);
    }
}
