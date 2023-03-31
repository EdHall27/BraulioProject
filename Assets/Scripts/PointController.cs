using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PointController 
{
    private static int point;
    public static int Point
    {
        get
        {
            return point;
        } 
        set
        {
            point =value;
            if(point <0 )
            {
               point = 0;
            }
            Debug.Log("Point "+ Point);
        } 
    }

}
