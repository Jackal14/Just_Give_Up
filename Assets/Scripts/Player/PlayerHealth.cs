using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    //Obviously determines the health of the player
    public float health = 0f;
    [SerializeField] private float maxHealth = 3f;

    //This will be used to give the player a small grace period when they get hit
    public float bulletCooldown; //How long the player is invulnerable when hit
    public float bulletTimer; //What will actually be counting down

    //Oh yeah Mr.Krabs, we got a hit animation
    public Animator animator;

    //

    //At the start of the game make the players health be at max
    void Start()
    {
        health = maxHealth;
    }

    //Update function that will count down the bulletCooldown for player to be hit again
    void Update()
    {
        if (bulletTimer > 0)
        {
            //Countdown the bulletTimer until it is 0
            bulletTimer -= Time.deltaTime;
            animator.SetFloat("Timer", bulletTimer); //Keep the Timer animator condition updated to the status
        }
         
    }

    //Function that determines if player has been hit by an enemy bullet
    public void OnTriggerEnter2D(Collider2D collision)
    {
        //If the player is hit with a bullet and doesn't have invincibility
        if (collision.gameObject.tag == "EnemyBullet" && bulletTimer <= 0)
        {
            //Subtract 1 from the health
            UpdateHealth(-1);
            //Set the timer equal to the predetermined cooldown time
            bulletTimer = bulletCooldown;
            animator.SetFloat("Timer", bulletTimer); //Send the bulletTimer information to the animator condition
        }
    }



    //Creates a function that can be called to update the players health
    public void UpdateHealth(float mod)
    {
        //Health is modified by mod
        health += mod;

        //For damage taken, if the health drops below 0 reset
        if (health <= 0f)
        {
            health = 0f;
        }
    }
}
