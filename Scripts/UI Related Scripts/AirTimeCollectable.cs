using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirTimeCollectable : MonoBehaviour
{
    [SerializeField]
    private bool IsAirCollectable;

    [SerializeField]
    private float increaseValue = 15f;

    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.CompareTag(TagManager.PLAYER_TAG))
        {
            if(IsAirCollectable)
            {   
                GameplayController.instance.IncreaseAirValue(increaseValue);

            }
            else
            {
                GameplayController.instance.IncreaseTimeValue(increaseValue);
            }
            gameObject.SetActive(false);
        }
    }
}


