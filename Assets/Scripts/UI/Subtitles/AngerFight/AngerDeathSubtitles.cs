using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AngerDeathSubtitles : MonoBehaviour
{
    //This is how we create a TextMeshPro object
    public TMP_Text angerSubtitle;

    //Disable the buttons in the beginning
    public GameObject buttons;

    //Want to check if the player is "dead"
    public PlayerHealth playerHealth;

    //Bool used to make sure our function is only called once
    bool onetime = false;

    //Floats so the player can control the speed of the text on screen
    float textSpeed = 0.1f;
    float subtitleSpeed = 1f;

    //Disable the buttons until the end of the subtitles
    void Start()
    {
        buttons.SetActive(false);
    }

    //Once the gameobject is active, just one time check the players health
    void Update()
    {
        if (!onetime)
        {
            CheckPlayer();
            onetime = true;
        }

        //Increase the speed of the text if the player is holding space
        if (Input.GetKeyDown("space"))
        {
            textSpeed = 0.05f;
            subtitleSpeed = textSpeed;
        }
        if (Input.GetKeyUp("space"))
        {
            textSpeed = 0.1f;
            subtitleSpeed = 1f;
        }
    }

    //If the players health is less than 0 start the enumerator
    void CheckPlayer()
    {
        if (playerHealth.health <= 0)
        {
            StartCoroutine(TheSequence());
        }
    }


    //This sequence will display all of our text
    IEnumerator TheSequence()
    {
        //Make sure text is blank at the beginning
        angerSubtitle.text = "";
        yield return new WaitForSeconds(subtitleSpeed); //Wait one second

        //Create a string called sentence which will hold what we want to display
        string sentence = "Just Stop!";
        //This will convert the string to a character array so we can display each letter at a time
        foreach (char letter in sentence.ToCharArray())
        {
            //Add the letter to our text mesh pro text to display on screen
            angerSubtitle.text += letter;
            //Put a little delay between each character being displayed 
            yield return new WaitForSeconds(textSpeed); //Gives it more of a typing feeling

        }
        //Keep the text up for a second
        yield return new WaitForSeconds(subtitleSpeed);
        angerSubtitle.text = ""; //Reset the text to blank
        yield return new WaitForSeconds(subtitleSpeed); //Pause for dramatic effect

        //You know the drill from here on out
        sentence = "I don't need you";
        foreach (char letter in sentence.ToCharArray())
        {
            angerSubtitle.text += letter;
            yield return new WaitForSeconds(textSpeed);

        }
        yield return new WaitForSeconds(subtitleSpeed);
        angerSubtitle.text = "";
        yield return new WaitForSeconds(subtitleSpeed);

        sentence = "Go away!";
        foreach (char letter in sentence.ToCharArray())
        {
            angerSubtitle.text += letter;
            yield return new WaitForSeconds(textSpeed);

        }
        yield return new WaitForSeconds(subtitleSpeed);
        angerSubtitle.text = "";
        yield return new WaitForSeconds(subtitleSpeed);

        sentence = "Just give up!";
        foreach (char letter in sentence.ToCharArray())
        {
            angerSubtitle.text += letter;
            yield return new WaitForSeconds(textSpeed);

        }
        yield return new WaitForSeconds(subtitleSpeed);
        angerSubtitle.text = "";

        //Now that we've displayed all our text, display the buttons for the user to use
        buttons.SetActive(true);
    }
}
