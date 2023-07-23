using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderWalk : MonoBehaviour
{
    [SerializeField]
    private Transform groundPosition;

    private SpriteRenderer sr;

    [SerializeField]
    private LayerMask groundLayer;

    [SerializeField]
    private float spiderMoveSpeed = 5f;

    private RaycastHit2D groundCollision;

    private bool moveLeft;

    private Vector2 tempPos;
    private Vector3 tempScale;
    private float scaleX;

    [SerializeField]
    private float totalWalkDistance = 5f;
    private float minDistance, maxDistance;

    [SerializeField]
    private bool randomizeMovement, moveToLeft, moveToRight;

    [SerializeField]
    private bool UseGroundCheckMethod;


    private void Awake() {        
        if(randomizeMovement)
        {
            if(Random.Range(0, 2) > 0)
            {
                moveLeft = false;
            }
            else
            {
                moveLeft = true;
            }
        }
        else if(moveToLeft)
        {
            moveLeft = true;
        }
        else if(moveToRight)
        {
            moveLeft = false;
        }
        else
        {
            moveLeft = false;//setting the initial direction of the spider to the right side
        }
        groundPosition = transform.GetChild(0);// this can be used instead of groundPosition = GetComponent<Transform>() to initialize the variable;
        scaleX = transform.localScale.x;    //copying the current scale (x) value of the spider to the scaleX variable1
        sr = GetComponent<SpriteRenderer>();
        minDistance = transform.position.x - totalWalkDistance;
        maxDistance = transform.position.x + totalWalkDistance;
    }

    private void Update() {
        if(UseGroundCheckMethod)
        {
            SpiderWalkUsingGroundCheck();
            detectGroundCollision();
        }
        else
            SpiderWalkUsingLeftandRightPosition();  //another method
    }

    void detectGroundCollision()
    {
        groundCollision = Physics2D.Raycast(groundPosition.position, Vector2.down, 0.1f, groundLayer);
        Debug.DrawRay(groundPosition.position, Vector3.down * 0.1f, Color.white);

        if(!groundCollision)
            moveLeft = !moveLeft;
    }

    void SpiderWalkUsingGroundCheck()
    {
        tempPos = transform.position;
        tempScale = transform.localScale;

        if(moveLeft)
        {
            tempPos.x -= spiderMoveSpeed * Time.deltaTime;
            tempScale.x = -scaleX;
        }
        else
        {
            tempPos.x += spiderMoveSpeed * Time.deltaTime;
            tempScale.x = scaleX;

        }

        transform.position = tempPos;
        transform.localScale = tempScale;
    }

    void SpiderWalkUsingLeftandRightPosition()
    {
        tempPos = transform.position;

        if(moveLeft)
        {
            tempPos.x -= spiderMoveSpeed * Time.deltaTime;
        }
        else
        {
            tempPos.x += spiderMoveSpeed * Time.deltaTime;
        }
        sr.flipX = moveLeft;

        if(tempPos.x < minDistance)
            moveLeft = false;
        if(tempPos.x > maxDistance)
            moveLeft = true;

        transform.position = tempPos;
    }
}

