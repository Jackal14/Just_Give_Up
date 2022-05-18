using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class BargainingPreFightSubtitles : MonoBehaviour
{
    //This is how we create a TextMeshPro object
    public TMP_Text subtitle;

    //Floats so the player can control the speed of the text on screen
    float textSpeed = 0.1f;
    float subtitleSpeed = 1f;

    //Start a coroutine when the scene is loaded
    void Start()
    {
        StartCoroutine(TheSequence());
    }

    void Update()
    {
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

    //This sequence will display all of our text
    IEnumerator TheSequence()
    {
        //Make sure text is blank at the beginning
        subtitle.text = "";
        yield return new WaitForSeconds(subtitleSpeed); //Wait one second

        //Create a string called sentence which will hold what we want to display
        string sentence = "This is real...";
        //This will convert the string to a character array so we can display each letter at a time
        foreach (char letter in sentence.ToCharArray())
        {
            //Add the letter to our text mesh pro text to display on screen
            subtitle.text += letter;
            //Put a little delay between each character being displayed 
            yield return new WaitForSeconds(textSpeed); //Gives it more of a typing feeling

        }
        //Keep the text up for a second
        yield return new WaitForSeconds(subtitleSpeed);
        subtitle.text = ""; //Reset the text to blank
        yield return new WaitForSeconds(subtitleSpeed); //Pause for dramatic effect

        //You know the drill from here on out
        sentence = "There has to be something I can do...";
        foreach (char letter in sentence.ToCharArray())
        {
            subtitle.text += letter;
            yield return new WaitForSeconds(textSpeed);

        }
        yield return new WaitForSeconds(subtitleSpeed);
        subtitle.text = "";
        yield return new WaitForSeconds(subtitleSpeed);

        sentence = "What will it take...";
        foreach (char letter in sentence.ToCharArray())
        {
            subtitle.text += letter;
            yield return new WaitForSeconds(textSpeed);

        }
        yield return new WaitForSeconds(subtitleSpeed);
        subtitle.text = "";
        yield return new WaitForSeconds(subtitleSpeed);

        sentence = "There has to be something...";
        foreach (char letter in sentence.ToCharArray())
        {
            subtitle.text += letter;
            yield return new WaitForSeconds(textSpeed);

        }
        yield return new WaitForSeconds(subtitleSpeed);
        subtitle.text = "";
        yield return new WaitForSeconds(subtitleSpeed); //Wait a little longer

        //Load the scene right after this one on the build index
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
