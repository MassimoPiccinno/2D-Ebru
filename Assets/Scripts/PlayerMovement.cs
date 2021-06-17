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
        animator.SetFloat("Speed", horizontalMovement);

        if(joystick.Vertical >= .2f)
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
