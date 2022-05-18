using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Script to control the enemy health
public class Enemy : MonoBehaviour
{
    //Establishes the health of the enemy
    public int health = 100;

    //Where to put in deathEffect
    public GameObject deathEffect;

    //Function for when the enemy takes damage
    //Function is public so it can be called by bullet script
    public void TakeDamage (int damage)
    {
        //Enemy health drops based on damage taken
        health -= damage;
    }
}
