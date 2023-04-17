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

    //controller
    private CharacterController controller;

    //weapon variables
    public GameObject melee;
    public GameObject meleeSlot;
    public float meleeSpeed;
    public bool isAttacking = false;

    //components
    public Animator animator;
    public Rigidbody2D rb;

    //animation
    public bool down;
    public bool up;
    public bool left;
    public bool right;

    //cam fix
    public CinemachineTargetGroup cam;
    public GameObject leftCamFix;
    public GameObject rightCamFix;

    // Start is called before the first frame update
    void Start()
    {

        //components
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        controller = gameObject.GetComponent<CharacterController>();

        cam = GameObject.Find("TargetGroup1").GetComponent<CinemachineTargetGroup>();
        leftCamFix = GameObject.Find("LeftLimit");
        rightCamFix = GameObject.Find("RightLimit");
        cam.AddMember(gameObject.transform, 1f, 0f);
        cam.AddMember(leftCamFix.transform, 1f, 0f);
        cam.AddMember(rightCamFix.transform, 1f, 0f);
    }


    public void OnMove(InputAction.CallbackContext context)
    {
        movementInput = context.ReadValue<Vector2>();
        Debug.Log(movementInput);
    }

    // Update is called once per frame
    void Update()
    {
            //movement
            Vector2 move = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
            controller.Move(movementInput * Time.deltaTime * speed);


            if (Input.GetKeyDown(KeyCode.Z) && isAttacking == false)
            {
                StartCoroutine(Attack());
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