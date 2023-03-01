using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;
    public float speed;
    private Vector2 movement;


    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
         movement = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
    }
    void FixedUpdate()
    {
            _rigidbody2D.MovePosition(_rigidbody2D.position + movement * speed * Time.fixedDeltaTime);
    }
}
