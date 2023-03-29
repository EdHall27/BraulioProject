using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] float speed;
    GameObject player;
    Animation anim;
    [SerializeField] GameObject powerUp;
    bool isAlive = true;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        //anim = GetComponentInChildren<Animation>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null && isAlive)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);

        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {


        if (collision.CompareTag("Bullet"))
        {
            // Codigo para Animaçao do inimigo morto
            //anim.SetTrigger("Dead");

            int randomNuber = Random.Range(0,10);
            if (randomNuber >= 8)
            {
                Instantiate(powerUp, transform.position, Quaternion.Euler(0f, 0f, 0f));
            }

            isAlive = false;
            Destroy(gameObject, 0.5f);
        }
    }

    private void OnCollisionEnter2D(Collision2D other) {
   
    {
        
        if(other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<HealthControl>().Damage();
        }
    }
}
}
