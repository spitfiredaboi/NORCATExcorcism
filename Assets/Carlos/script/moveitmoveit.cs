using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class moveitmoveit : MonoBehaviour
{
    public float HorizontalInput;
    public float VerticalInput;
    public float Speed = 10.0f;
    public void Start()
    {
        
    }
     public void Update()
    {
        HorizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * HorizontalInput * Time.deltaTime * Speed);
        VerticalInput = Input.GetAxis("Vertical");
        transform.Translate(Vector3.up * VerticalInput * Time.deltaTime * Speed);
    }
}
