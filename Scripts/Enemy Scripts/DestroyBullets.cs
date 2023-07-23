using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBullets : MonoBehaviour
{
    // private void Start() {
    //     Invoke("DestroyBullet", 1.5f);
    // }

    private void OnEnable() {
        Invoke("DestroyBullet", 3f);    //The DestroyBullet functions is called after an interval of 3 seconds. This is kept inside OnEnable because, unlike OnEnable(),  Invoke() and Start() doesnt apply to gameobjects which are inactive. Since the bullet game objects are activated and deactivated in the hierarchy multiple times, We should compulsorily call the DestorBullets() function in OnEnable().
    }

    void DestroyBullet()
    {
        if(gameObject.activeInHierarchy)
        {
            // Destroy(gameObject);
            CancelInvoke("DestroyBullet");
            gameObject.SetActive(false);
        }
    }
}

