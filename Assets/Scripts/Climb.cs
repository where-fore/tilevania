using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Climb : MonoBehaviour
{
    // Config
    [SerializeField] private float climbSpeed = 12f;
    private string layerForClimbableObject = "Climbing";

    private string isClimbingAnimatorBoolString = "IsClimbing";

    private bool isClimbing = false;

    private bool isInLadder = false;

    private string climbingInputAxis = "Vertical";

    private string jumpInput = "Jump";

    private Vector2 cachedStartingGravity;


    // Cached Component References
    private Collider2D myCollider2D = null;

    private Animator myAnimator = null;

    private Rigidbody2D myRigidbody2D = null;

    void Start()
    {
        CacheComponentReferences();
        cachedStartingGravity = Physics2D.gravity;
    }

    private void Update()
    {
        bool isTouchingLadder = myCollider2D.IsTouchingLayers(LayerMask.GetMask(layerForClimbableObject));
        Debug.Log(isTouchingLadder);

        if (isTouchingLadder && !isInLadder)
        {
            isInLadder = true;
        }

        if(!isTouchingLadder)
        {
            isInLadder = false;
        }

        if (isInLadder)
        {
            ListenForClimbInputs();
        }

        if (isClimbing)
        {
            //myRigidbody2D.velocity += cachedStartingGravity;
        }
    }

    private void ListenForClimbInputs()
    {

        if (!isClimbing && Input.GetButtonDown(climbingInputAxis))
        {
            Debug.Log("Trying to begin climbing");
            BeginClimbing();
        }
        else if (Input.GetAxis(climbingInputAxis) != 0 && isClimbing)
        {
            MoveClimbwards(Input.GetAxis(climbingInputAxis));
        }

        if(isClimbing && Input.GetButtonDown(jumpInput))
        {
            StopClimbing();
        }
    }

    private void BeginClimbing()
    {
        Debug.Log("Climbing");
        isClimbing = true;
        myRigidbody2D.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;

        PlayClimbAnimation();
    }

    private void StopClimbing()
    {
        isClimbing = false;
        myRigidbody2D.constraints = RigidbodyConstraints2D.FreezeRotation;

        StopClimbingAnimation();
    }

    private void MoveClimbwards(float climbButtonPressedAmount)
    {
        Vector2 moveSpeed = new Vector2(0, climbSpeed * climbButtonPressedAmount);
        myRigidbody2D.velocity = moveSpeed;
    }

    private void PlayClimbAnimation()
    {
        myAnimator.SetBool(isClimbingAnimatorBoolString, true);
    }

    private void StopClimbingAnimation()
    {
        myAnimator.SetBool(isClimbingAnimatorBoolString, false);
    }
    
    private void CacheComponentReferences()
    {
        myCollider2D = GetComponent<Collider2D>();
        myAnimator = GetComponent<Animator>();
        myRigidbody2D = GetComponent<Rigidbody2D>();
    }
}