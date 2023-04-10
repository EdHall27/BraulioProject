using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IgnoreObject : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        Physics.IgnoreLayerCollision(1,1, true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /*void OnCollisionEnter(Collision collision)
    {
        Physics.IgnoreCollision(collision.collider, GetComponent<Collider>());
    }*/
}
