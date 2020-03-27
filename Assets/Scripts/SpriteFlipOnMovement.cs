using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//If moving to the left, turns the 'flipX' bool to true - flips the sprite if it is moving to the left
//this requires the sprite to be facing to the right when moving to the right


public class SpriteFlipOnMovement : MonoBehaviour
{
    // Config
    private float movementBuffer = 1f; // The amount of velocity needed to count as moving - do not make this 0 for float rounding reasons.


    // Cached Component References
    private Rigidbody2D myRigidbody2D = null;
    private SpriteRenderer mySpriteRenderer = null;


    void Start()
    {
        CacheComponentReferences();
    }

    void Update()
    {
        float myXVelocity = myRigidbody2D.velocity.x;
        bool movingToTheLeft = false;
        bool movingToTheRight = false;

        if (myXVelocity > movementBuffer)
        {
            movingToTheRight = true;
        }
        else if (myXVelocity < -movementBuffer)
        {
            movingToTheLeft = true;
        }

        if (movingToTheLeft)
        {
            transform.localScale = new Vector2(-Mathf.Abs(transform.localScale.x), transform.localScale.y);
        }
        else if (movingToTheRight)
        {
            transform.localScale = new Vector2(Mathf.Abs(transform.localScale.x), transform.localScale.y);
        }
    }

    private void CacheComponentReferences()
    {
        myRigidbody2D = GetComponent<Rigidbody2D>();
        mySpriteRenderer = GetComponent<SpriteRenderer>();
    }
}
