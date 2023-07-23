using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator anim;
    private SpriteRenderer sr;

    private void Awake() {
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
    }

    public void walkAnimation(int walk)
    {
        anim.SetInteger(TagManager.WALK_ANIM_PARAMETER, walk);
    }

    public void jumpAnimation(bool jump)
    {
        anim.SetBool(TagManager.JUMP_ANIM_PARAMETER, jump);
    }

    public void flipPlayer(int flip)
    {
        if(flip>0)
            sr.flipX = false;
        else if(flip<0)
            sr.flipX = true;
    }
}
