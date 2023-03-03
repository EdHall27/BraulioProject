using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quadrado : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.F))
        {
           gameObject.GetComponent<SpriteRenderer>().color = new Color(0,0,0);
        }


    }
}
