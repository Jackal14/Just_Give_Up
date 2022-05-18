using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Script to generate the enemy bullets, all data is pulled from the BulletSpawnData scriptable objects (Put this on the enemy we want the bullets to spawn from)

public class EnemyBulletSpawner : MonoBehaviour
{
    //Array of bulletspawndata that can be used for attacks (this is our scriptable objects)
    public BulletSpawnData[] spawnDatas;
    //We'll use this to determine our place in the array, start at 0
    public int index = 0;
    //We'll use this if we want the attack sequence to be random and not in order
    public bool isSequenceRandom;

    //This will reference the BulletSpawnData script 
    //Whenever the data is needed call the GetSpawnData() function
    BulletSpawnData GetSpawnData()
    {
        return spawnDatas[index];
    }

    //Timer to manage the bullet cooldown
    float timer;

    //Float array to hold the rotation of the bullets
    float[] rotations;

    //Actions to be performed at the very beginning
    void Start()
    {
        //Sets timer to the cooldown set in the spawn data
        timer = GetSpawnData().cooldown;

        //Initializing array for rotations
        rotations = new float[GetSpawnData().numberOfBullets];

        //If it's not random, distribute the rotations in a set pattern, determines at what rotation the bullets spawn
        if (!GetSpawnData().isRandom)
        {
            DistributedRotations();
        }
    }

    //What needs to called per frame
    void Update()
    {
            //If timer is done counting down SPAWN MORE BULLETS!!!! MUAHAHAHAHA
            if (timer <= 0)
            {
                //Calls on the SpawnBullets function and resets the cooldown for the next wave
                SpawnBullets();
                timer = GetSpawnData().cooldown;

                //If the bool isSequenceRandom true, randomize the sequence (The order at which the patterns in the array are used)
                if (isSequenceRandom)
                {
                    //Pick a random number in the sequence and play that one 
                    index = Random.Range(0, spawnDatas.Length);
                }
                //Else play the sequence in order
                else
                {
                    //Go to the next sequence in the index
                    index++;
                    //If index exceeds the length reset the sequence and loop
                    if (index >= spawnDatas.Length)
                    {
                        index = 0;
                    }
                }
            }
            //Count down the timer in real seconds
            timer -= Time.deltaTime;
    }

    //This function selects a random rotation for every bullet between min and max
    public float[] RandomRotations()
    {
        for (int i = 0; i < GetSpawnData().numberOfBullets; i++)
        {
            //Creates a random range generator for the amount of bullets we want to spawn between set max and min ranges (angles)
            rotations[i] = Random.Range(GetSpawnData().minRotation, GetSpawnData().maxRotation);
        }
        return rotations;
    }

    //This function will distribute rotations in a set pattern, rotations won't be random
    public float[] DistributedRotations()
    {
        //This actually assigns the rotation to the bullet so it knows where to go
        for (int i = 0; i < GetSpawnData().numberOfBullets; i++)
        {
            //Calculates the rotation of the bullet (complicated math stuff, values can be messed with but I just looked up a formula so idk)
            var fraction = (float)i / (float)GetSpawnData().numberOfBullets;
            var difference = GetSpawnData().maxRotation - GetSpawnData().minRotation - 2f;
            var fractionOfDifference = fraction * difference;
            //Final rotation
            rotations[i] = fractionOfDifference * GetSpawnData().minRotation;
            //rotations[i] = difference;
        }
        foreach (var r in rotations);
        return rotations;
    }

    //Function to actually instantiate the bullets
    public GameObject[] SpawnBullets()
    {
        rotations = new float[GetSpawnData().numberOfBullets];
        //If bullet spawning is random
        if (GetSpawnData().isRandom)
        {
            //Ensure that the rotation for the bullet is random each time
            RandomRotations();
        }
        else
        {
            //Else use the set rotations
            DistributedRotations();
        }

        //Spawn the bullets
        GameObject[] spawnedBullets = new GameObject[GetSpawnData().numberOfBullets];
        //Will continue to instantiate bullets until the numberOfBullets to spawn is met
        for (int i = 0; i < GetSpawnData().numberOfBullets; i++)
        {
            //Check to see if there are bullets in the pool so we can spawn these insteand of instantiating (object pooling)
            spawnedBullets[i] = BulletManager.GetBulletFromPool();
            //If not instantiate the bullets
            if (spawnedBullets[i] == null)
            {
                spawnedBullets[i] = Instantiate(GetSpawnData().bulletResource, transform);
            }
            //Else if we did get a bullet, set it's transform to this game object
            else
            {
                spawnedBullets[i].transform.SetParent(transform);
                spawnedBullets[i].transform.localPosition = Vector2.zero;
            }

            //Then set the values of the bullet (i.e. speed, velocity)
            var b = spawnedBullets[i].GetComponent<EnemyBullet>();
            b.rotation = rotations[i];
            b.speed = GetSpawnData().bulletSpeed;
            b.velocity = GetSpawnData().bulletVelocity;

            //If isNotParent is set to true just have it not set to the parent
            //This will help when we want to move the parent object (enemy) without moving the bullet
            if (GetSpawnData().isNotParent == true)
            {
                spawnedBullets[i].transform.SetParent(null);
            }
        }
        //Return the spawned bullets
        return spawnedBullets;

    }



}
