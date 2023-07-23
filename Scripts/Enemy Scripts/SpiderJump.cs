using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderJump : MonoBehaviour
{
    private SpriteRenderer sr;
    private Rigidbody2D myBody;
    private Animator anim;


    [SerializeField]
    private float  minJumpForce=3f, maxJumpForce=6f, minWaitTime=2.5f, maxWaitTime=1f, waitTime;

    [SerializeField]
    private Transform jumperGroundPosition, playAudioPosition, player;

    [SerializeField]
    private LayerMask groundLayer;
    
    private void Awake() {
        sr = GetComponent<SpriteRenderer>();
        myBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void Start() {
        waitTime = Time.time + Random.Range(minWaitTime, maxWaitTime);
    }

    private void Update() {
        if(Time.time > waitTime && isGrounded())
        {
            waitTime = Time.time + Random.Range(minWaitTime, maxWaitTime);
            handleSpiderJump();
        }
        animateSpiderJumper();

        playJumperAudio();
    }

    void playJumperAudio()
    {
        if(player)
        {
            if(player.position == playAudioPosition.position)
                AudioController.instance.Play_SpiderJumperSound();
        }
        
    }

    bool isGrounded()
    {
        return Physics2D.Raycast(jumperGroundPosition.position, Vector2.down, 0.1f, groundLayer);
    }

    void handleSpiderJump()
    {
        myBody.velocity = new Vector2(myBody.velocity.x, Random.Range(minJumpForce, maxJumpForce));

    }

    void animateSpiderJumper()
    {
        if(isGrounded())
        {
            anim.SetBool(TagManager.SPIDER_JUMP_PARAMETER, false);
        }
        else
        {
            anim.SetBool(TagManager.SPIDER_JUMP_PARAMETER, true);
        }
    }
}
