using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This script makes the boss chase the player around the screen

public class AngerChase : MonoBehaviour
{
    //Gameobject to disable bullet spawning while the boss is in motion
    public GameObject bulletSpawner;
    //Gameobject to determine the position of the player
    public GameObject player;
    //Bool to keep track of the enemy chasing
    public bool isChasing = false;
    //Vector 3 for the target position I.E. the player
    Vector3 targetPosition;

    //When enemy is enabled, start the coroutine
    private void OnEnable()
    {
        StartCoroutine(ChasePlayerCooldown());
    }
    // Update is called once per frame
    void Update()
    {
        //If the enemy is currently on the chase
        if(isChasing)
        {
            //Move the enemy towards target position
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, .02f);
            //Once the enemy has reached target position, enable the bullet spawner
            if(transform.position == targetPosition)
            {
                bulletSpawner.SetActive(true);
                //Stop chasing and start the cooldown
                NotChasing();
                isChasing = false;
            }
        }
    }

    //Function to start the coroutine
    void NotChasing()
    {
        StartCoroutine(ChasePlayerCooldown());
    }

    //Chase cooldown enumerator
    IEnumerator ChasePlayerCooldown()
     {
        yield return new WaitForSeconds(2);
        //Set the target position to the players current transform
        targetPosition = player.transform.position;
        //Start chasing the player again 
        isChasing = true;
        //Disable the bullet spawner
        bulletSpawner.SetActive(false);
     }
}
