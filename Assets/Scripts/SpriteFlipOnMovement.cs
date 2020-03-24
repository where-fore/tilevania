using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//If moving to the left, turns the 'flipX' bool to true - flips the sprite if it is moving to the left
//this requires the sprite to be facing to the right when moving to the right


public class SpriteFlipOnMovement : MonoBehaviour
{
    private Rigidbody2D myRigidbody2D = null;
    private SpriteRenderer mySpriteRenderer = null;

    private float turnBuffer = 1f; // The amount of velocity needed to turn a sprite - do not make this 0 for rounding reasons.

    // Start is called before the first frame update
    void Start()
    {
        myRigidbody2D = GetComponent<Rigidbody2D>();
        mySpriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        float myXVelocity = myRigidbody2D.velocity.x;
        bool movingToTheLeft = false;
        bool movingToTheRight = false;

        if (myXVelocity > turnBuffer)
        {
            movingToTheRight = true;
        }
        else if (myXVelocity < -turnBuffer)
        {
            movingToTheLeft = true;
        }

        if (movingToTheLeft)
        {
            mySpriteRenderer.flipX = true;
            Debug.Log("flip left");
        }
        else if (movingToTheRight)
        {
            mySpriteRenderer.flipX = false;
            Debug.Log("flip right");
        }
    }
}
