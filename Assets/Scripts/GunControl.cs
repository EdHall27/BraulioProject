using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunControl : MonoBehaviour
{
    SpriteRenderer sprite;

    public GameObject bullet;
    public Transform spawnBullet; 
    public bool isPauseGame = false;
    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!isPauseGame)
        {
        PlayerMouse();
        Shoot();
        //se a buller sair da main camera 
        }

    }

    void Shoot()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            Instantiate(bullet, spawnBullet.position, transform.rotation);
        }
    }

     private void PlayerMouse()
     {
        Vector3 mousePos = Input.mousePosition;
        Vector3 screenPoint = Camera.main.WorldToScreenPoint(transform.position);

        Vector2 offset = new Vector2(mousePos.x - screenPoint.x, mousePos.y - screenPoint.y);

        float angle = Mathf.Atan2(offset.y,offset.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0,0,angle);

        sprite.flipY = (mousePos.x < screenPoint.x);
     }
}
