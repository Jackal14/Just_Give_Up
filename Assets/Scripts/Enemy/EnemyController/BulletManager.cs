using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Script to manage and "recycle" bullets through object pooling (Put this on an empty game object or manager of sorts)

public class BulletManager : MonoBehaviour
{
    //List of bullets in the scene
    public static List<GameObject> bullets;
    void Start()
    {
        bullets = new List<GameObject>();
    }

    //Function to grab the bullets not active
    public static GameObject GetBulletFromPool()
    {
        //Goes through each of the bullets in the list
        for (int i = 0; i < bullets.Count; i++)
        {
            //If the bullet is not active return it to the pool
            if (bullets[i].activeInHierarchy)
            {
                //Timer is reset for the bullet (lifetime)
                bullets[i].GetComponent<EnemyBullet>().ResetTimer();
                //Set the bullet active again and return the bullet 
                bullets[i].SetActive(true);
                return bullets[i];
            }
        }
        //If there are no bullets return null
        return null;
    }
}
