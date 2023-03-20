using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public float verticalInput;
    public float horizontalInput;
    public float speed = 5;
    public GameObject melee;
    public float meleeSpeed;
    public bool isAttacking = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        melee = gameObject.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject;

        //direction
        verticalInput = Input.GetAxis("Vertical");
        horizontalInput = Input.GetAxis("Horizontal");

        //movement
        transform.Translate(Vector3.up * verticalInput * speed * Time.deltaTime);
        transform.Translate(Vector3.right * horizontalInput * speed * Time.deltaTime);

        //Attack


        if (Input.GetKeyDown(KeyCode.Z) && isAttacking == false)
        {
           StartCoroutine(Attack());
        }
    }

    IEnumerator Attack()
    {
            isAttacking = true;
            melee.SetActive(true);
            yield return new WaitForSeconds(meleeSpeed);
            melee.SetActive(false);
            Debug.Log("It's workin");
            isAttacking = false;
    }

}
