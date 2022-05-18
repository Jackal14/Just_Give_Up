using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This script controls the shield that the Denial boss uses to block attacks
public class DenialShieldController : MonoBehaviour
{
    public GameObject shield;

    public int randomizer = 0;
    public bool shieldActive = false;

    void OnEnable()
    {
        //Disable the shield at the very beginning
        shield.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //If the shield is not currently active
        if(!shieldActive)
        {
            //Get a random number between 5 and 10
            randomizer = Random.Range(5, 10);
            //The shield is now going to be active 
            shieldActive = true;
            //Start the Activate shield function
            StartCoroutine(ActivateShield());
        }
    }

    //Enumerator activating the shield
    IEnumerator ActivateShield()
    {
        yield return new WaitForSeconds(3);
        //Turn on the shield object
        shield.SetActive(true);
        //Wait for the random number of time
        yield return new WaitForSeconds(randomizer);
        //Disable the shield
        shield.SetActive(false);
        //Wait for a random number of time
        yield return new WaitForSeconds(randomizer);
        //The shield is no longer active
        shieldActive = false;
    }


}
