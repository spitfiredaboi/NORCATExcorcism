using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LucyWalk : MonoBehaviour
{
    public Animator animator;
    public Player playerScript;
    public Rigidbody2D rb;
    public bool down;
    public bool up;
    public bool left;
    public bool right;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        playerScript = GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
      
        if(Mathf.Abs(playerScript.horizontalInput) > Mathf.Abs(playerScript.verticalInput))
        {
            if (playerScript.horizontalInput > 0)
            {
                right = true;
                left = false;
                up = false;
                down = false;
            }
            else
            {
                right = false;
                left = true;
                up = false;
                down = false;
            }
        }
        else if(Mathf.Abs(playerScript.verticalInput) > Mathf.Abs(playerScript.horizontalInput))
        {
            if (playerScript.verticalInput > 0)
            {
                right = false;
                left = false;
                up = true;
                down = false;
            }
            else
            {
                right = false;
                left = false;
                up = false;
                down = true;
            }
        }
        if(playerScript.horizontalInput == 0 && playerScript.verticalInput == 0)
        {
            right = false;
            left = false;
            up = false;
            down = false;
        }


        animator.SetBool("isWalkingDown", down);
        animator.SetBool("isWalkingLeft", left);
        animator.SetBool("isWalkingRight", right);
        animator.SetBool("isWalkingUp", up);
    }
}
