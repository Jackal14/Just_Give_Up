using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    //Reference to fire point object
    public Transform firePoint;
    //Reference the bullet prefab
    public GameObject playerBulletPrefab;

    //Variable for force of bullet
    public float playerBulletForce = 20f;


    // Update is called once per frame
    void Update()
    {
        //Determine if left mouse button is being clicked
        if(Input.GetButtonDown("Fire1"))
        {
            //Create a function for shoot that runs when mouse 1 is clicked
            Shoot();
        }
    }

    void Shoot()
    {
        //Create, from bulletPrefab, at the firePoint position, based on firePoint rotation
        //Reference bullet to add force to
        GameObject playerBullet = Instantiate(playerBulletPrefab, firePoint.position, firePoint.rotation);

        //Access rb 2d, store this in another variable
        Rigidbody2D rb = playerBullet.GetComponent<Rigidbody2D>();

        //Adds force to the rb, in the direction of the firePoint up vector, times the bullet force 
        rb.AddForce(firePoint.up * playerBulletForce, ForceMode2D.Impulse);

    }
}
