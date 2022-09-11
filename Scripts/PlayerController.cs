using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // anything that's public will show up under the inspector
    public Rigidbody2D theRB;

    public float moveSpeed;
    public float jumpForce;

    //every obj has a transform
    public Transform groundPoint;
    private bool isOnGround;
    public LayerMask whatIsGround;

    public Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // input can be found under edit-project settings-input manager
        // -1 for left, 1 for right
        // GetAxis: player will move to full speed gradually
        // GetAxisRaw: full speed immediately
        theRB.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * moveSpeed, theRB.velocity.y);

        //handle direction change
        if(theRB.velocity.x < 0)
        {
            // f stands for float 
            transform.localScale = new Vector3(-1f, 1f, 1f);
        } else if(theRB.velocity.x > 0)
        {
            //Vector3.one = 1f,1f,1f
            transform.localScale = Vector3.one;
        }


        // overlapcircle function creates a circle param (location, size, layer)
        isOnGround = Physics2D.OverlapCircle(groundPoint.position, 0.2f, whatIsGround);

        // GetButton : when button is being held
        // GetButtonDown : when the button is pressed
        // GetButtonUp : when the button is released
        if (Input.GetButtonDown("Jump") && isOnGround)
        {
            theRB.velocity = new Vector2(theRB.velocity.x, jumpForce);
        }










        anim.SetBool("isOnGround", isOnGround);
        anim.SetFloat("speed", Mathf.Abs(theRB.velocity.x));
    }
}
