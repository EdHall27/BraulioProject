using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public GameObject player;
    public HealthControl healthbar;
    public float lifeCount;
    private void  OnCollisionEnter2D(Collision2D collision)
    {
        //if(collision.gameObject.name.Equals("Life"))
        if(collision.gameObject.CompareTag("Life"))
        {
            healthbar.RestoreHealth(lifeCount);
            Destroy(collision.gameObject);
        }
    }
}
