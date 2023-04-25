using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class doorscene : MonoBehaviour
{
    public int nextlv;
    gamemanager gm;
    [SerializeField] private int nextLevel;
    // Start is called before the first frame update
    void Start()
    {
        gm = FindObjectOfType<gamemanager>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (GetComponent<Rigidbody2D>())
        {
            gm.LoadNextLevel(nextlv);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    public void MoveToScene(int sceneID)
    {
        SceneManager.LoadScene(sceneID);
    }
    /*private void OnCollisionEnter2D(Collision2D gameObjectInformation)
    {
        
    }*/

    private void OnCollisionEnter2D(Collision2D gameObjectInformation)
    {
        Debug.Log("COLLISION");
        if (gameObjectInformation.gameObject.name == "Lucy" || gameObjectInformation.gameObject.name == "Gavin")
        {
            Debug.Log("Collision Detected");
            SceneManager.LoadScene(nextLevel);
            
        }
    }
}
