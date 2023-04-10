using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private Rigidbody2D rb2d;
    public float speed;
    private Vector2 movement;
    public bool isPauseGame = false;
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        //PointController.Point = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(!isPauseGame)
        {
        movement = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        }
    }

    void FixedUpdate()
    {
        rb2d.MovePosition(rb2d.position + movement.normalized * speed * Time.fixedDeltaTime);
    }
}
