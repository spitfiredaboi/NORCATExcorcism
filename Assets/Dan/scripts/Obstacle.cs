using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Dead());
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * Time.deltaTime * 10);
    }

    IEnumerator Dead()
    {
        yield return new WaitForSeconds(10f);
        Destroy(gameObject);
    }
}
