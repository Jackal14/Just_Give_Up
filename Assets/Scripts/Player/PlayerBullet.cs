using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    //Reference a gameobject for a hit effect
    public GameObject hitEffect; //Show the player they're actually doing something!

    //Public variable so damage amount can be changed
    public int damage = 40;

    //Function that triggers when the bullet collides with something
    void OnCollisionEnter2D(Collision2D collision)
    {
        //Instantiates the hiteffect based on the current position of the bullet with no rotation
        GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
        //Destroy the effect gameObject after half a second
        Destroy(effect, .5f);

        //On collision with an enemy, deal damage 
        if (collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.GetComponent<Enemy>().TakeDamage(damage); //Tell the enemy script to give the enemy some damage
        }

        //Destroy the bullet on collision
        Destroy(gameObject);
    }


}
