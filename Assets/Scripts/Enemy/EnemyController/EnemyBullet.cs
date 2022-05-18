using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Script for the bullet itself that controls what it does once it's been spawned (Put this on the bullet prefab)

public class EnemyBullet : MonoBehaviour
{
    //Public variables that will modify the speed and rotation of bullet
    public Vector2 velocity;
    public float speed;
    public float rotation;

    //Will give the bullet a lifetime so it doesn't live forever
    public float lifeTime;
    float timer;


    void Start()
    {
        //Set timer to whatever we decide the lifetime is
        timer = lifeTime;
        transform.rotation = Quaternion.Euler(0, 0, rotation);
    }
    void Update()
    {
        //Move the bullet according to it's speed and velocity
        transform.Translate(velocity * speed * Time.deltaTime);
        //Countdown the timer based on time
        timer -= Time.deltaTime;

        //This will use object pooling, allowing us to recycle old bullets
        if(timer <= 0)
        {
            //Won't have to destroy and instantiate constantly, just disable it
            gameObject.SetActive(false);
        }
    }

    //Reset the timer
    public void ResetTimer()
    {
        timer = lifeTime;
    }
}