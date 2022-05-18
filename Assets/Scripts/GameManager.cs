using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Script to manage the flow of the game
public class GameManager : MonoBehaviour
{
    //Player GameObject to control the player
    public GameObject player;
    //Gameobject to have player animations for start and death
    public GameObject playerAnimation;
    public Animator playerAnimationController;
    //PlayerHealth variable to keep track of player health
    public PlayerHealth playerHealth;

    //Enemy GameObject to control the enemy
    public GameObject enemy;
    //GameObject to have enemy animations for start and death
    public GameObject enemyAnimation;
    public Animator enemyAnimationController;
    //Enemy variable to keep track of enemy health
    public Enemy enemyHealth;

    //GameObject to control the deathScreen
    public GameObject deathScreen;

    //At the start of the game
    private void Start()
    {
        //Disable the player
        player.SetActive(false);
        //Disable the enemy
        enemy.SetActive(false);
        //Disable the death screen
        deathScreen.SetActive(false);
        //Start the intro sequence
        StartCoroutine(IntroSequence());
    }

    private void Update()
    {
        //If the player health drops to zero
        if(playerHealth.health <= 0)
        {
            //Start the player death sequence
            StartCoroutine(PlayerDeath());
        }
        //If the boss health drops to zero
        if(enemyHealth.health <= 0)
        {
            //Start the enemy death sequence
            StartCoroutine(BossDeath());
        }
    }

    //Intro sequence
    IEnumerator IntroSequence()
    {
        //Wait for however long the intro animation is
        yield return new WaitForSeconds(5);
        //Turn off the animations after, activate the enemy and player to start the game
        playerAnimation.SetActive(false);
        enemyAnimation.SetActive(false);
        player.SetActive(true);
        enemy.SetActive(true);
    }

    //Player death sequence
    IEnumerator PlayerDeath()
    {
        //Set time scale to 0, "freeze" the game
        Time.timeScale = 0;

        //Activate the player animation gameobject
        playerAnimation.SetActive(true);
        //Place the playerAnimation gameobject where the player was
        playerAnimation.transform.position = (player.transform.position);
        //Disable the player
        player.SetActive(false);
        //Set the animator bool to isDead to play the death animation
        playerAnimationController.SetBool("isDead", true);
        //Wait for however long the player death animation is
        yield return new WaitForSecondsRealtime(5);
        //Turn on the death screen
        deathScreen.SetActive(true);
        //Disable the enemy so it aint chilling in the background
        enemy.SetActive(false);
        //Reset the time scale so the subtitles can play
        Time.timeScale = 1;
    }

    //Enemy death sequence
    IEnumerator BossDeath()
    {
        //Set time scale to 0, "freeze" the game
        Time.timeScale = 0;
        //Disable the enemy
        enemy.SetActive(false);
        //Enable the enemy animations
        enemyAnimation.SetActive(true);
        enemyAnimationController.SetBool("isDead", true);
        //Wait for however long the death animation is
        yield return new WaitForSecondsRealtime(5);
        //Load the next scene in the build index to transition to the next level
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Time.timeScale = 1;
    }
}
