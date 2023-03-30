using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //walking variables
    public float verticalInput;
    public float horizontalInput;
    public float speed = 5;

    //weapon variables
    public GameObject melee;
    public GameObject meleeSlot;
    public GameObject ranged;
    public GameObject rangedSlot;
    public float meleeSpeed;
    public float rangedSpeed;
    public bool isAttacking = false;

    //character identity
    public bool isPlayer1 = true;

    //components
    public Animator animator;
    public Rigidbody2D rb;

    //movement detection
    public bool down;
    public bool up;
    public bool left;
    public bool right;

    // Start is called before the first frame update
    void Start()
    {
        //player identity
        if (gameObject.CompareTag("Gavin"))
        {
            isPlayer1 = false;
        }
        if (isPlayer1)
        {
            meleeSlot = gameObject.transform.GetChild(0).gameObject;
            melee = meleeSlot.transform.GetChild(0).gameObject;
            meleeSpeed = 0.5f;
            ranged = null;
            rangedSpeed = 0;
        }
        else if (isPlayer1 == false)
        {
            meleeSlot = null;
            melee = null;
            meleeSpeed = 0;
            rangedSpeed = 1;
        }

        //components
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
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

        //movement detection
        //detect horizontal movement
        if (Mathf.Abs(horizontalInput) > Mathf.Abs(verticalInput))
        {
            //detect if moving right
            if (horizontalInput > 0)
            {
                right = true;
                left = false;
                up = false;
                down = false;
            }
            //detect if moving left
            else
            {
                right = false;
                left = true;
                up = false;
                down = false;
            }
        }
        //detect vertical movement
        else if (Mathf.Abs(verticalInput) > Mathf.Abs(horizontalInput))
        {
            //detect if moving up
            if (verticalInput > 0)
            {
                right = false;
                left = false;
                up = true;
                down = false;
            }
            //detect if moving down
            else
            {
                right = false;
                left = false;
                up = false;
                down = true;
            }
        }
        if (horizontalInput == 0 && verticalInput == 0)
        {
            right = false;
            left = false;
            up = false;
            down = false;
        }

        //set bools for animator
        animator.SetBool("isWalkingDown", down);
        animator.SetBool("isWalkingLeft", left);
        animator.SetBool("isWalkingRight", right);
        animator.SetBool("isWalkingUp", up);

        //attack in the right direction
        if (meleeSlot != null)
        {
            if ((verticalInput == 0 && horizontalInput == 0) || down)
            {
                meleeSlot.transform.eulerAngles = new Vector3(0, 0, 270);
            }
            else if (right)
            {
                meleeSlot.transform.eulerAngles = new Vector3(0, 0, 0);
            }
            else if (up)
            {
                meleeSlot.transform.eulerAngles = new Vector3(0, 0, 90);
            }
            else if (left)
            {
                meleeSlot.transform.eulerAngles = new Vector3(0, 0, 180);
            }
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
        else if (isPlayer1 == false)
        {
            isAttacking = true;
            Instantiate(ranged, rangedSlot.transform.position, rangedSlot.transform.rotation);
            yield return new WaitForSeconds(rangedSpeed);
            isAttacking = false;
        }
        
    }

}
