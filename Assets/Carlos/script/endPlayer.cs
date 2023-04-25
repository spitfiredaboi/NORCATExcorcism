using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class endPlayer : MonoBehaviour
{
    [SerializeField] private int sceneID;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void MoveToScene(int sceneID)
    {
        SceneManager.LoadScene(sceneID);
    }
    // Update is called once per frame
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "cry")
        {
            Destroy(gameObject);
            SceneManager.LoadScene(sceneID);
            
        }
    }



}
