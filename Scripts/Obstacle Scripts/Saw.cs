using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saw : MonoBehaviour
{
    [SerializeField]
    private Transform movePoint1, movePoint2;   //the transorm property of the two positions

    [SerializeField]
    float moveSpeed=5f, rotationSpeed=180f;

    [SerializeField]
    private bool randomizeMovement;

    private Transform targetPosition;   //this could be either movepoint1 or movepoint2

    private float zAngle;   //angle for rotation

    private void Awake() {
        if(randomizeMovement)
        {
            if(Random.Range(0, 2) > 0)  //randomizing whether the saw should move first to the left ro right(returns either 0 or 1)
            {
                targetPosition = movePoint1;
                rotationSpeed *= -1;    //default roation is to left. therefore we reverse it to right side if the object is moving to the right side
            }
            else
            {
                targetPosition = movePoint2;

            }
        }
        else
        {
            targetPosition = movePoint2;
        } 
    }
    
    private void Update() {
            moveSaw();
            animateSaw();
    }

    void moveSaw()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPosition.position, moveSpeed * Time.deltaTime);  // move FROM transform.position TO targetPosition.position WITH A SPEED OF moveSpeed * Time.deltaTime
        
        if(Vector3.Distance(transform.position, targetPosition.position)<0.1f) // as the saw approaches the movePoint, the distane between them decreases. So when the saw is VERY near to the movePoint, it changes direction
        {
            if(targetPosition == movePoint1)
            {   
                targetPosition = movePoint2;
                rotationSpeed *= -1; //we reverse the direction of rotation of the saw
                
            }

            else
            {
                targetPosition = movePoint1;
                rotationSpeed *= -1;    //we continously reverse the direction of roation of the saw in an alternationg manner
            }
        }
    }

    void animateSaw()
    {
        zAngle += rotationSpeed * Time.deltaTime; 
        transform.rotation = Quaternion.Euler(0f, 0f, zAngle);  //Quaternion is used to rotate the the Saw
    }
}
