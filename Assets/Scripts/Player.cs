using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Config
    [SerializeField]
    private float runSpeed = 5.0f;
    [SerializeField]
    private float jumpSpeed = 9.0f;


    // State
    bool isAlive = true;


    // Cached Component References
    private Rigidbody2D myRigidbody2D = null;
    private Animator myAnimator = null;


    // Messages then methods
    void Start()
    {
        CacheComponentReferences();
    }

    void Update()
    {
        ListenForMovementInputs();
    }

    private void ListenForMovementInputs()
    {
        Run(Input.GetAxis("Horizontal"));
        Jump(Input.GetButtonDown("Jump"));
    }

    private void Run(float runButtonPressedAmount)
    {
        Vector2 moveSpeed = new Vector2(runSpeed * runButtonPressedAmount, myRigidbody2D.velocity.y);
        myRigidbody2D.velocity = moveSpeed;
    }

    private void Jump(bool jumpButtonPressed)
    {
        if (jumpButtonPressed)
        { 
            Vector2 jumpVelocityToAdd = new Vector2(0f, jumpSpeed);

            myRigidbody2D.velocity += jumpVelocityToAdd;
        }
    }

    private void CacheComponentReferences()
    {
        myRigidbody2D = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
    }
}
