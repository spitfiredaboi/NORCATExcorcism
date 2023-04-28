using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class andscene : MonoBehaviour
{
    public int nextSceneNumber;
   public void MoveToScene(int sceneID)
    {
        SceneManager.LoadScene(sceneID);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Lucy") || collision.gameObject.CompareTag("Gavin"))
        {
            MoveToScene(nextSceneNumber);
        }
    }


}
