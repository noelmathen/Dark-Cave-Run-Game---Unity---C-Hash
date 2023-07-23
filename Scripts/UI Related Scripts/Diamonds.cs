using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diamonds : MonoBehaviour
{
    private void Start() {
        Door.instance.addDiamonds();
    }
 
    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.CompareTag(TagManager.PLAYER_TAG))
        {
            Door.instance.collectDiamonds();
            AudioController.instance.Play_CollectibleSound();
            GameplayController.instance.IncrementScore();   //since the player has both the capsule and box collider, a singlecollision will be considered as two collision, therefore, the score will be incremented twice. So manage that properly
            gameObject.SetActive(false);
        }
    }
}

