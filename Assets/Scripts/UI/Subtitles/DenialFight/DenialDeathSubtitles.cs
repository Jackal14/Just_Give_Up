using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DenialDeathSubtitles : MonoBehaviour
{
    //This is how we create a TextMeshPro object
    public TMP_Text denialSubtitle;

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
       if(!onetime)
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
        denialSubtitle.text = "";
        yield return new WaitForSeconds(subtitleSpeed); //Wait one second

        //Create a string called sentence which will hold what we want to display
        string sentence = "Nothing's wrong anyways...";
        //This will convert the string to a character array so we can display each letter at a time
        foreach (char letter in sentence.ToCharArray())
        {
            //Add the letter to our text mesh pro text to display on screen
            denialSubtitle.text += letter;
            //Put a little delay between each character being displayed 
            yield return new WaitForSeconds(textSpeed); //Gives it more of a typing feeling

        }
        //Keep the text up for a second
        yield return new WaitForSeconds(subtitleSpeed);
        denialSubtitle.text = ""; //Reset the text to blank
        yield return new WaitForSeconds(subtitleSpeed); //Pause for dramatic effect

        //You know the drill from here on out
        sentence = "Trust me...";
        foreach (char letter in sentence.ToCharArray())
        {
            denialSubtitle.text += letter;
            yield return new WaitForSeconds(textSpeed);

        }
        yield return new WaitForSeconds(subtitleSpeed);
        denialSubtitle.text = "";
        yield return new WaitForSeconds(subtitleSpeed);

        sentence = "There's nothing to worry about...";
        foreach (char letter in sentence.ToCharArray())
        {
            denialSubtitle.text += letter;
            yield return new WaitForSeconds(textSpeed);

        }
        yield return new WaitForSeconds(subtitleSpeed);
        denialSubtitle.text = "";
        yield return new WaitForSeconds(subtitleSpeed);

        sentence = "You can give up...";
        foreach (char letter in sentence.ToCharArray())
        {
            denialSubtitle.text += letter;
            yield return new WaitForSeconds(textSpeed);

        }
        yield return new WaitForSeconds(subtitleSpeed);
        denialSubtitle.text = "";

        //Now that we've displayed all our text, display the buttons for the user to use
        buttons.SetActive(true);
    }

}
