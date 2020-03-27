using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Config
    [SerializeField] private float runSpeed = 5.0f;
    
    private string horizontalMovementInputString = "Horizontal";

    // Cached Component References
    private Rigidbody2D myRigidbody2D;
    private Animator myAnimator;


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
        Run(Input.GetAxis(horizontalMovementInputString));
    }

    private void Run(float runButtonPressedAmount)
    {
        Vector2 moveSpeed = new Vector2(runSpeed * runButtonPressedAmount, myRigidbody2D.velocity.y);
        myRigidbody2D.velocity = moveSpeed;
    }

    private void CacheComponentReferences()
    {
        myRigidbody2D = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
    }
}
