using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float speed;

    
    // Update is called once per frame
    void Update()
    {
      
        transform.Translate(Vector3.right * Time.deltaTime * speed);
        

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        Destroy(this.gameObject);
    }

    void OnBecameInvisible()
    {
        Destroy(this.gameObject);
    }
}
