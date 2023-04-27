using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class ranged : MonoBehaviour
{
    public GameObject player;
    public float speed;
    public Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SelfDestroy());
        gameObject.transform.parent = null;

        if (gameObject.CompareTag("GavinEnemy"))
            {
            player = GameObject.Find("Gavin");
        }
        if (gameObject.CompareTag("LucyEnemy"))
        {
            player = GameObject.Find("Lucy");  
        }

        if(player != null)
        {
            Vector3 direction = player.transform.position - transform.position;
            float rotation = Mathf.Atan2(-direction.y, -direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, 0, rotation);
            rb = GetComponent<Rigidbody2D>();
            rb.velocity = new Vector2(direction.x, direction.y).normalized * speed;
        }


        //Quaternion.RotateTowards(transform.rotation,)

    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.CompareTag("GavinWeapon"))
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
        }
    }

    public IEnumerator SelfDestroy()
    {
        yield return new WaitForSeconds(1.5f);
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Lucy"))
        {
            Destroy(gameObject);
        }
    }
}
