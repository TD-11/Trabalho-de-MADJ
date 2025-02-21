using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scripts : MonoBehaviour
{
   private Rigidbody2D rig;

   public float velocity;
   public float forceJump;
   private bool jumping;
    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
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
            Debug.Log("Ataque");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            jumping = false;
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
        }
    }
}
