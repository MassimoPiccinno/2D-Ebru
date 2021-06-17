using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TDPlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f; //movement speed

    public Rigidbody2D rb; //rigidbody 
    public SpriteRenderer sr; //sprite renderer
    public Animator anim;

    Vector2 movement; //Used to store movement data (X, Y)
    bool facingRight; 

    // Handle Input
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        Debug.Log(Input.GetAxisRaw("Horizontal"));

        anim.SetFloat("Horizontal", movement.x);
        anim.SetFloat("Vertical", movement.y);
        anim.SetFloat("Speed", movement.sqrMagnitude);

        if(movement.x < 0)
        {
            sr.flipX = true;
        }
        else if(movement.x == 0)
        {
            sr.flipX = false;
        }
        
    }

    //Handle Movement
    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }



}
