using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderShooterPool : MonoBehaviour
{
    [SerializeField]
    private GameObject spiderShooterBullet; //The game object of the bullet image

    [SerializeField]
    private Transform bulletSpawnPosition;  //position of the bullet spwaner

    private List<GameObject> bullets = new List<GameObject>();  // here, we are creating a list of type 'GameObjects' to store the the bullet objects

    [SerializeField]
    private float minWaitingTime=1f, maxWaitingTime=3f;

    private float spawnTime; 

    [SerializeField]
    private float initialBullets = 10f;

    private void Awake() {
        initializeBullets();    //to initialize the bullets list
    }

    private void Start() {
        spawnTime = Time.time + Random.Range(minWaitingTime, maxWaitingTime); //Time.time is the time elapsed from the staring of the game. this is used to instantiate the bullet.
    }

    private void Update() {
        if(Time.time > spawnTime)  //spawntime gets updated randomly in every frame and will become greater than Time.time for some time. Thus, the time taken for Time.time to become greater than the spawnTime is the actual time delay/lag we see in the bullet spawning. 
        {
            spawnTime = Time.time + Random.Range(minWaitingTime, maxWaitingTime);   //updating the Time.time
            Shoot();
        }
    }

    void initializeBullets()
    {
        for(int i=0; i<initialBullets; i++) // initial number of bullets
        {
            GameObject newBullet = Instantiate(spiderShooterBullet);    //creating a new gameobject of spider bullets in a loop
            newBullet.SetActive(false); // we will instantly set the newly created bullet game object inactive in the hierarchy panel
            newBullet.transform.SetParent(transform);   // this script is attached to the SpiderShooter game object, so this LOC is to organize the newly created bullet game objects so that it is created inside the SpiderShooter gameobject.
            bullets.Add(newBullet); //the newly created bullet objects are added to the bullets list one by one
        }
    }

    void Shoot()
    {
        for(int i=0; i<bullets.Count; i++)  //count in the bullets list
        {
            if(!bullets[i].activeInHierarchy)   //if the bullets ARE NOT active in the hierarchy
            {
                bullets[i].SetActive(true); //set that bullet to active mode
                bullets[i].transform.position = bulletSpawnPosition.position;   //set the bulllets position to to position of the bullet spawner object.
                break;  //this break is necessary, else all ther game objects will be set to active and it will never be disabled
            }
        }
    }
}

