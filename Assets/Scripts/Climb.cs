using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Climb : MonoBehaviour
{
    // Config
    [SerializeField] private float climbSpeed = 12f;
    [SerializeField] private LayerMask climbableLayer;

    private string isClimbingAnimatorBoolString = "IsClimbing";

    private bool isClimbing = false;

    private string climbingInputAxis = "Vertical";

    private string jumpInput = "Jump";

    private float cachedStartingGravity;


    // Cached Component References
    private Collider2D myCollider2D = null;

    private Animator myAnimator = null;

    private Rigidbody2D myRigidbody2D = null;

    void Start()
    {
        CacheComponentReferences();
    }

    private void Update()
    {
        bool isTouchingLadder = myCollider2D.IsTouchingLayers(climbableLayer);

        if (isTouchingLadder)
        {
            ListenForClimbInputs();
        }
    }

    private void OnTriggerExit2D(Collider2D triggerToExit)
    {
        if (1 << triggerToExit.gameObject.layer == climbableLayer.value) //https://forum.unity.com/threads/get-the-layernumber-from-a-layermask.114553/
        {
            StopClimbing();
        }
    }

    private void ListenForClimbInputs()
    {

        if(isClimbing && Input.GetButtonDown(jumpInput))
        {
            StopClimbing();
        }

        if (!isClimbing && Input.GetButton(climbingInputAxis))
        {
            BeginClimbing();
        }
        
        if (isClimbing)
        {
            MoveClimbwards(Input.GetAxis(climbingInputAxis));
        }
    }

    private void BeginClimbing()
    {
        isClimbing = true;
        myRigidbody2D.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;

        cachedStartingGravity = myRigidbody2D.gravityScale;
        myRigidbody2D.gravityScale = 0;
        myRigidbody2D.velocity = Vector2.zero;


        PlayClimbAnimation();
    }

    private void StopClimbing()
    {
        isClimbing = false;
        myRigidbody2D.constraints = RigidbodyConstraints2D.FreezeRotation;
        myRigidbody2D.gravityScale = cachedStartingGravity;

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