﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BetterJump : MonoBehaviour
{
    // Config
    [SerializeField] private float jumpSpeed = 9.0f;

    [SerializeField]
    private float fallMultiplier = 3.5f;

    [SerializeField] private float lowJumpMultiplier = 3f;

    [SerializeField] private float gravityMultiplier = 4f;

    [SerializeField] private string layerToTouchForRefreshedJumpString = "Ground";
    private int layerToTouchForRefreshJump;
    private string jumpButtonInputName = "Jump";


    // Cached Component Refences
    private Rigidbody2D myRigidbody2D;
    private CapsuleCollider2D myBodyCollider2D;
    private BoxCollider2D myFeetCollider2D;

    private void Start()
    {
        CacheComponentReferences();

        myRigidbody2D.gravityScale = gravityMultiplier;

        layerToTouchForRefreshJump = LayerMask.GetMask(layerToTouchForRefreshedJumpString);
    }

    private void Update()
    {
        ListenForJumpInputs();
    }

    private void ListenForJumpInputs()
    {
        bool jumpButtonPressed = Input.GetButtonDown(jumpButtonInputName);

        Jump(jumpButtonPressed);
    }

    private void Jump(bool jumpButtonPressed)
    {
        ApplyExtraJumpGravity();

        bool ableToJump = myFeetCollider2D.IsTouchingLayers(layerToTouchForRefreshJump);

        if (jumpButtonPressed && ableToJump)
        { 
            Vector2 jumpVelocityToAdd = new Vector2(0f, jumpSpeed);

            myRigidbody2D.velocity += jumpVelocityToAdd;

            ableToJump = false;
        }
    }

    private void ApplyExtraJumpGravity()
    {
        if (myRigidbody2D.velocity.y < 0)
        {
            myRigidbody2D.velocity += Vector2.up * Physics2D.gravity.y * fallMultiplier * Time.deltaTime;
        }

        else if (myRigidbody2D.velocity.y > 0 && !Input.GetButton(jumpButtonInputName))
        {
            myRigidbody2D.velocity += Vector2.up * Physics2D.gravity.y * lowJumpMultiplier * Time.deltaTime;
        }
    }

    private void CacheComponentReferences()
    {
        myRigidbody2D = GetComponent<Rigidbody2D>();
        myBodyCollider2D = GetComponent<CapsuleCollider2D>();
        FindFeet();
    }

    private void FindFeet()
    {
        foreach (Transform child in transform)
        {
            if (child.GetComponent<PlayerFeet>())
            {
                myFeetCollider2D = child.GetComponent<BoxCollider2D>();
            }
        }
    }
}
