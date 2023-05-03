using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Cinemachine;

public class Player2 : MonoBehaviour
{
    public float speed = 5;
    private Vector2 playerVelocity;
    private Vector2 movementInput = Vector2.zero;
    private float health = 3;
    public bool iFrames = false;

    //weapon variables
    public GameObject weaponSlot;
    public GameObject weapon;
    public float weaponSpeed = 2;
    public bool isAttacking = false;
    public bool AttackDelay = false;

    //components
    public Animator animator;
    public Rigidbody2D rb;
    public DialogueUi dialogue;

    //animation
    public bool down;
    public bool up;
    public bool left;
    public bool right;
    public bool dead;
    public bool CanReadSign;

    //cam fix
    public CinemachineTargetGroup cam;
    public GameObject leftCamFix;
    public GameObject rightCamFix;
    public GameObject[] hearts;

    // Start is called before the first frame update
    void Start()
    {

        //components
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();

        cam = GameObject.Find("TargetGroup1").GetComponent<CinemachineTargetGroup>();
        leftCamFix = GameObject.Find("LeftLimit");
        rightCamFix = GameObject.Find("RightLimit");
        cam.AddMember(gameObject.transform, 1f, 0f);
        cam.AddMember(leftCamFix.transform, 1f, 0f);
        cam.AddMember(rightCamFix.transform, 1f, 0f);

        //weapon
        weaponSlot = GameObject.Find("weaponSlot");

        //hearts
        hearts[0] = GameObject.Find("GavinHeart0");
        hearts[1] = GameObject.Find("GavinHeart1");
        hearts[2] = GameObject.Find("GavinHeart2");
    }


    public void OnMove(InputAction.CallbackContext context)
    {
        movementInput = context.ReadValue<Vector2>();
        Debug.Log(movementInput);
    }

    public void OnAttack(InputAction.CallbackContext context)
    {
        if (!dead)
        {
            Debug.Log("Attack");
            isAttacking = context.action.triggered;
            StartCoroutine(Attacking());
        }
    }

    public void OnInteract(InputAction.CallbackContext context)
    {
        if (CanReadSign)
        {
            {
                dialogue.ActivateDialogue();
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector3(0, 0, 0);
        //movement
        Vector2 move = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        if (!dead)
        {
            gameObject.transform.Translate(movementInput * Time.deltaTime * speed);
        }


            if (Input.GetKeyDown(KeyCode.Z) && isAttacking == false)
            {
                StartCoroutine(Attacking());
            }


        if (health < 3)
        {
            Destroy(hearts[2]);
            if (health < 2)
            {
                Destroy(hearts[1]);
            }
            if (health < 1)
            {
                Destroy(hearts[0]);
                StartCoroutine(Death());
            }
        }
        //movement detection
        //detect horizontal movement
        if (Mathf.Abs(movementInput.x) > Mathf.Abs(movementInput.y))
            {
                //detect if moving right
                if (movementInput.x > 0)
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
            animator.SetBool("dead", dead);
        //attack in the right direction
            if (weaponSlot != null)
            {
                if ((movementInput.y == 0 && movementInput.x == 0) || down)
                {
                    weaponSlot.transform.eulerAngles = new Vector3(0, 0, 270);
                }
                else if (right)
                {
                    weaponSlot.transform.eulerAngles = new Vector3(0, 0, 0);
                }
                else if (up)
                {
                    weaponSlot.transform.eulerAngles = new Vector3(0, 0, 90);
                }
                else if (left)
                {
                    weaponSlot.transform.eulerAngles = new Vector3(0, 0, 180);
                }
            }
        }

    IEnumerator Attacking()
    {
        if (isAttacking && !AttackDelay) 
        {
            AttackDelay = true;
            Instantiate(weapon, weaponSlot.transform);
            yield return new WaitForSeconds(weaponSpeed);
            AttackDelay = false;
        }
        yield return new WaitForSeconds(0);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("GavinEnemy") && !iFrames)
        {
            health--;
            StartCoroutine(InvincibilityFrames());
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("gate"))
        {
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("Sign"))
        {
            dialogue = collision.gameObject.GetComponent<ObjectLinker>().dialogueObject.GetComponent<DialogueUi>();
            CanReadSign = true;

        }
    }


    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Sign"))
        {

            CanReadSign = false;

        }

    }
    

    IEnumerator Death()
    {
        dead = true;
        yield return new WaitForSeconds(1f);
        gameObject.SetActive(false);
    }

    IEnumerator InvincibilityFrames()
    {
        iFrames = true;
        yield return new WaitForSeconds(1.5f);
        iFrames = false;
    }
}