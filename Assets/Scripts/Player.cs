using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Config
    [SerializeField] private float runSpeed = 5.0f;
    [SerializeField] private LayerMask[] layersThatKillMe;
    [SerializeField] private Sprite deadSprite;
    [SerializeField] private Vector2 deathAnimationForce;
    
    private string horizontalMovementInputString = "Horizontal";
    private string isAliveAnimationString = "IsAlive";

    private bool alive = true;

    // Cached Component References
    private Rigidbody2D myRigidbody2D;
    private Animator myAnimator;
    private SpriteRenderer mySpriteRenderer;


    // Messages then methods
    void Start()
    {
        CacheComponentReferences();
    }

    void Update()
    {
        if (alive)
        {
            ListenForMovementInputs();
        }
    }

    private void OnCollisionEnter2D(Collision2D collisionData)
    {
        CheckForDeath(collisionData.collider);
    }

    private void OnTriggerEnter2D(Collider2D otherCollider2D)
    {
        CheckForDeath(otherCollider2D);
    }

    private void CheckForDeath(Collider2D otherCollider2D)
    {
        foreach (LayerMask deathlyLayer in layersThatKillMe)
        {
            if (1 << otherCollider2D.gameObject.layer == deathlyLayer.value) //https://forum.unity.com/threads/get-the-layernumber-from-a-layermask.114553/
            {
                if (alive) { Die(); }
            }
        }

    }

    private void Die()
    {
        alive = false;
        myRigidbody2D.velocity = deathAnimationForce;
        myAnimator.SetBool(isAliveAnimationString, false);
        Time.timeScale = 0.3f;
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
        mySpriteRenderer = GetComponent<SpriteRenderer>();
    }
}
