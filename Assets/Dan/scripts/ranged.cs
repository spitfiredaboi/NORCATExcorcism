using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ranged : MonoBehaviour
{

    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SelfDestroy());
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }

    public IEnumerator SelfDestroy()
    {
        yield return new WaitForSeconds(3);
        Destroy(gameObject);
    }
}
