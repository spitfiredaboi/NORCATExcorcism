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
    public Rigidbody2D rb;
    public GameObject player;
    public Vector2 location;
    public Vector2 lucyLocation;
    public Vector2 distance;

    public Transform[] playerDetectors;
    public RaycastHit2D[] playerHits = new RaycastHit2D[8];


    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.Find("Lucy");
    }

    // Update is called once per frame
    void Update()
    {
        lucyLocation = new Vector2(player.transform.position.x, player.transform.position.y);
        location = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y);

        if ((health <= 0 && !dead) || !player.activeInHierarchy)
        {
            StartCoroutine(Death());
        }

        distance = lucyLocation - location;
  
        if (Mathf.Abs(distance.x) > Mathf.Abs(distance.y))
        {
            if (distance.x > 0)
            {
                right = true;
                left = false;
                down = false;
                up = false;
            }
            else if (distance.x < 0)
            {
                right = false;
                left = true;
                down = false;
                up = false;
            }
        }
        else if (Mathf.Abs(distance.y) > Mathf.Abs(distance.x))
                {
            if(distance.y > 0)
            {
                right = false;
                    left = false;
                    down = false;
                up = true;
            }
            else if (distance.y < 0)
            {
                right = false;
                left = false;
                down = true;
                up = false;
            }
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
            if (ray.collider != null && !dead)
            {
                if (ray.collider.gameObject.CompareTag("Lucy"))
                {

                    if (ray.Equals(playerHits[0]))
                    {
                        transform.Translate(Vector2.right * Time.deltaTime * speed);
                    }
                    else if (ray.Equals(playerHits[1]))
                    {
                        transform.Translate(Vector2.left * Time.deltaTime * speed);
                    }
                    else if (ray.Equals(playerHits[2]))
                    {
                        transform.Translate(Vector2.up * Time.deltaTime * speed);
                    }
                    else if (ray.Equals(playerHits[3]))
                    {
                        transform.Translate(Vector2.down * Time.deltaTime * speed);
                    }
                    else if (ray.Equals(playerHits[4]))
                    {
                        transform.Translate((Vector2.up + Vector2.right).normalized * Time.deltaTime * speed);
                    }
                    else if (ray.Equals(playerHits[5]))
                    {
                        transform.Translate((Vector2.up + Vector2.left).normalized * Time.deltaTime * speed);
                    }
                    else if (ray.Equals(playerHits[6]))
                    {
                        transform.Translate((Vector2.down + Vector2.right).normalized * Time.deltaTime * speed);
                    }
                    else if (ray.Equals(playerHits[7]))
                    {
                        transform.Translate((Vector2.down + Vector2.left).normalized * Time.deltaTime * speed);
                    }
                }
            }
        }
    }

    IEnumerator Death()
    {
        gameObject.GetComponent<CapsuleCollider2D>().enabled = false;
        dead = true;
        yield return new WaitForSeconds(2f);
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("LucyWeapon"))
        {
            health--;
        }
    }
}
