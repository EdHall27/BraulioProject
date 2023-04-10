using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointController : MonoBehaviour
{
    public int pointPerEnemy = 1;
    //private int point;
   /* public int Point
    {
        get
        {
            return point;
        } 
        set
        {
            point = value;
            if(point < 0 )
            {
               point = 0;
            }
            Debug.Log("Point "+ Point);
        } 
    }*/
    public void EnemyDestroyed()
    {
        PointManager pointManager = GameObject.FindObjectOfType<PointManager>();
        if(pointManager != null)
        {
            pointManager.AddScore(pointPerEnemy);
        }
    }

}
