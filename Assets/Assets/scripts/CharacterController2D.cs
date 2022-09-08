using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController2D : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed;
    public float smooth;
    Rigidbody2D rb2d;
    bool facingRight = true;
    private int x;
    public float jumpForce = 10f;
    bool grounded;
    public Collider2D groundCheck;
    public LayerMask groundLayer;
    Animator animator;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();

        animator = GetComponent<Animator>();

    }

     void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Someone pressed space");

            rb2d.AddForce(new Vector2(0f, jumpForce));
        }
        // Is the player touching the ground ?
        grounded = groundCheck.IsTouchingLayers(groundLayer);

        // Only jump if the player is grounded and has pressed the Space bar

        if (Input.GetKeyDown(KeyCode.Space) && grounded)
            rb2d.AddForce(new Vector2(0f, jumpForce));


        grounded = groundCheck.IsTouchingLayers(groundLayer);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "star")
        {
            Destroy(collision.gameObject);
            gameObject.tag = "Powerup";
            gameObject.GetComponent<Renderer>().material.color = Color.green;
            StartCoroutine("reset");
        }
    }
    IEnumerator reset()
    {
        yield return new WaitForSeconds(5f);
        gameObject.tag = "Player";
        gameObject.GetComponent<Renderer>().material.color = Color.white;
    }

    

    void FixedUpdate()
    {
        float x = Input.GetAxisRaw("Horizontal");


        Vector2 targetvelocity = new Vector2(x * speed, rb2d.velocity.y);
        

        rb2d.velocity = targetvelocity;
        animator.SetBool("jumping", !grounded); // the ! sign means that the output will be opposite
        animator.SetBool("running", x != 0);


        //if the input is moving the player right and the player is facing left...
        if (x > 0 && !facingRight)
        {
            // ... flip the player.
            Flip();
        }
        // Otherwise if the input is moving the player left and the player is facing right...
        else if (x < 0 && facingRight)
        {
            // ... flip the player.
            Flip();


        }
        

        void Flip()
        {
            //Invert the facingRight variable
            facingRight = !facingRight;

            //Flip the Character
            Vector2 scale = transform.localScale;

            scale.x *= -1;


            transform.localScale = scale;
            //if the input is moving the player right and the player is facing left...
            if (x > 0 && !facingRight)
            {
                // ... flip the player.
                Flip();
            }
            // Otherwise if the input is moving the player left and the player is facing right...
            else if (x < 0 && facingRight)
            {
                // ... flip the player.
                Flip();
            }
            
        }
        

}
   


    
     

}
