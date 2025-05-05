using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

// Tutorial used : https://www.youtube.com/watch?v=whzomFgjT50

public class PlayerMovement : MonoBehaviour
{
    public int scoreTester;
    public float moveSpeed;
    private float originalMoveSpeed;
    public float sprintSpeed;

    public Rigidbody2D rb;
    public Animator animator;

    Vector2 movement; 

    void Start()
    {
        originalMoveSpeed = moveSpeed;
    }

    void Update()
    {
        if (DialogueManager.Instance != null && DialogueManager.Instance.isDialogueActive)
        {
            moveSpeed = 0;
            animator.SetFloat("Speed", 0);
            return;
        } // if dialogue is playing make moveSpeed 0
        else
        {
            if (Input.GetKey(KeyCode.LeftShift)) 
            {
                moveSpeed = sprintSpeed;
            }
            else
            {
                moveSpeed = originalMoveSpeed;
            }
        }
        // if movement on horizontal axis = -1 or 1 ( or 0 )
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + moveSpeed * Time.fixedDeltaTime * movement);
    }
}
