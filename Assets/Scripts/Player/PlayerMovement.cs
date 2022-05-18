using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMovement : MonoBehaviour
{
    //Declare a variable for the moveSpeed
    public float moveSpeed = 5f;

    //Reference rigidbody component on player
    public Rigidbody2D rb;

    //Camera needs to be referenced for pointer feature
    public Camera cam;

    //Variable that can be accessed by FixedUpdate based on input from update
    Vector2 movement;
    //A variable for the world units to be used for pointer feature
    Vector2 mousePos;

    // Update is called once per frame
    //This is where movement will be triggered (input)
    void Update()
    {
        //Gather input on X and Y axis
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        //Converts pixel coordinates from Input.mousePosition into world units
        //Set the mouse position equal to the world units
        //This tells us exactly where our mouse is
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
    }

    //Where player will be actually moved based on input
    void FixedUpdate()
    {
        //Call on rigid body and move the position based on the movement inputed, and move it at moveSpeed, ensure that time isn't called based on update
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);

        //If you subtract two vectors you get the vector that points from one to the other
        Vector2 lookDir = mousePos - rb.position;

        //This is the code that determines what angle the player needs to be rotated to based on mouse
        //Function that returns the angle between the X axis and a 2D vector
        //Value returned is in radians which needs to be converted into degrees for rotation
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;

        //Rotate the player based on angle determined
        rb.rotation = angle;
    }
}
