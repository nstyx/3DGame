using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody rb;
    public float moveSpeed = 2.5f;
    public float jumpSpeed = 3.8f;

    [SerializeField] Transform groundCheck;
    [SerializeField] LayerMask ground;

    Vector3 moveDirection;
    float turnSmooth = 15;

    public Animator anim;
    
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // movement
        //rb.velocity = new Vector3(horizontalInput * moveSpeed, rb.velocity.y, verticalInput * moveSpeed);
        Quaternion rotation = Quaternion.Euler(0, Mathf.Atan2(horizontalInput, verticalInput) * Mathf.Rad2Deg, 0);
        
        // jump
        if(Input.GetButtonDown("Jump") && IsGrounded())
        {
            rb.velocity = new Vector3(horizontalInput * moveSpeed, jumpSpeed, verticalInput * moveSpeed);
        }
        else
        {
            rb.velocity = new Vector3(horizontalInput * moveSpeed, rb.velocity.y, verticalInput * moveSpeed);
        }
        //rb.rotation = Quaternion.LookRotation(rb.velocity);
        //rb.rotation = Quaternion.LookRotation(rotation * Vector3.forward, Vector3.up); // to make the character stay vertical while jumping
        rb.rotation = Quaternion.Slerp(rb.rotation, rotation, turnSmooth * Time.deltaTime);

        anim.SetBool("isGrounded", IsGrounded());
        anim.SetFloat("speed", (Mathf.Abs(verticalInput)) + (Mathf.Abs(horizontalInput)));

                
        /*if(Input.GetKey(KeyCode.RightArrow))
        {
            Debug.Log("right");
            //anim.SetBool("isMovingRight", true);
            //anim.SetBool("IsMovingLeft", false);
        }
        else if(Input.GetKey(KeyCode.LeftArrow))
        {
            anim.SetBool("IsMovingLeft", true);
        }*/
    }
    bool IsGrounded()
    {
        return Physics.CheckSphere(groundCheck.position, .1f, ground);
    }
}
