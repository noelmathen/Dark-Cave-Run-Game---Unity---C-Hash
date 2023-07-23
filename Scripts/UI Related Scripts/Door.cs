using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    private BoxCollider2D boxCol;
    private Animator anim;

    public static Door instance;

    public static int diamondCount=0;

    private void Awake() {
        boxCol = GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();

        if(instance == null)
            instance = this;
        
        diamondCount=0;
    }

    

    private void Update() {
        OpenDoor();
    }

    public void addDiamonds()
    {
        diamondCount++;
        // Debug.Log("Diamond Added! - Count = " + diamondCount);  
    }

    public void collectDiamonds()
    {
        diamondCount--;
        // Debug.Log("Diamond Collected! - Count = " + diamondCount);
    }

    void OpenDoor()
    {
        if(diamondCount == 0)
        {
            anim.Play(TagManager.DOOR_OPEN_ANIMATION);
        }
    }

    void RemoveCollider()
    {
        boxCol.enabled = false;
    }

}







