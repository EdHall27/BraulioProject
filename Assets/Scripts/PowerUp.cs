using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public int lifeCount;
    private void  OnCollisionEnter2D(Collision2D collision)
    {
        //if(colision.gameObject.CopareTag('Life'))
        if(collision.gameObject.name.Equals("Life"))
        {
            Destroy(collision.gameObject);
            lifeCount++;
            Debug.Log("Life Count: "+ lifeCount);
        }
    }
}
