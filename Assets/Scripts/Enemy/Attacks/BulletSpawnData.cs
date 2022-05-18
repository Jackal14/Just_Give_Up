using UnityEngine;
//This creates an asset menu for our bullet data (Right click -> Create -> ScriptableObjects -> BulletSpawnData)
[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/BulletSpawnData", order = 1)]

//Scriptable object to hold the data for bullet spawning (The pattern bullets spawn in basically)

public class BulletSpawnData : ScriptableObject
{
    //The bullet that is going to be spawned in (Prefab)
    public GameObject bulletResource;

    //Bullets are gonna be spawned somewhere between these rotations
    public float minRotation;
    public float maxRotation;

    //Number of bullets that are to be spawned per cycle
    public int numberOfBullets;

    //If this is true, randomize the rotation that the bullet spawns in at
    public bool isRandom;

    //Bool to determine if we want the bullets to be spawned as a child
    //Provides more versatility to moving enemy
    public bool isNotParent;

    //How often do bullets spawn
    public float cooldown;
    //Control speed of bullet
    public float bulletSpeed;
    public Vector2 bulletVelocity;
}
