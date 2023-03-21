using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public float verticalInput;
    public float horizontalInput;
    public float speed = 5;
    public GameObject melee;
    public GameObject ranged;
    public GameObject rangedWeapon;
    public float meleeSpeed;
    public float rangedSpeed;
    public bool isAttacking = false;
    public bool isPlayer1 = true;

    // Start is called before the first frame update
    void Start()
    {
        if (gameObject.CompareTag("Gavin"))
        {
            isPlayer1 = false;
        }
        if (isPlayer1)
        {
            melee = gameObject.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject;
            meleeSpeed = 3;
            ranged = null;
            rangedSpeed = 0;
        }
        else if (isPlayer1!)
        {
            melee = null;
            meleeSpeed = 0;

            rangedSpeed = 1;
        }
    }
    // Update is called once per frame
    void Update()
    {

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
        if (isPlayer1)
        {
            isAttacking = true;
            melee.SetActive(true);
            yield return new WaitForSeconds(meleeSpeed);
            melee.SetActive(false);
            Debug.Log("It's workin");
            isAttacking = false;
        }
        else if (isPlayer1!)
        {
            isAttacking = true;
            Instantiate(ranged, rangedWeapon.transform.position, rangedWeapon.transform.rotation);
            yield return new WaitForSeconds(rangedSpeed);
            isAttacking = false;
        }
        
    }

}
