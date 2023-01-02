using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MariaMovement : MonoBehaviour
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
        //while(!HealthManager.playerDied) // no input when player dies --> THIS CRASHES THE GAME
        //{
            
            float horizontalInput = Input.GetAxis("Horizontal");
            float verticalInput = Input.GetAxis("Vertical");
            
            if(HealthManager.playerDied)
            {
                horizontalInput = 0f;
                verticalInput = 0f;
            }

            // movement
            //rb.velocity = new Vector3(horizontalInput * moveSpeed, rb.velocity.y, verticalInput * moveSpeed);
            Quaternion rotation = Quaternion.Euler(0, Mathf.Atan2(horizontalInput, verticalInput) * Mathf.Rad2Deg, 0);
            
            //rb.rotation = Quaternion.LookRotation(rb.velocity);
            //rb.rotation = Quaternion.LookRotation(rotation * Vector3.forward, Vector3.up); // to make the character stay vertical while jumping
            if (horizontalInput != 0 || verticalInput != 0)
            {
                rb.rotation = Quaternion.Slerp(rb.rotation, rotation, turnSmooth * Time.deltaTime);
                rb.constraints = RigidbodyConstraints.FreezeRotationX; //stop character from
                rb.constraints = RigidbodyConstraints.FreezeRotationZ;//falling over
            }
            else
            { //not working currently, fixed spinning, but now character SLOWLY falling over, overriden by something?
                rb.constraints = RigidbodyConstraints.FreezePositionX;
                rb.constraints = RigidbodyConstraints.FreezePositionZ;
                rb.constraints = RigidbodyConstraints.FreezeRotationY; //stop character from spinning randomly when idle
                rb.constraints = RigidbodyConstraints.FreezeRotationX; //stop character from
                rb.constraints = RigidbodyConstraints.FreezeRotationZ;//falling over
            }
            
            // attack sword
            if(Input.GetButtonDown("Fire3") && IsGrounded()) // left shift
            {
                anim.SetBool("isAttacking", true);
            }
            else
            {
                anim.SetBool("isAttacking", false);
            }

            // jump
            if(Input.GetButtonDown("Jump") && IsGrounded()) // spacebar
            {
                rb.velocity = new Vector3(horizontalInput * moveSpeed, jumpSpeed, verticalInput * moveSpeed);
            }
            else
            {
                rb.velocity = new Vector3(horizontalInput * moveSpeed, rb.velocity.y, verticalInput * moveSpeed);
            }

            anim.SetBool("isGrounded", IsGrounded());
            anim.SetFloat("speed", (Mathf.Abs(verticalInput)) + (Mathf.Abs(horizontalInput)));
        //}
    }
    bool IsGrounded()
    {
        return Physics.CheckSphere(groundCheck.position, .1f, ground);
    }

    protected void LateUpdate()
    {
            rb.constraints = RigidbodyConstraints.FreezeRotationX; //stop character from
            rb.constraints = RigidbodyConstraints.FreezeRotationZ;//falling over
    }
}
