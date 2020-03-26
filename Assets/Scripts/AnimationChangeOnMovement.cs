using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationChangeOnMovement : MonoBehaviour
{

    // Config
    private float movementBuffer = 1f; // The amount of velocity needed to count as moving - do not make this 0 for float rounding reasons.

    private string isRunningAnimatorBoolString = "IsRunning";

    // Cached Component References
    private Rigidbody2D myRigidbody2D = null;
    private Animator myAnimator = null;


    void Start()
    {
        CacheComponentReferences();
    }

    void Update()
    {
        float myXVelocity = myRigidbody2D.velocity.x;
        bool moving = true;

        if (myXVelocity > movementBuffer)
        {
            moving = true;
        }
        else if (myXVelocity < -movementBuffer)
        {
            moving = true;
        }
        else
        {
            moving = false;
        }

        if (moving == true)
        {
            myAnimator.SetBool(isRunningAnimatorBoolString, true);
        }
        else if (moving == false)
        {
            myAnimator.SetBool(isRunningAnimatorBoolString, false);
        }
    }

    private void CacheComponentReferences()
    {
        myRigidbody2D = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
    }
}
