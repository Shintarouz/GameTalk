using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Tutorial used : https://www.youtube.com/watch?v=whzomFgjT50

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;

    public Rigidbody2D rb;
    public Animator animator;

    Vector2 movement; 

    // Update is called once per frame
    void Update()
    {
        // if movement on horizontal axis = -1 or 1 ( or 0 )
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}
