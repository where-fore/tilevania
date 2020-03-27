using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;

    [SerializeField] private LayerMask layerToBounceOffOf;

    private bool isMovingRight = true;

    
    // Cached Component References
    private Rigidbody2D myRigidbody2D;
    private Animator myAnimator;


    void Start()
    {
        CacheComponentReferences();
    }

    // Update is called once per frame
    void Update()
    {
        if (isMovingRight)
        {
            Move(moveSpeed);
        }
        else if (!isMovingRight)
        {
            Move(-moveSpeed);
        }
    }

    private void OnTriggerEnter2D(Collider2D otherCollider2D)
    {
        if (1 << otherCollider2D.gameObject.layer == layerToBounceOffOf.value) //https://forum.unity.com/threads/get-the-layernumber-from-a-layermask.114553/
        {
            Turn();
        }
    }

    private void Turn()
    {
        myRigidbody2D.velocity = new Vector2(0f, myRigidbody2D.velocity.y);
        isMovingRight = !isMovingRight;
    }

    private void Move(float moveSpeed)
    {
        myRigidbody2D.velocity = new Vector2(moveSpeed, myRigidbody2D.velocity.y);
    }

    private void CacheComponentReferences()
    {
        myRigidbody2D = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
    }
}
