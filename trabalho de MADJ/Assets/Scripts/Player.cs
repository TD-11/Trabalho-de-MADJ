using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scripts : MonoBehaviour
{
   private Rigidbody2D rig;
   private Animator anim;

   private float velocity = 5f;
   public float forceJump;
   private bool jumping;
   private bool attacking;
   private bool grounded;
    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
       Jump();
       Atack();
    }
    void FixedUpdate()
    {
        Move();
    }

    void Move()
        {
            Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
            transform.position += move * Time.deltaTime * velocity;
            if (Input.GetAxis("Horizontal") > 0f)
            {
                transform.eulerAngles = new Vector3(0f, 0f, 0f);
            }
            if (Input.GetAxis("Horizontal") < 0f)
            {
                transform.eulerAngles = new Vector3(0f, 180f, 0f);
            }
        }

     void Jump()
    {
        if (Input.GetButtonDown("Jump")) 
        {
            if (!jumping)
            {
                rig.velocity = Vector2.up * forceJump;
            }
         
        } 
    }

    void Atack()
    {
        if(Input.GetKeyDown(KeyCode.L))
        {
            if (!attacking)
            {
                anim.SetBool("Attacking", true);
            }
            if(!attacking && grounded == true)
            {
                velocity = 0f;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            jumping = false;
            grounded = true;
        }
        if (collision.gameObject.tag == "Danger")
        {
            Destroy(gameObject);
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            jumping = true;
            grounded = false;
        }
    }

    void EndingAnimation()
    {
        anim.SetBool("Attacking", false);
        velocity = 5f;
        attacking = false;
    }
}
