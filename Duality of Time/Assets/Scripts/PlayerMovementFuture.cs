using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementFuture : MonoBehaviour
{

    [SerializeField] private CharacterController2D controller;
    [SerializeField] private Animator animator;

    [SerializeField] private float runSpeed = 40f;

    private float horizonralMove = 0f;
    private bool crouch = false;

    // Update is called once per frame
    void Update()
    {
        animator.SetFloat("Speed", Mathf.Abs(horizonralMove));

        GetHorizontalMove();
        Crouch();
    }

    private void FixedUpdate()
    {
        MoveForward();
    }

    private void MoveForward()
    {
        controller.Move(horizonralMove * Time.fixedDeltaTime, crouch, false);
    }

    private void GetHorizontalMove()
    {
        horizonralMove = Input.GetAxisRaw("Horizontal") * runSpeed;
    }
    private void Crouch()
    {
        if (Input.GetButtonDown("Crouch"))
        {
            crouch = true;
        }

        else if (Input.GetButtonUp("Crouch"))
        {
            crouch = false;
        }
    }

    public void OnCrouching(bool isCrouching)
    {
        animator.SetBool("Crouching", isCrouching);
    }
}
