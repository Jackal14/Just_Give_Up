using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BargainingBulletScript : MonoBehaviour
{
    public Enemy boss;
    // Start is called before the first frame update
    void Start()
    {
        boss = FindObjectOfType<Enemy>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            boss.TakeDamage(1);
            Debug.Log("BossTakingDamage");
            Debug.Log(boss.health);
            Destroy(this.gameObject);
        }
    }
}
