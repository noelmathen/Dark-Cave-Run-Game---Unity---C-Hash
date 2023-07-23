using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HangingSpikes : MonoBehaviour
{
    private Vector3 tempPos;

    private Rigidbody2D myBody;

    [SerializeField]
    private LayerMask playerLayer;


    private void Awake() {
        myBody = GetComponent<Rigidbody2D>();
        myBody.gravityScale = 0f;
    }

    private void Update() {
        SpikeFall();
    }

    private void OnDisable() {
        CancelInvoke("deactivateObject");
    }

    bool isPlayerBelow()
    {
        return Physics2D.Raycast(transform.position, Vector2.down, 50f, playerLayer);
    }

    void deactivateObject()
    {
        gameObject.SetActive(false);
    }

    void SpikeFall()
    {
        if(isPlayerBelow())
        {
            myBody.gravityScale = 1f;
            Invoke("deactivateObject", 3f);
        }

    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag(TagManager.PLAYER_TAG))
        {
            gameObject.SetActive(false);
        }
    }
}
