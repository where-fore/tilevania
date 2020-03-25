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
        Run();
        Jump();
    }

    private void Run()
    {
        Vector2 moveSpeed = new Vector2(runSpeed * Input.GetAxis("Horizontal"), myRigidbody2D.velocity.y);
        myRigidbody2D.velocity = moveSpeed;
    }

    private void Jump()
    {
        if (Input.GetButtonDown("Jump"))
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
