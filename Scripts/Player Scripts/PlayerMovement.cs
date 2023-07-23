using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float moveForce = 6f, jumpForce = 6f;

    private Rigidbody2D myBody;
    private PlayerAnimation animObject;
    
    [SerializeField]
    private Transform groundCheckPosition;

    [SerializeField]
    private LayerMask groundLayer;

    private BoxCollider2D boxCol;

    
    private void Awake() {
        myBody = GetComponent<Rigidbody2D>();
        animObject = GetComponent<PlayerAnimation>();
        boxCol = GetComponent<BoxCollider2D>();
    }

    private void Update() {
        animatePlayer();
        // movePlayerUsingTransform();//if we use Time.deltaTime, we generally call that function in the Update, not fixed update
        jumpPlayer();
    }

    private void FixedUpdate() {
        movePlayer();
    }

    // void movePlayerUsingTransform()
    // {
    //     tempPos = transform.position;
        
    //     if(Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
    //     {
    //         tempPos.x -= moveSpeed * Time.deltaTime;
    //     }
    //     if(Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
    //     {
    //         tempPos.x += moveSpeed * Time.deltaTime;
    //     }

    //     transform.position = tempPos;
    // }

    void movePlayer()
    {
        if(Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            myBody.velocity = new Vector2(-moveForce, myBody.velocity.y);
        }
        else if(Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            myBody.velocity = new Vector2(moveForce, myBody.velocity.y);
        }
        else
        {
            myBody.velocity = new Vector2(0f, myBody.velocity.y);
        }
    }

    void animatePlayer()
    {
        animObject.walkAnimation((int)Mathf.Abs(myBody.velocity.x));    //x of velocity could be + or - according to the players movement to the left or right. since walking happens only when "Walk" parameter is greater than 1, we take the absolute value so that -ve numbers willl also become positive.
        animObject.flipPlayer((int)myBody.velocity.x);  
        animObject.jumpAnimation(!isGrounded());
    }

    bool isGrounded()
    {
        // return Physics2D.Raycast(groundCheckPosition.position, Vector2.down, 0.1f, groundLayer); //RayCasting. not so efficient
        return Physics2D.BoxCast(boxCol.bounds.center, boxCol.bounds.size, 0f, Vector2.down, 0.1f, groundLayer); // this is box cast which casts a box instead of a ray. Better than raycasting for jumping purposes
    }

    void jumpPlayer()
    {
        // Debug.DrawRay(groundCheckPosition.position, Vector2.down * 0.1f , Color.red); // draws a ray from the given origin to a particularn dicetion with the specific size
        if(Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W) )
        {
            if(isGrounded())
            {
                AudioController.instance.Play_JumpSound();
                myBody.velocity = new Vector2(myBody.velocity.x, jumpForce);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.CompareTag(TagManager.ENEMY_TAG))
        {
            GameplayController.instance.GameOver(false); 
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag(TagManager.ENEMY_TAG))
        {
            GameplayController.instance.GameOver(false); 
        }
        if(other.gameObject.CompareTag(TagManager.GOAL_TAG))
        {
            GameplayController.instance.GameOver(true);
        }
    }
    
}

