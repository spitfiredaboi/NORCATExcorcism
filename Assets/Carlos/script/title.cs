using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class title : MonoBehaviour
{
    public TextMeshProUGUI titletext;
    // Start is called before the first frame update
    void Start()
    {
        titletext.gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
