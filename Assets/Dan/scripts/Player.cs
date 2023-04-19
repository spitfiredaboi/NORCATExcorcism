using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class Player : MonoBehaviour
{
    public float speed = 5;
    private Vector2 playerVelocity;
    private Vector2 movementInput = Vector2.zero;
    public int health = 5;
    public bool iFrames = false;

    //controller
    private CharacterController controller;

    //weapon variables
    public GameObject melee;
    public GameObject meleeSlot;
    public float meleeSpeed;
    public bool isAttacking = false;
    public bool AttackDelay = false;

    //components
    public Animator animator;
    public Rigidbody2D rb;

    //animation
    public bool down;
    public bool up;
    public bool left;
    public bool right;

    // Start is called before the first frame update
    void Start()
    {
        //melee
            meleeSlot = gameObject.transform.GetChild(0).gameObject;
            melee = meleeSlot.transform.GetChild(0).gameObject;
            meleeSpeed = 0.5f;

        //components
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        
        movementInput = context.ReadValue<Vector2>();
    }
    
    public void OnAttack(InputAction.CallbackContext context)
    {
        if (!AttackDelay)
        {
            Debug.Log("Attack");
            StartCoroutine(Attacking());
        }
    }

    // Update is called once per frame
    void Update()
    {
        //movement
        Vector2 move = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        gameObject.transform.Translate(movementInput * Time.deltaTime * speed);
        

        //movement detection
        //detect horizontal movement
        if (Mathf.Abs(movementInput.x) > Mathf.Abs(movementInput.y))
        {
            //detect if moving right
            if (movementInput.x> 0)
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
        else if (Mathf.Abs(movementInput.y) > Mathf.Abs(movementInput.x))
        {
            //detect if moving up
            if (movementInput.y > 0)
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
        if (movementInput.x == 0 && movementInput.y == 0)
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
        animator.SetBool("isAttacking", isAttacking);

        //attack in the right direction
        if (meleeSlot != null)
        {
            if ((movementInput.y == 0 && movementInput.x == 0) || down)
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

    IEnumerator Attacking()
    {     
            isAttacking = true;
            AttackDelay = true;
            melee.SetActive(true);
            yield return new WaitForSeconds(meleeSpeed);
            melee.SetActive(false);
            AttackDelay = false;
            isAttacking = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("I");
        if (collision.gameObject.CompareTag("LucyEnemy") && !iFrames)
        {
            health--;
            StartCoroutine(InvincibilityFrames());
        }
    }

    IEnumerator InvincibilityFrames()
    {
        iFrames = true;
        yield return new WaitForSeconds(1.5f);
        iFrames = false;
    }
}
