using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller;
    public Animator animator;
    public Joystick joystick;

    float horizontalMovement;
    public float runSpeed = 60f;

    bool jump = false;
    bool crouch = false;


    // Update is called once per frame
    void Update()
    {
        horizontalMovement = joystick.Horizontal * runSpeed; // -1 : 1, D = 1, A = -1
        animator.SetFloat("Speed", Mathf.Abs(horizontalMovement));

        //tries to play animation when speed >= 0.01 right: speed = 1 * something = 10
        //                                           left: speed = -1 * something = -10 ; abs value = 10

        if(joystick.Vertical >= .5f)
        {
            jump = true;
            animator.SetBool("isJumping", true);
        }
        /*
        if(Input.GetButtonDown("Crouch"))
        {
            crouch = true;
            Debug.Log("Crouching");
        
        }else if(Input.GetButtonUp("Crouch"))
        {
            crouch = false;
        } */
    }

    public void OnLanding ()
    {
        animator.SetBool("isJumping", false); 
    }

    public void OnCrouching(bool isCrouching)
    {
        animator.SetBool("isCroching", isCrouching);
    }

    private void FixedUpdate()
    {
        controller.Move(horizontalMovement * Time.fixedDeltaTime, crouch, jump);
        jump = false;
    }
}
