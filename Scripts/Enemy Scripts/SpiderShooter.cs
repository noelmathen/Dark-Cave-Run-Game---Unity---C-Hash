using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderShooter : MonoBehaviour
{
    [SerializeField]
    private GameObject spiderShooterBullet; //The game object of the bullet image

    [SerializeField]
    private Transform bulletSpawnPosition;  //position of the bullet spwaner

    [SerializeField]
    private float minWaitingTime=1f, maxWaitingTime=3f;

    private float spawnTime;

    private void Start() {
        spawnTime = Time.time + Random.Range(minWaitingTime, maxWaitingTime);   //Time.time is the time elapsed from the staring of the game. this is used to instantiate the bullet.
        // Invoke("Shoot", Random.Range(minWaitingTime, maxWaitingTime)); //Anoher method for times instantiation of the bullet using the Invoke method. It will be also called at the end of the Shoot() function.
    }

    private void Update() {
        if(Time.time > spawnTime)   //spawntime gets updated randomly in every frame and will become greater than Time.time for some time. Thus, the time taken for Time.time to become greater than the spawnTime is the actual time delay/lag we see in the bullet spawning. 
        {
            spawnTime = Time.time + Random.Range(minWaitingTime, maxWaitingTime);
            Shoot();
        }
    }

    void Shoot()
    {
        Instantiate(spiderShooterBullet, bulletSpawnPosition.position, Quaternion.identity);    //Quaternion.Identity - I think its a rotation parameter which is used to specify the object is not rotated.
        // Invoke("Shoot", Random.Range(minWaitingTime, maxWaitingTime));
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag(TagManager.PLAYER_TAG))
        {
            spiderShooterBullet.SetActive(false);
        }
    }
}
